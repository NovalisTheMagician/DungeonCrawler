using System;
using System.Collections.Generic;
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

        public AssetBase()
        {
            Tags = new Tags();
        }

        public abstract bool Construct(Stream stream);
        public abstract void Save(Stream stream);
        public abstract void Dispose();
    }
}
