using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Editor.Brush
{
    public struct Vertex
    {
        public Vector3 Position { get; set; }
        public Vector3 Normal { get; set; }
        public Vector2 TexCoord { get; set; }
    }

    public class Mesh
    {
        private List<Vertex> vertices;

        public Mesh()
        {
            vertices = new List<Vertex>();
        }
    }
}
