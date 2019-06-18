
namespace Editor
{
    public interface IAssetLoader
    {
        string[] GetAssociatedExtensions();
        BaseAsset LoadAsset(string file, AssetCache assetCache);
        void SaveAsset(string file, BaseAsset asset);
    }
}
