using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor
{
    public partial class TextureManager : Form
    {
        private class TexturePanel : Panel
        {
            public Image Texture { get; set; }

            private const int PANEL_WIDTH = 256;
            private const int PANEL_HEIGHT = 256;

            private Font nameFont;
            public string TextureName { private get; set; }

            public TexturePanel()
            {
                this.Paint += OnPaint;
                this.Size = new Size(256, 256);

                Texture = null;

                nameFont = new Font(FontFamily.GenericMonospace, 12);
                
                TextureName = "Default";
            }

            private void OnPaint(object sender, PaintEventArgs e)
            {
                Brush textBrush = new SolidBrush(Color.DarkBlue);
                Brush backgroundBrush = new SolidBrush(Color.White);

                Graphics g = e.Graphics;

                SizeF textSize = g.MeasureString(TextureName, nameFont);
                PointF textLocation = new PointF((PANEL_WIDTH / 2) - (textSize.Width / 2), PANEL_HEIGHT - (textSize.Height + 16));

                g.DrawImage(Texture, new Rectangle(0, 0, this.Size.Width, this.Size.Height));
                g.FillRectangle(backgroundBrush, new RectangleF(textLocation, textSize));
                g.DrawString(TextureName, nameFont, textBrush, textLocation);
            }
        }

        private string baseTexturePath;
        public string BaseTexturePath
        {
            get { return baseTexturePath; }
            set { baseTexturePath = value; ReloadTextures(); }
        }

        private Dictionary<string, TexturePanel> textureMap;

        public TextureManager()
        {
            InitializeComponent();

            textureMap = new Dictionary<string, TexturePanel>();
        }

        private void OnTextureClick(object sender, EventArgs e)
        {

        }

        private void RefreshTextures()
        {
            foreach(var texmap in textureMap)
            {
                string file = texmap.Key;
                TexturePanel texpan = texmap.Value;

                if(!File.Exists(file))
                {
                    texpan.Texture.Dispose();
                    texturePanel.Controls.Remove(texpan);
                    textureMap.Remove(file);
                }
                else
                {
                    // optimize here to only load the images which have been changed since last loaded
                    // (check file last modified date and store the date somewhere)
                    Image texture = Image.FromFile(file);
                    textureMap[file].Texture = new Bitmap(texture);
                    texture.Dispose();
                    textureMap[file].Invalidate();
                }
            }
        }

        private void ReloadTextures()
        {
            foreach(TexturePanel texpan in textureMap.Values)
            {
                texpan.Texture.Dispose();
            }
            textureMap.Clear();

            texturePanel.Controls.Clear();

            string[] files = Directory.GetFiles(baseTexturePath);
            foreach(string file in files)
            {
                if(IsRightExtension(file))
                {
                    TexturePanel texpan = CreateTexturePanel(file);
                    textureMap.Add(file, texpan);
                    texturePanel.Controls.Add(texpan);
                }
            }
        }

        private TexturePanel CreateTexturePanel(string file)
        {
            TexturePanel texpan = new TexturePanel();
            texpan.TextureName = GetName(file);

            Image texture = Image.FromFile(file);
            texpan.Texture = new Bitmap(texture);
            texture.Dispose();

            texpan.DoubleClick += OnTextureClick;

            return texpan;
        }

        private bool IsRightExtension(string path)
        {
            return Regex.IsMatch(GetExtension(path), @"\.bmp|\.png|\.tga");
        }

        private string GetExtension(string path)
        {
            return (Path.GetExtension(path) ?? "").ToLower();
        }

        private string GetName(string path)
        {
            return Path.GetFileNameWithoutExtension(path);
        }

        private void OnImportBtnClick(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Image files (*.bmp, *.png, *.tga)|*.bmp;*.png;*.tga|All files (*.*)|*.*";

            DialogResult result = openFileDialog.ShowDialog();
            if(result == DialogResult.OK)
            {

            }
        }

        private void OnReloadBtnClick(object sender, EventArgs e)
        {
            ReloadTextures();
        }

        private void OnRefreshBtnClick(object sender, EventArgs e)
        {
            RefreshTextures();
        }

        private void OnCloseButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                this.Hide();
                e.Cancel = true;
            }
        }
    }
}
