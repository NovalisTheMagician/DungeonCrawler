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
        [Browsable(false)]
        public int GridSize
        {
            get { return twoDView1.GridSize; }
            set
            {
                twoDView1.GridSize = value; twoDView1.Invalidate();
                twoDView2.GridSize = value; twoDView2.Invalidate();
                twoDView3.GridSize = value; twoDView3.Invalidate();
            }
        }

        [Browsable(false)]
        public int AltGridSize
        {
            get { return twoDView1.AltGridSize; }
            set
            {
                twoDView1.AltGridSize = value;
                twoDView2.AltGridSize = value;
                twoDView3.AltGridSize = value;
            }
        }

        public ThreeDView ThreeDView { get { return threeDView1; } }

        public Layout6Pane()
        {
            InitializeComponent();
        }
    }
}
