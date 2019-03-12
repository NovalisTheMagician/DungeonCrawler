using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor.Controls
{
    public enum Orientation
    {
        TOP,
        FRONT,
        SIDE
    }

    public partial class TwoDView : Control
    {
        public Orientation Orientation { get; set; }

        public TwoDView()
        {
            InitializeComponent();
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
