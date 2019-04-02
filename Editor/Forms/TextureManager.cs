using Editor.Controls;
using System;
using System.IO;
using System.Windows.Forms;

namespace Editor.Forms
{
    public partial class TextureManager : Form
    {
        public TextureView TextureView { get; private set; }

        public TextureManager(TextureView textureView)
        {
            InitializeComponent();

            TextureView = textureView;

            contentPanel.Controls.Add(TextureView);
            UpdateNumberOfTextures();
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
                    string destination = TextureView.TextureCache.BaseAssetPath + @"\" + name;

                    if (!File.Exists(destination))
                    {
                        File.Copy(file, destination);
                    }
                    else
                    {
                        MessageBox.Show($"'{destination}' already exists in the Project", "Image not imported", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                TextureView.ReloadTextures();
                UpdateNumberOfTextures();
            }
        }

        private void OnReloadBtnClick(object sender, EventArgs e)
        {
            TextureView.ReloadTextures();
            UpdateNumberOfTextures();
        }

        private void OnRefreshBtnClick(object sender, EventArgs e)
        {
            TextureView.RefreshTextures();
            UpdateNumberOfTextures();
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

        private void UpdateNumberOfTextures()
        {
            int numTextures = TextureView.TextureCache.Assets.Count;
            numberOfTexturesLbl.Text = numTextures.ToString();
        }
    }
}
