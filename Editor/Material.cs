using System;
using System.Drawing;
using System.IO;

namespace Editor
{
    public class Material : BaseAsset
    {
        public string Diffuse { get; set; }
        public string Normal { get; set; }
        public string Specular { get; set; }

        public Material()
        {
            Diffuse = "";
            Normal = "";
            Specular = "";
        }

        public override void Dispose()
        {
            
        }
    }
}
