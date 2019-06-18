using System;
using System.Windows.Forms;

namespace Editor.Forms
{
    public partial class AssetManager : Form
    {
        public AssetCache AssetCache { get; set; }

        public AssetManager()
        {
            InitializeComponent();
        }

        private void UpdateList(object sender, EventArgs e)
        {

        }
    }
}
