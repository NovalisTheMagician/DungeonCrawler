using System;
using System.Drawing;
using System.Windows.Forms;
using Editor.Properties;
using Editor.Forms;

namespace Editor.Controls
{
    public partial class TextureItem : UserControl
    {
        private Image textureImage;
        private Texture texture;
        public Texture Texture
        {
            set
            {
                texture = value;
                textureImage = texture.TextureBitmap;
                Invalidate();
            }

            private get
            {
                return texture;
            }
        }

        public TagManager TagManager { get; set; }

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
            
            textureImage = Resources.ErrorImage;
            TextureName = "Error";
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(textureImage, new Rectangle(0, 0, this.Width, this.Height));
        }

        private void OnEditBtnClick(object sender, EventArgs e)
        {
            TextureEdit textureEdit = new TextureEdit();
            textureEdit.Texture = texture;
            textureEdit.TagManager = TagManager;
            textureEdit.Show();
        }

        private void OnDeleteBtnClick(object sender, EventArgs e)
        {

        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            DoDragDrop(Texture, DragDropEffects.Link);
        }
    }
}
