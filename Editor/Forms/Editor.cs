using Editor.Controls;
using Editor.Interop;
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
    public partial class EditorForm : Form
    {
        private TagManager tagManager;
        
        private TextureView textureView;
        private MaterialView materialView;

        private TextureManager textureManager;
        private MaterialManager materialManager;

        private AssetCache<Texture> textureCache;
        private AssetCache<Material> materialCache;

        private bool isDirty;
        private string currentLevelName;
        private string currentProjectPath;

        public EditorForm()
        {
            InitializeComponent();
        }

        #region MenuHandlers

        #region FileMenu

        private void OnNewProjectBtnClick(object sender, EventArgs e)
        {
            if (!CheckLevelState())
            {
                return;
            }

            OpenProject(true);
        }

        private void OnOpenProjectBtnClick(object sender, EventArgs e)
        {
            if (!CheckLevelState())
            {
                return;
            }

            OpenProject(false);
        }

        private void OnCloneProjectBtnClick(object sender, EventArgs e)
        {
            if (!CheckLevelState())
            {
                return;
            }

            CloneProject();
        }

        private void OnNewBtnClick(object sender, EventArgs e)
        {
            if (!CheckLevelState())
            {
                return;
            }

            NewLevel();
        }

        private void OnOpenBtnClick(object sender, EventArgs e)
        {
            if(!CheckLevelState())
            {
                return;
            }

            LoadLevel();
        }

        private void OnSaveBtnClick(object sender, EventArgs e)
        {
            SaveLevel(false);
        }

        private void OnSaveAsBtnClick(object sender, EventArgs e)
        {
            SaveLevel(true);
        }

        private void OnQuitBtnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region GitMenu

        private void OnPullBtnClick(object sender, EventArgs e)
        {

        }

        private void OnViewChangesBtnClick(object sender, EventArgs e)
        {

        }

        private void OnCommitBtnClick(object sender, EventArgs e)
        {

        }

        private void OnPushBtnClick(object sender, EventArgs e)
        {

        }

        private void OnSetupBtnClick(object sender, EventArgs e)
        {

        }

        #endregion

        #region ExportMenu



        #endregion

        #region AssetMenu

        private void OnTextureManagerBtnClick(object sender, EventArgs e)
        {
            if (textureManager == null || !textureManager.IsHandleCreated)
            {
                textureManager = new TextureManager();
                textureManager.TextureView = textureView;
                textureManager.Show();
            }
            else
            {
                textureManager.BringToFront();
            }
        }

        private void OnModelManagerBtnClick(object sender, EventArgs e)
        {

        }

        private void OnMaterialManagerBtnClick(object sender, EventArgs e)
        {
            if (materialManager == null || !materialManager.IsHandleCreated)
            {
                materialManager = new MaterialManager();
                materialManager.MaterialView = materialView;
                materialManager.Show();
            }
            else
            {
                materialManager.BringToFront();
            }
        }

        #endregion

        #region TagsMenu

        private void OnTagsBtnClick(object sender, EventArgs e)
        {
            TagsForm tagsForm = new TagsForm();
            tagsForm.ShowDialog();
        }

        #endregion

        #region ToolsMenu



        #endregion

        #region ViewMenu

        private void OnStandardViewBtnClick(object sender, EventArgs e)
        {
            Interop.RendererInterop.Initialize();
        }

        private void OnTexturingViewBtnClick(object sender, EventArgs e)
        {

        }

        #endregion

        #region HelpMenu
    
        private void OnSettingsBtnClick(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        private void OnAboutBtnClick(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        #endregion

        #endregion

        #region ToolbarHandler



        #endregion

        #region WindowEventsHandler

        private void OnEditorLoading(object sender, EventArgs e)
        {
            RendererInterop.Initialize();

            tagManager = new TagManager();

            textureCache = new AssetCache<Texture>();
            textureCache.BaseAssetPath = @"Assets\Textures\";

            materialCache = new AssetCache<Material>();
            materialCache.BaseAssetPath = @"Assets\Materials\";

            textureView = new TextureView();
            textureView.TextureCache = textureCache;
            textureView.TagManager = tagManager;

            materialView = new MaterialView(textureCache);
            materialView.MaterialCache = materialCache;
            materialView.TagManager = tagManager;

            isDirty = false;
            currentLevelName = "";
            currentProjectPath = "";

            DisableMenus();
        }

        private void OnEditorClosed(object sender, FormClosedEventArgs e)
        {
            RendererInterop.Dispose();
            tagManager.SaveTags();
        }

        private void OnEditorClosing(object sender, FormClosingEventArgs e)
        {
            bool immediateClose = e.CloseReason == CloseReason.WindowsShutDown || e.CloseReason == CloseReason.TaskManagerClosing;
            if (isDirty && !immediateClose)
            {
                DialogResult result = MessageBox.Show("Save now?", "Unsaved changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if(result == DialogResult.Yes)
                {
                    SaveLevel(false);
                }
                else if(result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        #endregion

        private void OpenProject(bool createNew)
        {
            if(createNew)
            {

            }
            else
            {
                CommonOpenFileDialog commonOpenFileDialog = new CommonOpenFileDialog();
                commonOpenFileDialog.IsFolderPicker = true;
                //commonOpenFileDialog.RestoreDirectory = true;
                commonOpenFileDialog.Multiselect = false;
                CommonFileDialogResult result = commonOpenFileDialog.ShowDialog();
                if (result == CommonFileDialogResult.Ok)
                {
                    string folder = commonOpenFileDialog.FileName;
                }
            }

            EnableMenus();
        }

        private void CloneProject()
        {
            EnableMenus();
        }

        private void NewLevel()
        {

        }

        private void LoadLevel()
        {
            CommonOpenFileDialog openFileDialog = new CommonOpenFileDialog();
            openFileDialog.EnsureFileExists = true;
            openFileDialog.DefaultExtension = ".lvl";
            openFileDialog.Filters.Add(new CommonFileDialogFilter("Level Files", "*.lvl"));
            openFileDialog.Filters.Add(new CommonFileDialogFilter("All Files", "*.*"));
            openFileDialog.InitialDirectory = currentProjectPath + "Levels/";
            openFileDialog.Multiselect = false;
            //openFileDialog.RestoreDirectory = true;

            CommonFileDialogResult result = openFileDialog.ShowDialog();
            if(result == CommonFileDialogResult.Ok)
            {
                string fileName = openFileDialog.FileName;

            }
        }

        private bool SaveLevel(bool forceSaveDialog)
        {
            if(forceSaveDialog || currentLevelName == string.Empty)
            {
                CommonSaveFileDialog saveFileDialog = new CommonSaveFileDialog();
                saveFileDialog.EnsurePathExists = true;
                saveFileDialog.DefaultExtension = ".lvl";
                saveFileDialog.InitialDirectory = currentProjectPath + "Levels/";
                saveFileDialog.Filters.Add(new CommonFileDialogFilter("Level Files", "*.lvl"));
                saveFileDialog.RestoreDirectory = true;

                CommonFileDialogResult result = saveFileDialog.ShowDialog();
                if (result == CommonFileDialogResult.Cancel)
                {
                    return false;
                }
                else if(result == CommonFileDialogResult.Ok)
                {
                    string fileName = saveFileDialog.FileName;
                    //currentLevelName = ;
                }
            }

            //save the level

            isDirty = false;
            return true;
        }

        private bool CheckLevelState()
        {
            if (isDirty)
            {
                if (!SaveLevel(false))
                {
                    return false;
                }
            }

            return true;
        }

        private void DisableMenus()
        {
            gitMenu.Enabled = false;
            exportMenu.Enabled = false;
            assetMenu.Enabled = false;
            tagsBtn.Enabled = false;
            toolsMenu.Enabled = false;
            viewMenu.Enabled = false;

            newBtn.Enabled = false;
            openBtn.Enabled = false;
            saveBtn.Enabled = false;
            saveAsBtn.Enabled = false;
        }

        private void EnableMenus()
        {
            gitMenu.Enabled = true;
            exportMenu.Enabled = true;
            assetMenu.Enabled = true;
            tagsBtn.Enabled = true;
            toolsMenu.Enabled = true;
            viewMenu.Enabled = true;

            newBtn.Enabled = true;
            openBtn.Enabled = true;
            saveBtn.Enabled = true;
            saveAsBtn.Enabled = true;
        }
    }
}
