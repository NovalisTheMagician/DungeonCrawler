using Editor.Controls;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Editor.Forms
{
    public partial class TextureManager : Form
    {

        public TextureView TextureView { get; set; }

        public TextureManager()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            contentPanel.Controls.Add(TextureView);
            UpdateNumberOfTextures();
        }

        private void OnTextureClick(object sender, EventArgs e)
        {

        }

        private void OnImportBtnClick(object sender, EventArgs e)
        {
            CommonOpenFileDialog openFileDialog = new CommonOpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filters.Add(new CommonFileDialogFilter("Image Files", "*.bmp, *.png, *.tga"));
            openFileDialog.Filters.Add(new CommonFileDialogFilter("All Files", "*.*"));
            openFileDialog.RestoreDirectory = true;

            CommonFileDialogResult result = openFileDialog.ShowDialog(this.Handle);
            if(result == CommonFileDialogResult.Ok)
            {
                IEnumerable<string> files = openFileDialog.FileNames;
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
            contentPanel.Controls.Remove(TextureView);
        }

        private void UpdateNumberOfTextures()
        {
            int numTextures = TextureView.TextureCache.Assets.Count;
            numberOfTexturesLbl.Text = numTextures.ToString();
        }
    }
}
