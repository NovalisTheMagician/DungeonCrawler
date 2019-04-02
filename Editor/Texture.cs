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
    public class Texture : IAsset
    {
        public int Width { get; private set; }

        public int Height { get; private set; }

        public byte[] TextureData { get; private set; }
        
        public Bitmap TextureBitmap { get; private set; }

        public bool Construct(Stream stream)
        {
            if (TextureBitmap != null)
                TextureBitmap.Dispose();
            
            try
            {
                TextureBitmap = new Bitmap(stream);
            }
            catch(ArgumentException e)
            {
                return false;
            }

            Width = TextureBitmap.Width;
            Height = TextureBitmap.Height;

            BitmapData bitmapData = TextureBitmap.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            IntPtr ptr = bitmapData.Scan0;
            int numBytes = Math.Abs(bitmapData.Stride) * Height;
            TextureData = new byte[numBytes];

            System.Runtime.InteropServices.Marshal.Copy(ptr, TextureData, 0, numBytes);

            TextureBitmap.UnlockBits(bitmapData);

            return true;
        }
        
        public void Dispose()
        {
            if(TextureBitmap != null)
            {
                TextureBitmap.Dispose();
                TextureBitmap = null;
            }
        }
    }
}
