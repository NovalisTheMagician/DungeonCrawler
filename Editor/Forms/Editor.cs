using Editor.Controls;
using Editor.Interop;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Text.Json.Serialization;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using D3DRenderer = Editor.Renderer.Renderer;

namespace Editor.Forms
{
    public partial class EditorForm : Form
    {
        private AssetCache assetCache;

        private ProjectSettings projectSettings;
        private EditorSettings editorSettings;

        private D3DRenderer renderer;

        private bool isDirty;
        private string currentLevelName;
        private string currentProjectPath;

        private MouseWheelFilter mouseWheelFilter;

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

        private void OnAssetManagerBtnClick(object sender, EventArgs e)
        {
            AssetManager assetManager = new AssetManager(assetCache);
            assetManager.Show();
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
            using (SettingsForm settingsForm = new SettingsForm())
            {
                settingsForm.ShowDialog();
            }
        }

        private void OnAboutBtnClick(object sender, EventArgs e)
        {
            using (AboutBox aboutBox = new AboutBox())
            {
                aboutBox.ShowDialog();
            }
        }

        #endregion

        #endregion

        #region ToolbarHandlers



        #endregion

        #region WindowEventHandlers

        private void OnEditorLoading(object sender, EventArgs e)
        {
            mouseWheelFilter = new MouseWheelFilter();
            Application.AddMessageFilter(mouseWheelFilter);

            renderer = new D3DRenderer();
            if(!renderer.Initialize())
            {
                MessageBox.Show("Something went wrong during Initialization of the 3D View! Exiting now...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            layout6Pane.ThreeDView.Renderer = renderer;
            
            assetCache = new AssetCache();

            assetCache.RegisterLoader(new TextureLoader());
            assetCache.RegisterLoader(new MaterialLoader());

            isDirty = false;
            currentLevelName = "";
            currentProjectPath = "";

            DisableMenus();
        }

        private void OnEditorClosed(object sender, FormClosedEventArgs e)
        {
            renderer.Destroy();
            assetCache.SaveAssets();
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
                    return;
                }
            }
            assetCache.ClearAll();
            Application.RemoveMessageFilter(mouseWheelFilter);
        }

        #endregion

        private void OnGridBtnClick(object sender, EventArgs e)
        {
            ToolStripMenuItem btn = sender as ToolStripMenuItem;
            int gridSize = int.Parse((string)btn.Tag);
            gridBtn.Text = $"{gridSize}";
            layout6Pane.GridSize = gridSize;
        }

        private void CreateFolderHierarchy(string projectFolder)
        {
            Directory.CreateDirectory(projectFolder + "/cache/");
            Directory.CreateDirectory(projectFolder + "/assets/");
            Directory.CreateDirectory(projectFolder + "/assets/textures/");
            Directory.CreateDirectory(projectFolder + "/assets/materials/");
            Directory.CreateDirectory(projectFolder + "/assets/models/");
            Directory.CreateDirectory(projectFolder + "/assets/sounds/");
            Directory.CreateDirectory(projectFolder + "/assets/music/");
            Directory.CreateDirectory(projectFolder + "/levels/");
        }

        private void OpenProject(bool createNew)
        {
            using (CommonOpenFileDialog commonOpenFileDialog = new CommonOpenFileDialog())
            {
                commonOpenFileDialog.IsFolderPicker = true;
                commonOpenFileDialog.Multiselect = false;
                CommonFileDialogResult result = commonOpenFileDialog.ShowDialog();
                if (result == CommonFileDialogResult.Ok)
                {
                    string folder = commonOpenFileDialog.FileName;

                    bool folderEmpty = Directory.EnumerateFiles(folder).Count() == 0;
                    folderEmpty = folderEmpty &&  (Directory.EnumerateDirectories(folder).Count() == 0);
                    
                    if (createNew)
                    {
                        if(!folderEmpty)
                        {
                            MessageBox.Show("Specified Folder is not Empty!", "Couldn't create new Project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        CreateFolderHierarchy(folder);

                        projectSettings = new ProjectSettings();
                        projectSettings.Name = Path.GetFileNameWithoutExtension(folder);
                        projectSettings.Version = 1;
                        projectSettings.LastUpdated = DateTime.Now;

                        JsonSerializerOptions options = new JsonSerializerOptions
                        {
                            WriteIndented = true
                        };

                        string serializedSettings = JsonSerializer.ToString<ProjectSettings>(projectSettings, options);
                        File.WriteAllText(folder + "/settings.json", serializedSettings);
                    }
                    else
                    {
                        if(!File.Exists(folder + "/settings.json"))
                        {
                            MessageBox.Show("Specified Folder is not a valid Project", "Couldn't open Project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string serilizedSettings = File.ReadAllText(folder + "/settings.json");
                        projectSettings = JsonSerializer.Parse<ProjectSettings>(serilizedSettings);
                    }
                    currentProjectPath = $"{folder}/";
                    assetCache.AssetPath = $"{currentProjectPath}assets/";
                    assetCache.ReloadAll();
                    EnableMenus();
                }
            }
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
            using (CommonOpenFileDialog openFileDialog = new CommonOpenFileDialog())
            {
                openFileDialog.EnsureFileExists = true;
                openFileDialog.DefaultExtension = ".lvl";
                openFileDialog.Filters.Add(new CommonFileDialogFilter("Level Files", "*.lvl"));
                openFileDialog.Filters.Add(new CommonFileDialogFilter("All Files", "*.*"));
                openFileDialog.InitialDirectory = currentProjectPath + "Levels/";
                openFileDialog.Multiselect = false;
                //openFileDialog.RestoreDirectory = true;

                CommonFileDialogResult result = openFileDialog.ShowDialog();
                if (result == CommonFileDialogResult.Ok)
                {
                    string fileName = openFileDialog.FileName;

                }
            }
        }

        private bool SaveLevel(bool forceSaveDialog)
        {
            if(forceSaveDialog || currentLevelName == string.Empty)
            {
                using (CommonSaveFileDialog saveFileDialog = new CommonSaveFileDialog())
                {
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
                    else if (result == CommonFileDialogResult.Ok)
                    {
                        string fileName = saveFileDialog.FileName;
                        //currentLevelName = ;
                    }
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
            toolsMenu.Enabled = true;
            viewMenu.Enabled = true;

            newBtn.Enabled = true;
            openBtn.Enabled = true;
            saveBtn.Enabled = true;
            saveAsBtn.Enabled = true;
        }
    }
}
