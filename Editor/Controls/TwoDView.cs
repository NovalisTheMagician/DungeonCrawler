using System;
using System.Drawing;
using System.Windows.Forms;
using System.Numerics;

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

        public float ScaleFactor { get; set; }
        public int Zoom
        {
            get
            {
                return (int)(ScaleFactor * 100);
            }
            set
            {
                ScaleFactor = value / 100.0f;
            }
        }

        public Vector2 PanOffset { get; set; }

        public int GridSize { get; set; }

        private bool panning;
        private Point startPanPos;

        private Font textFont;

        public TwoDView()
        {
            InitializeComponent();

            BackColor = Color.DarkBlue;

            DoubleBuffered = true;

            ScaleFactor = 1.0f;
            PanOffset = Vector2.Zero;
            Orientation = Orientation.TOP;
            GridSize = 64;

            textFont = new Font(FontFamily.GenericMonospace, 8);

            panning = false;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Middle && !panning)
            {
                panning = true;
                startPanPos = e.Location;
            }
            else if(e.Button == MouseButtons.Left && Control.ModifierKeys == Keys.Control && !panning)
            {
                panning = true;
                startPanPos = e.Location;
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Middle || e.Button == MouseButtons.Left)
            {
                if (panning) panning = false;
            }
            base.OnMouseUp(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            ScaleFactor += 0.01f * e.Delta;
            if (ScaleFactor <= 0.01f)
                ScaleFactor = 0.01f;
            Invalidate();

            base.OnMouseWheel(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if(panning)
            {
                int offsetX = e.X - startPanPos.X;
                int offsetY = e.Y - startPanPos.Y;
                startPanPos = e.Location;
                PanOffset += new Vector2(offsetX, offsetY);

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

            base.OnPaint(pe);
        }

        public void DrawStats(Graphics g)
        {
            Brush fontBrush = Brushes.GhostWhite;
            g.DrawString(Orientation.ToString(), textFont, fontBrush, new PointF(10, 10));
            g.DrawString($"Zoom: {Zoom}%", textFont, fontBrush, new PointF(10, Height - 30));
        }

        public void DrawGrid(Graphics g)
        {
            float[] dashPattern = { 2, 5, 5, 5 };
            using (Pen dashedLines = new Pen(Color.DarkGray, 1))
            {
                dashedLines.DashPattern = dashPattern;
                dashedLines.DashCap = System.Drawing.Drawing2D.DashCap.Round;

                int offsetX = (int)PanOffset.X % GridSize;
                int offsetY = (int)PanOffset.Y % GridSize;
                dashedLines.DashOffset = -offsetX;
                for (int y = offsetY; y < Height; y += GridSize)
                {
                    Point horLineStart = new Point(0, y);
                    Point horLineEnd = new Point(Width - 1, y);
                
                    g.DrawLine(dashedLines, horLineStart, horLineEnd);
                }

                dashedLines.DashOffset = -offsetY;
                for (int x = offsetX; x < Width; x += GridSize)
                {
                    Point verLineStart = new Point(x, 0);
                    Point verLineEnd = new Point(x, Height - 1);
                
                    g.DrawLine(dashedLines, verLineStart, verLineEnd);
                }
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
    }
}
