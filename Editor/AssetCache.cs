using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public class AssetCache<T> where T : IAsset, new()
    {
        public delegate void AssetReloaded();
        public event AssetReloaded OnAssetReloaded;

        private string baseAssetPath;
        public string BaseAssetPath
        {
            get { return baseAssetPath; }
            set { baseAssetPath = value; ReloadAssets(); }
        }

        private Dictionary<string, T> assetMap;

        public IReadOnlyList<string> AssetFiles
        {
            get
            {
                return assetMap.Keys.ToList();
            }
        }

        public IReadOnlyDictionary<string, T> Assets
        {
            get
            {
                return assetMap;
            }
        }

        public AssetCache()
        {
            assetMap = new Dictionary<string, T>();
        }

        public void ReloadAssets()
        {
            foreach (T asset in assetMap.Values)
            {
                asset.Dispose();
            }
            assetMap.Clear();

            if (!Directory.Exists(baseAssetPath))
                Directory.CreateDirectory(baseAssetPath);

            string[] files = Directory.GetFiles(baseAssetPath);
            foreach (string file in files)
            {
                T asset = new T();
                using (FileStream fs = new FileStream(file, FileMode.Open))
                {
                    if (asset.Construct(fs))
                    {
                        assetMap.Add(file, asset);
                    }
                    else
                    {
                        asset.Dispose();
                    }
                }
            }

            OnAssetReloaded?.Invoke();
        }

        public void RefreshAssets()
        {
            foreach (var assMap in assetMap.ToList())
            {
                string file = assMap.Key;
                T asset = assMap.Value;

                asset.Dispose();

                if (!File.Exists(file))
                {
                    assetMap.Remove(file);
                }
                else
                {
                    // optimize here to only load the images which have been changed since last loaded
                    // (check file last modified date and store the date somewhere)
                    using (FileStream fs = new FileStream(file, FileMode.Open))
                    {
                        if (!asset.Construct(fs))
                        {
                            assetMap.Remove(file);
                        }
                    }
                }
            }

            OnAssetReloaded?.Invoke();
        }
    }
}
