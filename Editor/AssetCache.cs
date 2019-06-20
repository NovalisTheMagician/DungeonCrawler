using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    [Flags]
    public enum FilterType
    {
        NONE = 0,
        TEXTURES = 1,
        MATERIALS = 2,
        MODELS = 3,
        SOUNDS = 4,
        MUSIC = 5,
        ALL = 0xFF
    }

    public class AssetCache
    {
        public delegate void AssetReloaded();
        public event AssetReloaded OnAssetReloaded;

        public delegate void AssetAdded(string name, BaseAsset asset);
        public event AssetAdded OnAssetAdded;

        public delegate void AssetRemoved(string name, BaseAsset asset);
        public event AssetRemoved OnAssetRemoved;

        public delegate void AssetChanged(string name, BaseAsset asset);
        public event AssetChanged OnAssetChanged;

        private IDictionary<string, BaseAsset> assets;
        private IDictionary<string, IAssetLoader> assetLoaders;
        private IDictionary<string, string> assetNameToPath;
        private IDictionary<string, DateTime> assetLastModified;

        public string AssetPath { get; set; }

        public AssetCache()
        {
            assets = new Dictionary<string, BaseAsset>();
            assetLoaders = new Dictionary<string, IAssetLoader>();
            assetNameToPath = new Dictionary<string, string>();
            assetLastModified = new Dictionary<string, DateTime>();
        }

        public void RegisterLoader(IAssetLoader loader)
        {
            string[] exts = loader.GetAssociatedExtensions();
            foreach(string extension in exts)
            {
                assetLoaders.Add(extension, loader);
            }
        }

        public void CheckChanges()
        {
            string[] files = Directory.GetFiles(AssetPath, "*.*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                bool fileHandled = false;
                string ext = Path.GetExtension(file);
                if (!assetLoaders.ContainsKey(ext))
                    continue;
                IAssetLoader loader = assetLoaders[ext];
                DateTime assetTime = File.GetLastWriteTime(file);

                foreach(string assetName in assets.Keys)
                {
                    if(name == assetName)
                    {
                        if(assetTime != assetLastModified[name])
                        {
                            //file changed!
                            BaseAsset changedAsset = loader.LoadAsset(file, this);
                            if(changedAsset != null)
                            {
                                assets[name] = changedAsset;
                                assetLastModified[name] = assetTime;

                                OnAssetChanged?.Invoke(name, changedAsset);
                            }
                        }

                        fileHandled = true;
                    }
                }

                if (fileHandled)
                    continue;

                //might be new file
                BaseAsset asset = loader.LoadAsset(file, this);
                if (asset != null)
                {
                    assets.Add(name, asset);
                    assetNameToPath.Add(name, file);
                    assetLastModified.Add(name, assetTime);

                    OnAssetAdded?.Invoke(name, asset);
                }
            }
        }

        public void ClearAll()
        {
            foreach (KeyValuePair<string, BaseAsset> assetEntry in assets)
            {
                string name = assetEntry.Key;
                BaseAsset asset = assetEntry.Value;

                string ext = Path.GetExtension(name);

                IAssetLoader loader = assetLoaders[ext];
                loader.SaveAsset(assetNameToPath[name], asset);

                asset.Dispose();
            }

            assets.Clear();
        }

        public void ReloadAll()
        {
            ClearAll();
            string[] files = Directory.GetFiles(AssetPath, "*.*", SearchOption.AllDirectories);
            foreach(string file in files)
            {
                string ext = Path.GetExtension(file);
                if(assetLoaders.ContainsKey(ext))
                {
                    string name = Path.GetFileName(file);

                    IAssetLoader loader = assetLoaders[ext];
                    BaseAsset asset = loader.LoadAsset(file, this);
                    if(asset != null)
                    {
                        DateTime time = File.GetLastWriteTime(file);

                        assets.Add(name, asset);
                        assetNameToPath.Add(name, file);
                        assetLastModified.Add(name, time);
                    }
                }
            }

            OnAssetReloaded?.Invoke();
        }

        public IList<BaseAsset> GetAssets(FilterType filter, string nameFilter, HashSet<string> tags)
        {

            IEnumerable<BaseAsset> assetsFound =  from asset
                                                  in assets.Values
                                                  where (asset as BaseAsset).Name.Contains(nameFilter) &&
                                                        ((asset as BaseAsset).Tags.Intersect(tags).Count() > 0) || (tags.Count == 0) &&
                                                        filter.HasFlag(FilterType.TEXTURES) ? asset is Texture :
                                                        filter.HasFlag(FilterType.MATERIALS) ? asset is Material :
                                                        true
                                                  select asset;

            return assetsFound.ToList();
        }

        public IList<BaseAsset> GetAllAssets()
        {
            return assets.Values.ToList();
        }

        public T GetAsset<T>(string name) where T : BaseAsset
        {
            if(assets.ContainsKey(name))
            {
                BaseAsset asset = assets[name];
                if (asset is T)
                    return (T)asset;
            }
            return default(T);
        }
    }
}
