using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Drawing;

namespace Editor
{
    public interface IAsset : IDisposable
    {
        bool Load(Stream stream);
        void Save(Stream stream);
        Bitmap GetPreviewImage();
    }
}
