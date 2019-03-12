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
    public partial class TextureItem : UserControl
    {
        private Image texture;
        public Image Texture
        {
            set
            {
                texture = new Bitmap(value);
                Invalidate();
            }
        }

        public string TextureName
        {
            set
            {
                textureLabel.Text = value;
            }
        }

        public TextureItem()
        {
            InitializeComponent();
            
            Texture = Resources.ErrorImage;
            TextureName = "Error";
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(texture, new Rectangle(0, 0, this.Width, this.Height));
        }
    }
}
