using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Editor.Brush
{
    public class Brush
    {
        private List<Plane> Planes { get; set; }

        [JsonIgnore]
        public bool IsValid { get; private set; }

        [JsonIgnore]
        public Mesh Mesh { get; private set; }

        public Brush()
            : this(64, 64, 64)
        {

        }

        public Brush(int width, int height, int depth)
        {
            Planes = new List<Plane>();
        }

        public Mesh CreateMesh()
        {
            return null;
        }
    }
}
