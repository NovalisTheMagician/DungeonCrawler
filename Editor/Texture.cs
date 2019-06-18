using Editor.Properties;
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
    public class Texture : BaseAsset
    {
        public int Width { get { return TextureBitmap.Width; } }
        public int Height { get { return TextureBitmap.Height; } }

        public Bitmap TextureBitmap { get; private set; }

        public Texture()
        {
            TextureBitmap = Resources.ErrorImage;
        }

        public Texture(Bitmap textureBitmap)
        {
            TextureBitmap = textureBitmap;
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
