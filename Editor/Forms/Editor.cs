using Editor.Controls;
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
        private TextureManager textureManager;
        private AssetCache<Texture> textureCache;
        private TextureView textureView;

        private bool isDirty = false;

        public EditorForm()
        {
            InitializeComponent();
        }

        #region MenuHandlers

        #region FileMenu

        private void OnNewBtnClick(object sender, EventArgs e)
        {
            
        }

        private void OnOpenBtnClick(object sender, EventArgs e)
        {
            
        }

        private void OnSaveBtnClick(object sender, EventArgs e)
        {
            
        }

        private void OnSaveAsBtnClick(object sender, EventArgs e)
        {
            
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
            textureManager.Show();
        }

        private void OnModelManagerBtnClick(object sender, EventArgs e)
        {

        }

        private void OnMaterialManagerBtnClick(object sender, EventArgs e)
        {

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

        #endregion

        #endregion

        #region ToolbarHandler



        #endregion

        #region WindowEventsHandler

        private void OnEditorLoading(object sender, EventArgs e)
        {
            Interop.RendererInterop.Initialize();

            textureCache = new AssetCache<Texture>();
            textureCache.BaseAssetPath = @"Assets\Textures";

            textureView = new TextureView();
            textureView.TextureCache = textureCache;

            textureManager = new TextureManager(textureView);

            using (FileStream fs = new FileStream("Assets/Textures/grid.png", FileMode.Open))
            {
                Texture tex = new Texture();
                tex.Construct(fs);
                Interop.RendererInterop.RenderTexture(1, tex);
                tex.Dispose();
            }
        }

        private void OnEditorClosed(object sender, FormClosedEventArgs e)
        {
            Interop.RendererInterop.Dispose();
        }

        private void OnEditorClosing(object sender, FormClosingEventArgs e)
        {

        }

        #endregion
    }
}
