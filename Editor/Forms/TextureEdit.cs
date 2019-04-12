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
    public partial class TextureEdit : Form
    {
        private Texture texture;
        public Texture Texture
        {
            set
            {
                texture = value;
                imagePanel.Width = texture.Width;
                imagePanel.Height = texture.Height;
                imagePanel.Update();
            }
        }

        public TagManager TagManager { get; set; }

        public TextureEdit()
        {
            InitializeComponent();
            texture = null;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            tagList.Items.Clear();

            foreach (Tag tag in TagManager.Tags)
            {
                if (!tag.IsValid())
                    continue;

                bool hasTag = texture.Tags.HasTag(tag);
                tagList.Items.Add(tag.Name, hasTag);
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            float dpiX = g.DpiX / 96.0f;
            float dpiY = g.DpiY / 96.0f;

            imagePanel.Width = (int)(texture.Width * dpiX);
            imagePanel.Height = (int)(texture.Height * dpiY);

            g.DrawImage(texture.TextureBitmap, new Point(0, 0));
        }

        private void OnOKBtnClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
