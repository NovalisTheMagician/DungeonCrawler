using Editor.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public abstract class AssetBase : IAsset
    {
        public Tags Tags { get; set; }
        public string Name { get; set; }
        
        public Bitmap PreviewImage { get; set; }

        public AssetBase()
        {
            Tags = new Tags();
            PreviewImage = Resources.ErrorImage;
        }

        public abstract Bitmap GetPreviewImage();
        public abstract void Dispose();
        public abstract bool Load(Stream stream);
        public abstract void Save(Stream stream);
    }
}
