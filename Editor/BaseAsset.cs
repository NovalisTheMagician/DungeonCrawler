using Editor.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Editor
{
    public abstract class BaseAsset
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

        public abstract void Dispose();
    }
}
