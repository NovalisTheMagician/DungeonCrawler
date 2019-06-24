using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public abstract class BaseAssetLoader : IAssetLoader
    {
        public BaseAsset LoadTag(string file, BaseAsset asset)
        {
            asset.Name = Path.GetFileName(file);
            asset.Path = file;

            string tagFile = $"{file}.tags";
            if (File.Exists(tagFile))
            {
                using (StreamReader tagStreamReader = File.OpenText(tagFile))
                {
                    while(!tagStreamReader.EndOfStream)
                    {
                        string tag = tagStreamReader.ReadLine();
                        asset.Tags.Add(tag);
                    }
                }
            }
            return asset;
        }

        public virtual void SaveAsset(string file, BaseAsset asset)
        {
            using (StreamWriter tagStreamWriter = File.CreateText($"{file}.tags"))
            {
                foreach(string tag in asset.Tags)
                {
                    tagStreamWriter.WriteLine(tag);
                }
            }
        }

        public abstract BaseAsset LoadAsset(string file, AssetCache assetCache);
        public abstract string[] GetAssociatedExtensions();
    }
}
