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
        private struct PlaneVertices
        {
            public Vector3 A { get; set; }
            public Vector3 B { get; set; }
            public Vector3 C { get; set; }
        }

        private Dictionary<Plane, PlaneVertices> PlaneVerts { get; set; }

        [JsonIgnore]
        public List<Plane> Planes
        {
            get
            {
                return PlaneVerts.Keys.ToList();
            }
        }

        [JsonIgnore]
        public int PlaneCount
        {
            get
            {
                return PlaneVerts.Count;
            }
        }

        private BoundingBox boundingBox;

        [JsonIgnore]
        public bool IsValid { get; private set; }

        [JsonIgnore]
        public Mesh Mesh { get; private set; }

        public Brush()
        {
            PlaneVerts = new Dictionary<Plane, PlaneVertices>();
            boundingBox = new BoundingBox();
        }

        public void AddPlane(Vector3 a, Vector3 b, Vector3 c)
        {
            PlaneVertices planeVert = new PlaneVertices()
            {
                A = a,
                B = b,
                C = c
            };

            Plane p = Plane.CreateFromVertices(a, b, c);
            PlaneVerts.Add(p, planeVert);

            //CalcBoundingBox();
        }

        public void CalcBoundingBox()
        {
            if (PlaneCount < 3)
            {
                IsValid = false;
                return;
            }

            Vector3 min = new Vector3(float.MaxValue);
            Vector3 max = new Vector3(float.MinValue);
            foreach(PlaneVertices vertices in PlaneVerts.Values)
            {
                min = Vector3.Min(min, vertices.A);
                min = Vector3.Min(min, vertices.B);
                min = Vector3.Min(min, vertices.C);

                max = Vector3.Max(max, vertices.A);
                max = Vector3.Max(max, vertices.B);
                max = Vector3.Max(max, vertices.C);
            }

            boundingBox.Min = min;
            boundingBox.Max = max;
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
            Mesh mesh = new Mesh();
            List<Vertex> vertices = mesh.Vertices;

            int planeCount = PlaneCount;

            for(int i = 0; i < planeCount; ++i)
            {
                Plane a = Planes[i];
                Vector3 an = a.Normal;
                for(int j = 0; j < planeCount; ++j)
                {
                    if (j == i) continue;
                    Plane b = Planes[j % planeCount];
                    Vector3 bn = b.Normal;
                    Plane c = Planes[(j + 1) % planeCount];
                    Vector3 cn = c.Normal;

                    Vector3 cross = Vector3.Cross(bn, cn);
                    float denom = Vector3.Dot(an, cross);
                    if (Math.Abs(denom) > 0.001f)
                    {
                        Vector3 ab = Vector3.Cross(an, bn);
                        Vector3 bc = Vector3.Cross(bn, cn);
                        Vector3 ca = Vector3.Cross(cn, an);

                        Vector3 point = -a.D * bc - b.D * Vector3.Cross(cn, an) - c.D * Vector3.Cross(an, bn);
                        point /= denom;
                        if (boundingBox.PointInBox(point))
                        {
                            Vertex v = new Vertex();
                            v.Position = point;
                            vertices.Add(v);
                        }
                    }
                }
            }

            Mesh = mesh;
            return mesh;
        }
    }
}
