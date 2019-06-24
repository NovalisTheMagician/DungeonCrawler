using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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
                    if(tag != string.Empty)
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
            assetPanel.Controls.Clear();

            foreach(BaseAsset asset in assets)
            {
                Panel item = new Panel();
                item.BackColor = Color.PaleVioletRed;
                item.Size = new Size(128, 128);
                PictureBox image = new PictureBox();
                image.Size = new Size(118, 118);
                image.Image = asset.GetImage();
                image.SizeMode = PictureBoxSizeMode.StretchImage;
                image.Location = new Point(5, 5);
                item.Controls.Add(image);
                assetPanel.Controls.Add(item);
            }

            filteredAssetsLabel.Text = $"{assets.Count}";
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
