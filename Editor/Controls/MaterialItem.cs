using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Editor.Properties;

namespace Editor.Controls
{
    public partial class MaterialItem : UserControl
    {
        private AssetCache<Texture> textureCache;

        private Image previewImage;
        private Material material;
        public Material Material
        {
            set
            {
                material = value;
                string previewTexture = material.GetPreviewTexture();
                if(previewTexture != string.Empty)
                {
                    Texture texture = textureCache.Assets[previewTexture];
                    if(texture != null)
                    {
                        previewImage = texture.TextureBitmap;
                    }
                }
            }
        }

        public TagManager TagManager { get; set; }

        public string MaterialName
        {
            set
            {
                materialLabel.Text = value;
            }
        }

        public MaterialItem(AssetCache<Texture> textureCache)
        {
            InitializeComponent();

            this.textureCache = textureCache;

            previewImage = Resources.ErrorImage;
            MaterialName = "Error!";
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(previewImage, new Rectangle(0, 0, this.Width, this.Height));
        }

        private void OnEditBtnClick(object sender, EventArgs e)
        {

        }

        private void OnDeleteBtnClick(object sender, EventArgs e)
        {

        }
    }
}
