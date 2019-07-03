using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace Editor.Controls
{
    public partial class ThreeDView : Control
    {
        public Vector3 CameraPosition { get; set; }


        public Vector3 CameraDirection { get; set; }


        public float Fov { get; set; }

        private int bufferId;

        public ThreeDView()
        {
            InitializeComponent();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            bufferId = Interop.RendererInterop.AttachRenderbuffer(Handle);
            if(bufferId < 0)
            {
                MessageBox.Show("Couldn't attach Control to Dx");
                Application.Exit();
            }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);


        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;

            Draw3D();
            Draw2D(g);
        }

        private void Draw3D()
        {

        }

        private void Draw2D(Graphics g)
        {

        }
    }
}
