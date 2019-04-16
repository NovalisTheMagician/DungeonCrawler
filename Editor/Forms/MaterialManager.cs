using Editor.Controls;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor.Forms
{
    public partial class MaterialManager : Form
    {
        public MaterialView MaterialView { get; set; }

        public MaterialManager()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            contentPanel.Controls.Add(MaterialView);
            UpdateNumberOfMaterials();
        }

        private void OnImportBtnClick(object sender, EventArgs e)
        {
            using (CommonOpenFileDialog openFileDialog = new CommonOpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                openFileDialog.Filters.Add(new CommonFileDialogFilter("Material Files", "*.mat"));
                openFileDialog.Filters.Add(new CommonFileDialogFilter("All Files", "*.*"));
                openFileDialog.RestoreDirectory = true;

                CommonFileDialogResult result = openFileDialog.ShowDialog(this.Handle);
                if (result == CommonFileDialogResult.Ok)
                {
                    IEnumerable<string> files = openFileDialog.FileNames;
                    foreach (string file in files)
                    {
                        string name = Path.GetFileName(file);
                        string destination = MaterialView.MaterialCache.BaseAssetPath + name;

                        if (!File.Exists(destination))
                        {
                            File.Copy(file, destination);
                        }
                        else
                        {
                            MessageBox.Show($"'{destination}' already exists in the Project", "Image not imported", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    MaterialView.ReloadMaterials();
                    UpdateNumberOfMaterials();
                }
            }
        }

        private void OnNewBtnClick(object sender, EventArgs e)
        {
            using (InputBox inputBox = new InputBox())
            {
                inputBox.Caption = "New Material";
                inputBox.InputLabel = "Materialname";
                DialogResult dialogResult = inputBox.ShowDialog();
                if(dialogResult == DialogResult.OK)
                {
                    string name = inputBox.Input;

                    string path = MaterialView.MaterialCache.BaseAssetPath + name + ".mat";

                    if(File.Exists(path))
                    {
                        MessageBox.Show($"Material {name} already exists", "Couldn't create Material", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Material material = new Material();
                    using (FileStream fileStream = new FileStream(path, FileMode.CreateNew))
                    {
                        material.Save(fileStream);
                    }

                    MaterialView.ReloadMaterials();
                    UpdateNumberOfMaterials();
                }
            }
        }

        private void OnRefreshBtnClick(object sender, EventArgs e)
        {
            MaterialView.RefreshMaterials();
            UpdateNumberOfMaterials();
        }

        private void OnReloadBtnClick(object sender, EventArgs e)
        {
            MaterialView.ReloadMaterials();
            UpdateNumberOfMaterials();
        }

        private void OnCloseBtnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            contentPanel.Controls.Remove(MaterialView);
        }

        private void UpdateNumberOfMaterials()
        {
            int numMaterials = MaterialView.MaterialCache.Assets.Count;
            numberOfMaterialsLbl.Text = numMaterials.ToString();
        }
    }
}
