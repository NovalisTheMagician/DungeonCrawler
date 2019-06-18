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
