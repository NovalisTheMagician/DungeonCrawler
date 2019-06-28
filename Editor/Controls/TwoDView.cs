using System;
using System.Drawing;
using System.Windows.Forms;
using System.Numerics;
using System.ComponentModel;

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

        [Browsable(false)]
        public float ScaleFactor
        {
            get
            {
                return Zoom / 100.0f;
            }
        }

        [Browsable(false)]
        public int Zoom { get; set; }

        [Browsable(false)]
        public Vector2 PanOffset { get; set; }

        [Browsable(false)]
        public int GridSize { get; set; }

        private bool panning;
        private Point startPanPos;

        private Font textFont;

        private Vector2 mousePosBeforeZoom;
        private Vector2 mousePosAfterZoom;

        public TwoDView()
        {
            InitializeComponent();

            BackColor = Color.DarkBlue;

            DoubleBuffered = true;

            Zoom = 100;
            PanOffset = new Vector2((-Width / 2) / ScaleFactor, (-Height / 2) / ScaleFactor);
            Orientation = Orientation.TOP;
            GridSize = 64;

            textFont = new Font(FontFamily.GenericMonospace, 8);

            panning = false;
        }

        protected override void OnCreateControl()
        {
            PanOffset = new Vector2((-Width / 2) / ScaleFactor, (-Height / 2) / ScaleFactor);
            base.OnCreateControl();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Middle && !panning)
            {
                StartPanning(e.Location);
            }
            else if(e.Button == MouseButtons.Left && Control.ModifierKeys == Keys.Control && !panning)
            {
                StartPanning(e.Location);
            }

            if(e.Button == MouseButtons.Left)
            {
                Focus();
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Middle || e.Button == MouseButtons.Left)
            {
                if (panning)
                    EndPanning();
            }

            base.OnMouseUp(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            if (Parent.Focused && !Focused) Focus();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (Focused) Parent.Focus();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            mousePosBeforeZoom = ScreenToWorld(e.Location);

            int factor = 5;
            if (Control.ModifierKeys == Keys.Shift)
                factor = 10;
            else if (Control.ModifierKeys == Keys.Control)
                factor = 1;

            Zoom += factor * Math.Sign(e.Delta);
            if (Zoom <= 1)
                Zoom = 1;
            if (Zoom >= 400)
                Zoom = 400;

            mousePosAfterZoom = ScreenToWorld(e.Location);

            PanOffset += mousePosBeforeZoom - mousePosAfterZoom;

            Invalidate();
            
            base.OnMouseWheel(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if(panning)
            {
                DoPanning(e.Location);

                Invalidate();
            }

            base.OnMouseMove(e);
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
            g.Clear(Color.DarkBlue);

            DrawStats(g);
            DrawGrid(g);
            DrawWorldAxis(g);

            base.OnPaint(pe);
        }

        private void DrawWorldAxis(Graphics g)
        {
            Point origin = WorldToScreen(Vector2.Zero);
            if (origin.X >= 0 && origin.X < Width)
                g.DrawLine(Pens.DarkGray, new Point(origin.X, 0), new Point(origin.X, Height - 1));
            if (origin.Y >= 0 && origin.Y < Height)
                g.DrawLine(Pens.DarkGray, new Point(0, origin.Y), new Point(Width - 1, origin.Y));
        }

        private void DrawStats(Graphics g)
        {
            Brush fontBrush = Brushes.GhostWhite;
            g.DrawString(Orientation.ToString(), textFont, fontBrush, new PointF(10, 10));
            g.DrawString($"Zoom: {Zoom}%", textFont, fontBrush, new PointF(10, Height - 30));
        }

        private void DrawGrid(Graphics g)
        {
            Vector2 worldTopLeft = ScreenToWorld(new Point(0, 0));
            Vector2 worldBottomRight = ScreenToWorld(new Point(Width, Height));

            worldTopLeft.X = (float)Math.Floor(worldTopLeft.X);
            worldTopLeft.Y = (float)Math.Floor(worldTopLeft.Y);
            worldBottomRight.X = (float)Math.Ceiling(worldBottomRight.X);
            worldBottomRight.Y = (float)Math.Ceiling(worldBottomRight.Y);

            using (Pen dashedLines = new Pen(Color.FromArgb(32, Color.DarkGray), 1))
            {
                for (float y = worldTopLeft.Y; y < worldBottomRight.Y; y += GridSize)
                {
                    for (float x = worldTopLeft.X; x < worldBottomRight.X; x += GridSize)
                    {
                        Point p = WorldToScreen(new Vector2(x, y));
                        g.FillRectangle(Brushes.DarkGray, p.X, p.Y, 1, 1);
                        //g.DrawLine(dashedLines, p, p);
                    }
                }

                /*
                for (int y = offsetY; y < Height; y += GridSize)
                {
                    Point horLineStart = new Point(0, y);
                    Point horLineEnd = new Point(Width - 1, y);
                
                    g.DrawLine(dashedLines, horLineStart, horLineEnd);
                }
                
                for (int x = offsetX; x < Width; x += GridSize)
                {
                    Point verLineStart = new Point(x, 0);
                    Point verLineEnd = new Point(x, Height - 1);
                
                    g.DrawLine(dashedLines, verLineStart, verLineEnd);
                }
                */
            }
        }

        private Vector2 ScreenToWorld(Point screenPos)
        {
            Vector2 worldPos = new Vector2();
            worldPos.X = (screenPos.X + PanOffset.X) / ScaleFactor;
            worldPos.Y = (screenPos.Y + PanOffset.Y) / ScaleFactor;
            return worldPos;
        }

        private Point WorldToScreen(Vector2 worldPos)
        {
            Point screenPos = new Point();
            screenPos.X = (int)((worldPos.X - PanOffset.X) * ScaleFactor);
            screenPos.Y = (int)((worldPos.Y - PanOffset.Y) * ScaleFactor);
            return screenPos;
        }

        private void StartPanning(Point mousePos)
        {
            panning = true;
            startPanPos = mousePos;
            Cursor.Current = Cursors.NoMove2D;
        }

        private void DoPanning(Point mousePos)
        {
            float offsetX = (mousePos.X - startPanPos.X) / ScaleFactor;
            float offsetY = (mousePos.Y - startPanPos.Y) / ScaleFactor;
            startPanPos = mousePos;
            PanOffset -= new Vector2(offsetX, offsetY);
        }

        private void EndPanning()
        {
            panning = false;
            Cursor.Current = Cursors.Default;
        }
    }
}
