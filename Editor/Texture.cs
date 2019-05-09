using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public class Texture : AssetBase
    {
        public int Width { get { return TextureBitmap.Width; } }

        public int Height { get { return TextureBitmap.Height; } }
        
        public Bitmap TextureBitmap { get; private set; }

        public override Bitmap GetPreviewImage()
        {
            return PreviewImage;
        }

        public override bool Load(Stream stream)
        {
            try
            {
                TextureBitmap = new Bitmap(stream);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }

        public override void Save(Stream stream)
        {
            
        }

        public override void Dispose()
        {
            if(TextureBitmap != null)
            {
                TextureBitmap.Dispose();
                TextureBitmap = null;
            }
        }
    }
}
