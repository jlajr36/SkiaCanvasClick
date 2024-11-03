using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SkiaCanvasClick
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SKPaint paint = new SKPaint
        {
            Color = SKColors.White,
            IsAntialias = true,
            StrokeWidth = 1,
        };

        float step = 0.01f;

        public class LightPoint
        {
            public float x { get; set; }
            public float y { get; set; }
            public float size;

            private static Random random = new Random();
            float min = 0.5f;
            float max = 5.5f;

            public LightPoint(float x, float y)
            {
                this.x = x;
                this.y = y;
                this.size = (float)random.NextDouble() * (max - min) + min;
            }
        }

        List<LightPoint> lPoints = new List<LightPoint>();

        private void skglControl1_MouseClick(
            object sender,
            System.Windows.Forms.MouseEventArgs e)
        {
            lPoints.Add(new LightPoint(e.X, e.Y));
        }

        private void skglControl1_PaintSurface(
            object sender,
            SkiaSharp.Views.Desktop.SKPaintGLSurfaceEventArgs e)
        {
            e.Surface.Canvas.Clear(SKColors.Black);
            for (int i = 0; i < lPoints.Count; i++)
            {
                e.Surface.Canvas.DrawCircle(
                    lPoints[i].x,
                    lPoints[i].y,
                    lPoints[i].size,
                    paint
                );
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            skglControl1.Invalidate();
            Application.DoEvents();
        }
    }
}
