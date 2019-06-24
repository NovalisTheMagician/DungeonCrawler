using System;
using System.Text.Json.Serialization;
using System.IO;

namespace Editor
{
    public class MaterialLoader : BaseAssetLoader
    {
        public override string[] GetAssociatedExtensions()
        {
            return new[] { ".mat" };
        }

        public override BaseAsset LoadAsset(string file, AssetCache assetCache)
        {
            Material material = new Material();

            string materialJson = File.ReadAllText(file);

            material = JsonSerializer.Parse<Material>(materialJson);

            if(material.Diffuse != string.Empty)
            {
                Texture diffuse = assetCache.GetAsset<Texture>(material.Diffuse);
                if (diffuse != null) material.DiffuseTexture = diffuse;
            }

            if (material.Normal != string.Empty)
            {
                Texture normal = assetCache.GetAsset<Texture>(material.Normal);
                if (normal != null) material.NormalTexture = normal;
            }

            if (material.Specular != string.Empty)
            {
                Texture specular = assetCache.GetAsset<Texture>(material.Specular);
                if (specular != null) material.SpecularTexture = specular;
            }

            return LoadTag(file, material);
        }

        public override void SaveAsset(string file, BaseAsset asset)
        {
            string materialJson = JsonSerializer.ToString<Material>(asset as Material);
            File.WriteAllText(file, materialJson);

            base.SaveAsset(file, asset);
        }
    }
}
