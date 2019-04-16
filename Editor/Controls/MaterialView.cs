using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Editor.Controls
{
    public partial class MaterialView : UserControl
    {
        private AssetCache<Material> materialCache;

        [Browsable(false)]
        public AssetCache<Material> MaterialCache
        {
            get
            {
                return materialCache;
            }

            set
            {
                if (value != null)
                {
                    materialCache = value;
                    ReloadAllItems();
                }
            }
        }

        private AssetCache<Texture> textureCache;

        [Browsable(false)]
        public TagManager TagManager { get; set; }

        public MaterialView(AssetCache<Texture> textureCache)
        {
            InitializeComponent();
            this.textureCache = textureCache;
            this.Dock = DockStyle.Fill;
        }

        private void ReloadAllItems()
        {
            materialFlowPanel.Controls.Clear();

            var materialList = materialCache.AssetFiles;
            var materialMap = materialCache.Assets;

            foreach (string materialFile in materialList.OrderBy(s => s).ToList())
            {
                string name = GetName(materialFile);
                Material material = materialMap[materialFile];
                materialFlowPanel.Controls.Add(CreateMaterialItem(name, material));
            }

            materialFlowPanel.Refresh();
        }

        private MaterialItem CreateMaterialItem(string name, Material material)
        {
            MaterialItem item = new MaterialItem(textureCache, materialCache);
            item.Material = material;
            item.MaterialName = name;
            item.TagManager = TagManager;
            return item;
        }

        public void RefreshMaterials()
        {
            if (materialCache != null)
            {
                materialCache.RefreshAssets();
                ReloadAllItems();
            }
        }

        public void ReloadMaterials()
        {
            if (materialCache != null)
            {
                materialCache.ReloadAssets();
                ReloadAllItems();
            }
        }

        private string GetName(string path)
        {
            return Path.GetFileNameWithoutExtension(path);
        }

        private void RefreshBtnClick(object sender, EventArgs e)
        {
            RefreshMaterials();
        }

        private void ReloadBtnClick(object sender, EventArgs e)
        {
            ReloadMaterials();
        }

        private void OnVisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                ReloadMaterials();
            }
            else
            {
                materialFlowPanel.Controls.Clear();
            }
        }
    }
}
