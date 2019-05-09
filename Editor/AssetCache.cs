using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public class AssetCache
    {
        public delegate void AssetReloaded();
        public event AssetReloaded OnAssetReloaded;

        public delegate void AssetAdded(string name, IAsset asset);
        public event AssetAdded OnAssetAdded;

        public delegate void AssetRemoved(string name, IAsset asset);
        public event AssetRemoved OnAssetRemoved;

        public delegate void AssetChanged(string name, IAsset asset);
        public event AssetChanged OnAssetChanged;

        private IDictionary<Type, Dictionary<string, IAsset>> assets;
        private IDictionary<string, IAssetLoader> assetLoaders;
        private IDictionary<string, string> assetNameToPath;
        private IDictionary<string, DateTime> assetLastModified;

        public string AssetPath { get; set; }

        public AssetCache()
        {
            assets = new Dictionary<Type, Dictionary<string, IAsset>>();
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
            assets.Add(loader.GetAssociatedAssetType(), new Dictionary<string, IAsset>());
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

                foreach (IDictionary<string, IAsset> assetEntry in assets.Values)
                {
                    foreach(string assetName in assetEntry.Keys)
                    {
                        if(name == assetName)
                        {
                            if(assetTime != assetLastModified[name])
                            {
                                //file changed!
                                IAsset changedAsset = loader.LoadAsset(file, this);
                                if(changedAsset != null)
                                {
                                    assetEntry[name] = changedAsset;
                                    assetLastModified[name] = assetTime;

                                    OnAssetChanged?.Invoke(name, changedAsset);
                                }

                                fileHandled = true;
                            }
                        }
                    }
                }

                if (fileHandled)
                    continue;

                //might be new file
                IAsset asset = loader.LoadAsset(file, this);
                if (asset != null)
                {
                    assets[loader.GetAssociatedAssetType()].Add(name, asset);
                    assetNameToPath.Add(name, file);
                    assetLastModified.Add(name, assetTime);

                    OnAssetAdded?.Invoke(name, asset);
                }
            }
        }

        public void ClearAll()
        {
            foreach (Dictionary<string, IAsset> assetDict in assets.Values)
            {
                foreach (KeyValuePair<string, IAsset> assetEntry in assetDict)
                {
                    string name = assetEntry.Key;
                    IAsset asset = assetEntry.Value;

                    string ext = Path.GetExtension(name);

                    IAssetLoader loader = assetLoaders[ext];
                    loader.SaveAsset(assetNameToPath[name], asset);

                    asset.Dispose();
                }

                assetDict.Clear();
            }
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
                    IAsset asset = loader.LoadAsset(file, this);
                    if(asset != null)
                    {
                        DateTime time = File.GetLastWriteTime(file);

                        assets[loader.GetAssociatedAssetType()].Add(name, asset);
                        assetNameToPath.Add(name, file);
                        assetLastModified.Add(name, time);
                    }
                }
            }

            OnAssetReloaded?.Invoke();
        }

        public IList<IAsset> GetAllAssets()
        {
            IList<IAsset> assetList = new List<IAsset>();
            foreach(Dictionary<string, IAsset> assetDict in assets.Values)
            {
                foreach(IAsset asset in assetDict.Values)
                {
                    assetList.Add(asset);
                }
            }
            return assetList;
        }

        public T GetAsset<T>(string name) where T : IAsset
        {
            Type type = typeof(T);
            if(assets.ContainsKey(type))
            {
                if(assets[type].ContainsKey(name))
                {
                    return (T)assets[type][name];
                }
            }
            return default(T);
        }
    }
}
