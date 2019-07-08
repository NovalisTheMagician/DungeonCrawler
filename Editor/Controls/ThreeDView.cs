using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

using D3DRenderer = Editor.Renderer.Renderer;

using DXColor = SharpDX.Color;

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

        private Matrix4x4 view, projection;

        private int bufferId;

        private bool mouseLooking;
        private Point mouseStart;

        public ThreeDView()
        {
            InitializeComponent();
            //DoubleBuffered = true;

            mouseLooking = false;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
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
            if(e.Button == MouseButtons.Right && !mouseLooking)
            {
                mouseLooking = true;

            }

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
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;

            view = Matrix4x4.CreateLookAt(CameraPosition, CameraPosition + CameraDirection, Vector3.UnitY);
            projection = Matrix4x4.CreatePerspectiveFieldOfView(Fov, (float)Width / Height, 0.1f, 100.0f);

            Renderer?.BeginDraw(bufferId, view, projection, DXColor.Black);
            Draw3D();
            Renderer?.EndDraw(bufferId);

            Draw2D(g);
        }

        private void Draw3D()
        {

        }

        private void Draw2D(Graphics g)
        {
            g.DrawString("Test", new Font(FontFamily.GenericMonospace, 8, FontStyle.Regular), Brushes.AntiqueWhite, new PointF(10, 10));
        }
    }
}
