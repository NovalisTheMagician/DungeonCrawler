using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Editor.Forms
{
    public partial class AssetManager : Form
    {
        public AssetCache AssetCache { get; set; }

        private FilterType Filter
        {
            get
            {
                FilterType type = 0;
                if (texturesTglBtn.Checked) type |= FilterType.TEXTURES;
                if (materialsTglBtn.Checked) type |= FilterType.MATERIALS;
                if (modelsTglBtn.Checked) type |= FilterType.MODELS;
                if (soundsTglBtn.Checked) type |= FilterType.SOUNDS;
                if (musicTglBtn.Checked) type |= FilterType.MUSIC; 
                return type;
            }
        }

        private HashSet<string> Tags
        {
            get
            {
                HashSet<string> tags = new HashSet<string>();
                foreach(string tag in tagsTextBox.Lines)
                {
                    tags.Add(tag);
                }
                return tags;
            }
        }

        public AssetManager()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            AssetCache.OnAssetAdded += OnAssetAdded;
            AssetCache.OnAssetChanged += OnAssetChanged;
            AssetCache.OnAssetReloaded += OnAssetsReloaded;
            AssetCache.OnAssetRemoved += OnAssetRemoved;

            totalAssetsLabel.Text = $"{AssetCache.GetAllAssets().Count}";

            UpdateList(null, new EventArgs());
            AssetCache.CheckChanges();
        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            AssetCache.OnAssetAdded -= OnAssetAdded;
            AssetCache.OnAssetChanged -= OnAssetChanged;
            AssetCache.OnAssetReloaded -= OnAssetsReloaded;
            AssetCache.OnAssetRemoved -= OnAssetRemoved;
        }

        private void UpdateList(object sender, EventArgs e)
        {
            string textFilter = filterTextBox.Text;

            IList<BaseAsset> assets = AssetCache.GetAssets(Filter, textFilter, Tags);
            Console.WriteLine("Update!");
        }

        private void OnAssetsReloaded()
        {
            UpdateList(null, new EventArgs());
        }

        private void OnAssetAdded(string name, BaseAsset asset)
        {

        }

        private void OnAssetRemoved(string name, BaseAsset asset)
        {

        }

        private void OnAssetChanged(string name, BaseAsset asset)
        {

        }

        private void OnRefreshBtnClick(object sender, EventArgs e)
        {
            AssetCache.CheckChanges();
        }

        private void OnNewMaterialBtnClick(object sender, EventArgs e)
        {

        }

        private void OnExistingAssetBtnClick(object sender, EventArgs e)
        {

        }

        private void OnCloseBtnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnTextboxEnterPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                UpdateList(sender, new EventArgs());
        }
    }
}
