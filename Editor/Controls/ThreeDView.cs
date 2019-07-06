using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

using D3DRenderer = Editor.Renderer.Renderer;

namespace Editor.Controls
{
    public partial class ThreeDView : Control
    {
        private D3DRenderer renderer;
        public D3DRenderer Renderer
        {
            get { return renderer; }
            set
            {
                renderer = value;
                OnRendererSet();
            }
        }

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
        }

        private void OnRendererSet()
        {
            bufferId = Renderer.AttachWindow(Handle);
            if (bufferId < 0)
            {
                MessageBox.Show("Couldn't attach Control to Dx");
            }
            Renderer.Resize(bufferId, Width, Height);
            Invalidate();
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);

            Renderer?.DetachWindow(bufferId);
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
            Renderer?.Resize(bufferId, Width, Height);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;

            Renderer?.BeginDraw(bufferId);
            Draw3D();
            Renderer?.EndDraw(bufferId);

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
