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
    public partial class EditorForm : Form
    {
        private AssetWatcher assetWatcher;
        private TextureManager textureManager;

        private bool isDirty = false;

        public EditorForm()
        {
            InitializeComponent();

            //textureCache = new TextureCache(@"Assets\Textures");
            assetWatcher = new AssetWatcher(this);
            assetWatcher.AssetRoot = @"Assets";

            textureManager = new TextureManager();
            textureManager.BaseTexturePath = @"Assets/Textures";
        }

        #region MenuHandlers

        #region FileMenu

        private void newBtnClick(object sender, EventArgs e)
        {
            
        }

        private void openBtnClick(object sender, EventArgs e)
        {
            
        }

        private void saveBtnClick(object sender, EventArgs e)
        {
            
        }

        private void saveAsBtnClick(object sender, EventArgs e)
        {
            
        }

        private void quitBtnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region GitMenu

        private void pullBtnClick(object sender, EventArgs e)
        {

        }

        private void viewChangesBtnClick(object sender, EventArgs e)
        {

        }

        private void commitBtnClick(object sender, EventArgs e)
        {

        }

        private void pushBtnClick(object sender, EventArgs e)
        {

        }

        private void setupBtnClick(object sender, EventArgs e)
        {

        }

        #endregion

        #region ExportMenu



        #endregion

        #region AssetMenu

        private void textureManagerBtnClick(object sender, EventArgs e)
        {
            textureManager.Show();
        }

        private void modelManagerBtnClick(object sender, EventArgs e)
        {

        }

        private void materialManagerBtnClick(object sender, EventArgs e)
        {

        }

        #endregion

        #region ToolsMenu



        #endregion

        #region ViewMenu

        private void standardViewBtnClick(object sender, EventArgs e)
        {
            RendererInterop.Initialize();
        }

        private void texturingViewBtnClick(object sender, EventArgs e)
        {

        }

        #endregion

        #region HelpMenu
    
        private void settingsBtnClick(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        #endregion

        #endregion

        #region ToolbarHandler



        #endregion

        #region WindowEventsHandler

        private void editorClosing(object sender, FormClosingEventArgs e)
        {

        }

        #endregion
    }
}
