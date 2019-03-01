using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor
{
    public partial class EditorForm : Form
    {
        private bool isDirty = false;

        public EditorForm()
        {
            InitializeComponent();
        }

        private void standardViewBtnClick(object sender, EventArgs e)
        {
            RendererInterop.Initialize();
        }

        private void texturingViewBtnClick(object sender, EventArgs e)
        {

        }

        private void settingsBtnClick(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        private void quitBtnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editorClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
