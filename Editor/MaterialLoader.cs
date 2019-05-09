using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public class MaterialLoader : IAssetLoader
    {
        public Type GetAssociatedAssetType()
        {
            return typeof(Material);
        }

        public string[] GetAssociatedExtensions()
        {
            return new[] { ".mat" };
        }

        public IAsset LoadAsset(string file, AssetCache assetCache)
        {
            Material material = new Material();

            using (Stream stream = new FileStream(file, FileMode.Open))
            {
                if (!material.Load(stream))
                    return null;
            }

            string tagFile = $"{file}.tags";
            if (File.Exists(tagFile))
            {
                using (StreamReader tagStreamReader = File.OpenText(tagFile))
                {
                    ulong tagVal = ulong.Parse(tagStreamReader.ReadLine());
                    material.Tags = new Tags(tagVal);
                }
            }

            material.Name = Path.GetFileName(file);

            return material;
        }

        public void SaveAsset(string file, IAsset asset)
        {
            using (Stream stream = new FileStream(file, FileMode.Create))
            {
                asset.Save(stream);
            }

            string tagToSave = $"{(asset as Material).Tags.Bitfield}\n";
            File.WriteAllText($"{file}.tags", tagToSave);
        }
    }
}
