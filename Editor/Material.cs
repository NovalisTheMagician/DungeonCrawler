using System;
using System.IO;
using Newtonsoft.Json;

namespace Editor
{
    [Serializable]
    public class Material : AssetBase
    {
        public string Diffuse { get; set; }
        public string Normal { get; set; }
        public string Specular { get; set; }

        public Material()
        {

        }

        public string GetPreviewTexture()
        {
            if (Diffuse != null && Diffuse != string.Empty)
                return Diffuse;
            if (Normal != null && Normal != string.Empty)
                return Normal;
            if (Specular != null && Specular != string.Empty)
                return Specular;
            return "";
        }

        public override bool Construct(Stream stream)
        {
            JsonSerializer serializer = new JsonSerializer();

            using (StreamReader reader = new StreamReader(stream))
            using (JsonTextReader jsonTextReader = new JsonTextReader(reader))
            {
                Material tmp = serializer.Deserialize<Material>(jsonTextReader);
                if(tmp != null)
                {
                    Diffuse = tmp.Diffuse;
                    Normal = tmp.Normal;
                    return true;
                }
                return false;
            }
        }

        public override void Dispose()
        {
            
        }
    }
}
