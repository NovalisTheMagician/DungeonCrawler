using System;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;

namespace Editor.Controls
{
    public partial class TextureView : UserControl
    {
        private AssetCache<Texture> textureCache;

        [Browsable(false)]
        public AssetCache<Texture> TextureCache
        {
            get
            {
                return textureCache;
            }

            set
            {
                if(value != null)
                {
                    textureCache = value;
                    ReloadAllItems();
                }
            }
        }

        [Browsable(false)]
        public TagManager TagManager { get; set; }

        public TextureView()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void ReloadAllItems()
        {
            textureFlowPanel.Controls.Clear();

            var textureList = textureCache.AssetFiles;
            var textureMap = textureCache.Assets;
            
            foreach(string textureFile in textureList.OrderBy(o => o).ToList())
            {
                string name = GetName(textureFile);
                Texture texture = textureMap[textureFile];
                textureFlowPanel.Controls.Add(CreateTextureItem(name, texture));
            }

            textureFlowPanel.Refresh();
        }

        private TextureItem CreateTextureItem(string name, Texture texture)
        {
            TextureItem item = new TextureItem();
            item.Texture = texture;
            item.TextureName = name;
            item.TagManager = TagManager;
            return item;
        }

        public void RefreshTextures()
        {
            if (textureCache != null)
            {
                textureCache.RefreshAssets();
                ReloadAllItems();
            }
        }

        public void ReloadTextures()
        {
            if (textureCache != null)
            {
                textureCache.ReloadAssets();
                ReloadAllItems();
            }
        }

        private string GetName(string path)
        {
            return Path.GetFileNameWithoutExtension(path);
        }

        private void RefreshBtnClick(object sender, EventArgs e)
        {
            RefreshTextures();
        }

        private void ReloadBtnClick(object sender, EventArgs e)
        {
            ReloadTextures();
        }

        private void OnVisibleChanged(object sender, EventArgs e)
        {
            if(this.Visible)
            {
                ReloadTextures();
            }
            else
            {
                textureFlowPanel.Controls.Clear();
            }
        }
    }
}
