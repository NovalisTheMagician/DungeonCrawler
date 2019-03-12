using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor.Controls
{
    public partial class Layout6Pane : UserControl
    {
        public TextureView TextureView
        {
            get
            {
                return textureView;
            }
        }

        public Layout6Pane()
        {
            InitializeComponent();
        }
    }
}
