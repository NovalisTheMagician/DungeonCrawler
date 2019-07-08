using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public static class NumericExtension
    {
        public static float ToRadians(this float val)
        {
            return ((float)Math.PI / 180.0f) * val;
        }

        public static float ToDegrees(this float val)
        {
            return (180.0f / (float)Math.PI) * val;
        }
    }
}
