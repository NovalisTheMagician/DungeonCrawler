using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Editor.Controls
{
    public partial class TextureView : UserControl
    {
        private TextureCache textureCache;
        public TextureCache TextureCache
        {
            get
            {
                return textureCache;
            }

            set
            {
                textureCache = value;
                ReloadAllItems();
            }
        }

        public TextureView()
        {
            InitializeComponent();
        }

        private void ReloadAllItems()
        {
            textureFlowPanel.Controls.Clear();

            var textureList = textureCache.TextureFiles;
            var textureMap = textureCache.Textures;
            
            foreach(string textureFile in textureList.OrderBy(o => o).ToList())
            {
                string name = GetName(textureFile);
                Image texture = textureMap[textureFile];
                textureFlowPanel.Controls.Add(CreateTextureItem(name, texture));
            }
        }

        private TextureItem CreateTextureItem(string name, Image texture)
        {
            TextureItem item = new TextureItem();
            item.Texture = texture;
            item.TextureName = name;
            return item;
        }

        public void RefreshTextures()
        {
            if (textureCache != null)
            {
                textureCache.RefreshTextures();
                ReloadAllItems();
            }
        }

        public void ReloadTextures()
        {
            if (textureCache != null)
            {
                textureCache.ReloadTextures();
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
