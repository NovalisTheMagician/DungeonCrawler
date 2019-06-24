using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.Json.Serialization;

namespace Editor
{
    public abstract class BaseAsset : IDisposable
    {
        [JsonIgnore]
        public HashSet<string> Tags { get; }

        [JsonIgnore]
        public string Name { get; set; }

        [JsonIgnore]
        public string Path { get; set; }

        public BaseAsset()
        {
            Tags = new HashSet<string>();
        }

        public abstract Bitmap GetImage();

        public abstract void Dispose();
    }
}
