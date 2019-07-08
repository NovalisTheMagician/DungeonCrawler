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
        public List<Plane> Planes { get; private set; }

        private BoundingBox boundingBox;

        [JsonIgnore]
        public bool IsValid { get; private set; }

        [JsonIgnore]
        public Mesh Mesh { get; private set; }

        public Brush()
        {
            Planes = new List<Plane>();
        }

        public Brush(float size)
            : this(size, size, size)
        {

        }

        public Brush(float width, float height, float depth)
        {
            Planes = new List<Plane>();
            float halfWidth = width / 2;
            float halfHeight = height / 2;
            float halfDepth = depth / 2;

            Plane front = new Plane(-Vector3.UnitZ, halfDepth);
            Plane back = new Plane(Vector3.UnitZ, halfDepth);

            Plane left = new Plane(-Vector3.UnitX, halfWidth);
            Plane right = new Plane(Vector3.UnitX, halfWidth);

            Plane bottom = new Plane(-Vector3.UnitY, halfHeight);
            Plane top = new Plane(Vector3.UnitY, halfHeight);

            Planes.AddRange(new Plane[] 
            {
                front, back, left, right, bottom, top
            });
        }

        public void AddPlane(Plane p)
        {
            Planes.Add(p);
        }

        public void CalcBoundingBox()
        {

        }

        public static void Sub(Brush a, Brush b, out List<Brush> result)
        {
            result = null;
        }

        public static void Clip(Brush toClip, Plane clippingPlane, out Brush a, out Brush b)
        {
            a = null;
            b = null;
        }

        public Mesh CreateMesh()
        {
            return null;
        }
    }
}
