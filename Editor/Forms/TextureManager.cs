using Editor.Controls;
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

namespace Editor.Forms
{
    public partial class TextureManager : Form
    {
        public TextureView TextureView
        {
            get
            {
                return textureView;
            }
        }

        public TextureManager(TextureCache textureCache)
        {
            InitializeComponent();
            textureView.TextureCache = textureCache;
        }

        private void OnTextureClick(object sender, EventArgs e)
        {

        }

        private void OnImportBtnClick(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Image files (*.bmp, *.png, *.tga)|*.bmp;*.png;*.tga|All files (*.*)|*.*";

            DialogResult result = openFileDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                string[] files = openFileDialog.FileNames;
                foreach(string file in files)
                {
                    string name = Path.GetFileName(file);
                    string destination = textureView.TextureCache.BaseTexturePath + @"\" + name;

                    if (!File.Exists(destination))
                    {
                        File.Copy(file, destination);
                    }
                    else
                    {
                        MessageBox.Show($"'{destination}' already exists in the Project", "Image not imported", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                textureView.ReloadTextures();
            }
        }

        private void OnReloadBtnClick(object sender, EventArgs e)
        {
            textureView.ReloadTextures();
        }

        private void OnRefreshBtnClick(object sender, EventArgs e)
        {
            textureView.RefreshTextures();
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
