using blank.Render;
using FastBitmaps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace blank
{
    public partial class XRayEngine : UserControl
    {
        private Bitmap _bitmap;
        private Graphics _graphics;
        private Scene _scene;
        private Color background_color = Color.Black;

        Double Infinity = Double.MaxValue;
        Double projection_plane_z = 1.0;
        Double viewport_size = 1.0;
        Vector4 camera_pos = new Vector4(0,0,-2);

        public XRayEngine()
        {
            InitializeComponent();
            _bitmap = new Bitmap(canvas.Width, canvas.Height);
            _graphics = Graphics.FromImage(_bitmap);
            _graphics.Clear(Color.White);
            canvas.Image = _bitmap;
            _bitmap.SetPixel(400, 0, Color.Red);
            _bitmap.SetPixel(0, 300, Color.Blue);
            _scene = new Scene();
        }

        private void DrawAll()
        {
            using (var fastBitmap = new FastBitmap(_bitmap))
            {
                for (int x = -canvas.Width / 2; x < canvas.Width / 2; x++)
                    for (int y = -canvas.Height / 2; y < canvas.Height / 2; y++)
                    {
                        Vector4 direction = CanvsToViewport(x, y);
                        Color color = TraceRay(camera_pos, direction, 1, Infinity);
                        fastBitmap[x + canvas.Width / 2, canvas.Height / 2 - y - 1] = color;
                    }
            }
            canvas.Image = _bitmap;
            canvas.Invalidate();
        }

        private Vector4 CanvsToViewport(int x, int y)
        {
            return new Vector4((x * (float)(viewport_size / canvas.Width)), (y * (float)(viewport_size / canvas.Height)), (float)projection_plane_z);
        }

        private Color TraceRay(Vector4 origin, Vector4 direction, Double min_t, Double max_t)
        {
            double closest_t = Infinity;
            Shape closest_obj = null;

            foreach (var obj in _scene.objects)
            {
                (double, double) cur_t = obj.Intersect(origin, direction);

                if (cur_t.Item1 < closest_t && cur_t.Item1 > min_t && cur_t.Item1 < max_t)
                {
                    closest_t = cur_t.Item1;
                    closest_obj = obj as Shape;
                }

                if (cur_t.Item2 < closest_t && cur_t.Item2 > min_t && cur_t.Item2 < max_t)
                {
                    closest_t = cur_t.Item2;
                    closest_obj = obj as Shape;
                }
            }

            if (closest_obj == null) return background_color;

            return closest_obj.color;
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            DrawAll();
        }
    }
}
