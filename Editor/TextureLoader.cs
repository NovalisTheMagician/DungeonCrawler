using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public class TextureLoader : BaseAssetLoader
    {
        public override string[] GetAssociatedExtensions()
        {
            return new[] { ".png", ".bmp" };
        }

        public override BaseAsset LoadAsset(string file, AssetCache assetCache)
        {
            Texture texture = null;

            using (Stream stream = new FileStream(file, FileMode.Open))
            {
                try
                {
                    Bitmap textureBitmap = new Bitmap(stream);
                    texture = new Texture(textureBitmap);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }

            return LoadTag(file, texture);
        }

        public override void SaveAsset(string file, BaseAsset asset)
        {
            base.SaveAsset(file, asset);
        }
    }
}
