using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public interface IAssetLoader
    {
        string[] GetAssociatedExtensions();
        Type GetAssociatedAssetType();
        IAsset LoadAsset(string file, AssetCache assetCache);
        void SaveAsset(string file, IAsset asset);
    }
}
