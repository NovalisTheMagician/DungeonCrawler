using Editor.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor.Forms
{
    public partial class MaterialEdit : Form
    {
        private Material material;
        public Material Material
        {
            set
            {
                material = value;
                if(material != null)
                {
                    Invalidate();
                }
            }
        }

        public TagManager TagManager { get; set; }

        private AssetCache<Texture> textureCache;

        public MaterialEdit(AssetCache<Texture> textureCache)
        {
            InitializeComponent();

            this.textureCache = textureCache;
        }

        private void OnMaterialPanelPaint(object sender, PaintEventArgs e)
        {
            string texName = "";
            Image image = Resources.ErrorImage;

            Graphics g = e.Graphics;
            if(material != null)
            {
                if (sender == diffusePanel)
                {
                    texName = material.Diffuse;
                }
                else if (sender == normalPanel)
                {
                    texName = material.Normal;
                }
                else if (sender == specularPanel)
                {
                    texName = material.Specular;
                }
            }

            if(texName != string.Empty)
            {
                Texture tex = textureCache[texName];
                if (tex != null)
                {
                    image = tex.TextureBitmap;
                }
            }

            g.DrawImage(image, new Rectangle(0, 0, 256, 256));
        }

        private void OnOKBtnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnTextureDragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(typeof(Texture)))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void OnTextureDragDrop(object sender, DragEventArgs e)
        {
            Texture texture = e.Data.GetData(typeof(Texture)) as Texture;

            if(sender == diffusePanel)
            {
                material.Diffuse = texture.Name;
            }
            else if (sender == normalPanel)
            {
                material.Normal = texture.Name;
            }
            else if (sender == specularPanel)
            {
                material.Specular = texture.Name;
            }

            Refresh();
        }
    }
}
