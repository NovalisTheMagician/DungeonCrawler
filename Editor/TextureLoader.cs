using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public class TextureLoader : IAssetLoader
    {
        public Type GetAssociatedAssetType()
        {
            return typeof(Texture);
        }

        public string[] GetAssociatedExtensions()
        {
            return new[] { ".png", ".bmp" };
        }

        public IAsset LoadAsset(string file, AssetCache assetCache)
        {
            Texture texture = new Texture();

            using (Stream stream = new FileStream(file, FileMode.Open))
            {
                if (!texture.Load(stream))
                    return null;
            }

            string tagFile = $"{file}.tags";
            if (File.Exists(tagFile))
            {
                using (StreamReader tagStreamReader = File.OpenText(tagFile))
                {
                    ulong tagVal = ulong.Parse(tagStreamReader.ReadLine());
                    texture.Tags = new Tags(tagVal);
                }
            }

            texture.Name = Path.GetFileName(file);

            return texture;
        }

        public void SaveAsset(string file, IAsset asset)
        {
            string tagToSave = $"{(asset as Texture).Tags.Bitfield}\n";
            File.WriteAllText($"{file}.tags", tagToSave);
        }
    }
}
