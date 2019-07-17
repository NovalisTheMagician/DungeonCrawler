using Editor.Renderer;
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
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            mouseLooking = false;
            Fov = 90.0f;
            CameraPosition = new Vector3(32, 32, 32);
            CameraDirection = Vector3.Normalize(Vector3.Zero - CameraPosition);
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
                mouseStart = e.Location;
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                if(mouseLooking)
                {
                    mouseLooking = false;
                }
            }

            base.OnMouseUp(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if(mouseLooking)
            {
                Point currMousePos = e.Location;
                int dx = currMousePos.X - mouseStart.X;
                int dy = currMousePos.Y - mouseStart.Y;
                mouseStart = currMousePos;
            }

            base.OnMouseMove(e);
            Invalidate();
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
            if(!Enabled)
            {
                pe.Graphics.Clear(Color.LightGray);
                return;
            }

            if(DesignMode)
            {
                pe.Graphics.Clear(Color.CornflowerBlue);
            }

            if (Renderer == null) return;

            view = Matrix4x4.CreateLookAt(CameraPosition, CameraPosition + CameraDirection, Vector3.UnitY);
            projection = Matrix4x4.CreatePerspectiveFieldOfView(Fov.ToRadians(), (float)Width / Height, 0.1f, 100.0f);

            Renderer.BeginDraw(bufferId, view, projection, DXColor.Green);
            Draw3D();

            GDIDevice device = new GDIDevice();

            if (renderer.GetGDIDevice(bufferId, ref device))
            {
                Draw2D(device.Graphics);
                renderer.ReleaseGDIDevice(ref device);
            }
            
            Renderer.EndDraw(bufferId);
        }

        protected override void OnPaintBackground(PaintEventArgs pe)
        {
            if(DesignMode)
            {
                pe.Graphics.Clear(Color.CornflowerBlue);
            }
        }

        private void Draw3D()
        {

        }

        private void Draw2D(Graphics g)
        {
            g.FillRectangle(Brushes.CornflowerBlue, new Rectangle(100, 100, 100, 200));
            Font font = new Font(FontFamily.GenericMonospace, 8, FontStyle.Regular);
            TextRenderer.DrawText(g, "Test", font, new Point(10, 10), Color.AntiqueWhite);
        }
    }
}
