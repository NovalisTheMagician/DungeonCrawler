using Editor.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Text.Json.Serialization;

namespace Editor
{
    public class Material : BaseAsset
    {
        public string Diffuse { get; set; }
        public string Normal { get; set; }
        public string Specular { get; set; }

        [JsonIgnore]
        public Texture DiffuseTexture { get; set; }
        [JsonIgnore]
        public Texture NormalTexture { get; set; }
        [JsonIgnore]
        public Texture SpecularTexture { get; set; }

        public Material()
        {
            Diffuse = "";
            Normal = "";
            Specular = "";
            DiffuseTexture = Texture.NO_TEXTURE;
            NormalTexture = Texture.NO_TEXTURE;
            SpecularTexture = Texture.NO_TEXTURE;
        }

        public override void Dispose()
        {
        }

        public override Bitmap GetImage()
        {
            return DiffuseTexture.TextureBitmap;
        }
    }
}
