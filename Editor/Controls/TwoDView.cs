using System;
using System.Drawing;
using System.Windows.Forms;
using System.Numerics;
using System.ComponentModel;

using WinBrush = System.Drawing.Brush;

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

        private int zoom;
        [Browsable(false)]
        public int Zoom
        {
            get { return zoom; }
            set
            {
                zoom = value;
                if (zoom < 10) zoom = 10;
                if (zoom > 400) zoom = 400;
            }
        }

        [Browsable(false)]
        public Vector2 PanOffset { get; set; }

        [Browsable(false)]
        public int GridSize { get; set; }

        [Browsable(false)]
        public int AltGridSize { get; set; }

        private bool panning;
        private Point startPanPos;

        private Font textFont;
        
        private Vector2 mousePosSnapped;
        private Vector2 mousePos;

        private bool drawCursor;

        public TwoDView()
        {
            InitializeComponent();

            BackColor = Color.DarkBlue;

            DoubleBuffered = true;

            textFont = new Font(FontFamily.GenericMonospace, 8);
            mousePosSnapped = new Vector2();

            drawCursor = false;

            panning = false;
        }

        protected override void OnCreateControl()
        {
            Zoom = 100;
            PanOffset = new Vector2((-Width / 2) / ScaleFactor, (-Height / 2) / ScaleFactor);
            GridSize = 64;
            AltGridSize = 32;

            base.OnCreateControl();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Middle && !panning)
            {
                StartPanning(e.Location);
            }
            else if(e.Button == MouseButtons.Right && ModifierKeys == Keys.Control && !panning)
            {
                StartPanning(e.Location);
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Middle || e.Button == MouseButtons.Right)
            {
                if (panning)
                    EndPanning();
            }

            base.OnMouseUp(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            drawCursor = true;

            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            //if(Focused) Parent.Focus();
            drawCursor = false;

            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            Vector2 mousePosBeforeZoom = ScreenToWorld(e.Location);

            int factor = 5;
            if (Control.ModifierKeys == Keys.Shift)
                factor = 10;
            else if (Control.ModifierKeys == Keys.Control)
                factor = 1;

            Zoom += factor * Math.Sign(e.Delta);

            Vector2 mousePosAfterZoom = ScreenToWorld(e.Location);

            PanOffset += mousePosBeforeZoom - mousePosAfterZoom;

            Invalidate();
            
            base.OnMouseWheel(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if(panning)
            {
                DoPanning(e.Location);
            }

            mousePos = ScreenToWorld(e.Location);
            
            mousePosSnapped.X = (float)Math.Floor((mousePos.X + GridSize / 2) / GridSize) * GridSize;
            mousePosSnapped.Y = (float)Math.Floor((mousePos.Y + GridSize / 2) / GridSize) * GridSize;

            if(Control.ModifierKeys == Keys.Control)
            {
                mousePosSnapped.X = (float)Math.Floor((mousePos.X + AltGridSize / 2) / AltGridSize) * AltGridSize;
                mousePosSnapped.Y = (float)Math.Floor((mousePos.Y + AltGridSize / 2) / AltGridSize) * AltGridSize;
            }
            else if(Control.ModifierKeys == Keys.Shift)
            {
                mousePosSnapped.X = mousePos.X;
                mousePosSnapped.Y = mousePos.Y;
            }

            Invalidate();

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
            if(!Enabled)
            {
                g.Clear(Color.LightGray);
                return;
            }

            g.Clear(Color.DarkBlue);

            DrawGrid(g);
            DrawWorldAxis(g);
            if(drawCursor)
                DrawCursor(g);
            DrawStats(g);

            base.OnPaint(pe);
        }

        private void DrawCursor(Graphics g)
        {
            Point screenSnapped = WorldToScreen(mousePosSnapped);
            g.FillEllipse(Brushes.PaleVioletRed, screenSnapped.X - 5, screenSnapped.Y - 5, 10, 10);
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
            TextRenderer.DrawText(g, Orientation.ToString(), textFont, new Point(10, 10), Color.GhostWhite);
            string coord1Label = "X", coord2Label = "Y";
            switch(Orientation)
            {
                case Orientation.FRONT: break;
                case Orientation.SIDE: coord1Label = "Z"; break;
                case Orientation.TOP: coord2Label = "Z"; break;
            }

            TextRenderer.DrawText(g, $"{coord1Label}={mousePosSnapped.X} {coord2Label}={mousePosSnapped.Y * -1}", textFont, new Point(10, 30), Color.GhostWhite);
            TextRenderer.DrawText(g, $"Zoom: {Zoom}%", textFont, new Point(10, Height - 30), Color.GhostWhite);
        }

        private void DrawGrid(Graphics g)
        {
            Vector2 worldTopLeft = ScreenToWorld(new Point(0, 0));
            Vector2 worldBottomRight = ScreenToWorld(new Point(Width, Height));

            worldTopLeft.X = (float)Math.Floor(worldTopLeft.X);
            worldTopLeft.Y = (float)Math.Floor(worldTopLeft.Y);
            worldBottomRight.X = (float)Math.Ceiling(worldBottomRight.X);
            worldBottomRight.Y = (float)Math.Ceiling(worldBottomRight.Y);

            float offsetX = PanOffset.X % GridSize;
            float offsetY = PanOffset.Y % GridSize;

            using (Pen gridPen = new Pen(Color.FromArgb(64, Color.DarkGray), 1))
            {
                for (float y = worldTopLeft.Y - offsetY; y < worldBottomRight.Y; y += GridSize)
                {
                    Point start = WorldToScreen(new Vector2(worldTopLeft.X, y));
                    Point end = WorldToScreen(new Vector2(worldBottomRight.X, y));
                    g.DrawLine(gridPen, start, end);
                }

                for (float x = worldTopLeft.X - offsetX; x < worldBottomRight.X; x += GridSize)
                {
                    Point start = WorldToScreen(new Vector2(x, worldTopLeft.Y));
                    Point end = WorldToScreen(new Vector2(x, worldBottomRight.Y));
                    g.DrawLine(gridPen, start, end);
                }
            }
        }

        private Vector2 ScreenToWorld(Point screenPos)
        {
            Vector2 worldPos = new Vector2();
            worldPos.X = (screenPos.X / ScaleFactor) + PanOffset.X;
            worldPos.Y = (screenPos.Y / ScaleFactor) + PanOffset.Y;
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
            Cursor.Current = Cursors.SizeAll;
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
