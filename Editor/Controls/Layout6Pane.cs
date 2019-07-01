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

        public Layout6Pane()
        {
            InitializeComponent();

            //int width = (int)(splitContainer3.Width * 2000);
            //int height = (int)(splitContainer3.Height);

            //splitContainer3.SplitterDistance = Width / 2;
            //splitContainer4.SplitterDistance = Height / 2;
            //splitContainer5.SplitterDistance = Height / 2;
        }
    }
}
