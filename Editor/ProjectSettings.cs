using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public struct ProjectSettings
    {
        public string Name { get; set; }
        public int Version { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
