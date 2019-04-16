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
using Editor.Forms;
using System.IO;

namespace Editor.Controls
{
    public partial class MaterialItem : UserControl
    {
        private AssetCache<Texture> textureCache;
        private AssetCache<Material> materialCache;

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
                    Texture texture = textureCache[previewTexture];
                    if(texture != null)
                    {
                        previewImage = texture.TextureBitmap;
                        Invalidate();
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

        public MaterialItem(AssetCache<Texture> textureCache, AssetCache<Material> materialCache)
        {
            InitializeComponent();

            this.textureCache = textureCache;
            this.materialCache = materialCache;

            previewImage = Resources.ErrorImage;
            MaterialName = "!404";
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(previewImage, new Rectangle(0, 0, this.Width, this.Height));
        }

        private void OnEditBtnClick(object sender, EventArgs e)
        {
            MaterialEdit materialEdit = new MaterialEdit(textureCache);
            materialEdit.Material = material;
            materialEdit.TagManager = TagManager;
            materialEdit.Show();

            string file = materialCache.BaseAssetPath + material.Name;
            using (FileStream fileStream = new FileStream(file, FileMode.Truncate))
            {
                material.Save(fileStream);
            }

            materialCache.RefreshAssets();
        }

        private void OnDeleteBtnClick(object sender, EventArgs e)
        {

        }
    }
}
