using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Editor.Brush
{
    public static class VectorMathExtensions
    {
        public static bool PointInBox(this BoundingBox bbox, Vector3 point)
        {
            if (point.X >= bbox.Min.X && point.Y >= bbox.Min.Y && point.Z >= bbox.Min.Z &&
                point.X <= bbox.Max.X && point.Y <= bbox.Max.Y && point.Z <= bbox.Max.Z)
                return true;
            return false;
        }
    }
}
