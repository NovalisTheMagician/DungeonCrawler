using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    static class AssetCaches
    {
        private static AssetCache<Texture> textureCache;
        private static AssetCache<Material> materialCache;

        public static void Initialize()
        {
            textureCache = new AssetCache<Texture>();
            materialCache = new AssetCache<Material>();
        }

        public static AssetCache<Texture> TextureCache
        {
            get { return textureCache; }
        }

        public static AssetCache<Material> MaterialCache
        {
            get { return materialCache; }
        }
    }
}
