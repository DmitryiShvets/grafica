using FastBitmaps;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using blank.Primitives;
namespace blank.Utility
{
    class Render
    {
        float[,] z_buff = null;
        PictureBox canvas;
        Bitmap bmp;
        public bool zbuffer = false;
        public bool cull_backfaces = false;
        public Render(PictureBox canvas, Bitmap bmp)
        {
            this.canvas = canvas;
            this.bmp = bmp;
            z_buff = new float[bmp.Width, bmp.Height];
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    z_buff[i, j] = 0;
                }
            }
        }
        public static float GetIntensive(double lamb)
        {
            return (float)(lamb + 1) / 2;
        }

        public static double GetLambertLightnes(Vector4 vertex, Vector4 light, Vector4 normal)
        {
            var ray_to_vertex = new Vector4(light.x - vertex.x, light.y - vertex.y, light.z - vertex.z).Normalize();
            return Math.Max((double)Vector4.DotProduct(normal.Normalize(), ray_to_vertex), 0.0);
        }

        public void ClearZBuff()
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    z_buff[i, j] = 0;
                }
            }
        }
        public static List<float> Interpolate(float fx0, float y0, float fx1, float y1)
        {
            int x0 = (int)fx0;
            int x1 = (int)fx1;

            if (x0 == x1) return new List<float> { y0 };
            List<float> values = new List<float>();
            float a = (y1 - y0) / (x1 - x0);
            float d = y0;
            for (float i = x0; i <= x1; ++i)
            {
                values.Add(d);
                d += a;
            }
            return values;
        }

        public void Draw(Vector4 p0, Vector4 p1, Vector4 p2, Color color)
        {
            DrawLine(p0, p1, color);
            DrawLine(p1, p2, color);
            DrawLine(p2, p0, color);
        }

        public void DrawTriangle(Vector4 p0, Vector4 p1, Vector4 p2, Color color)
        {
            if (p0.y < 0 || p1.y < 0 || p2.y < 0) return;
            if (p0.y > bmp.Height || p1.y > bmp.Height || p2.y > bmp.Height) return;
            if (p0.x < 0 || p1.x < 0 || p2.x < 0) return;
            if (p0.x > bmp.Width || p1.x > bmp.Width || p2.x > bmp.Width) return;

            if (p1.y < p0.y) (p0, p1) = (p1, p0);
            if (p2.y < p0.y) (p0, p2) = (p2, p0);
            if (p2.y < p1.y) (p1, p2) = (p2, p1);
            //float h0 = 1.0f, h1 = 0.5f, h2 = 0.5f;
            List<float> x01 = Interpolate(p0.y, p0.x, p1.y, p1.x);
            List<float> h01 = Interpolate(p0.y, p0.h, p1.y, p1.h);
            List<float> z01 = Interpolate(p0.y, 1 / (p0.z + 1), p1.y, 1 / (p1.z + 1));
            List<float> x12 = Interpolate(p1.y, p1.x, p2.y, p2.x);
            List<float> h12 = Interpolate(p1.y, p1.h, p2.y, p2.h);
            List<float> z12 = Interpolate(p1.y, 1 / (p1.z + 1), p2.y, 1 / (p2.z + 1));
            List<float> x02 = Interpolate(p0.y, p0.x, p2.y, p2.x);
            List<float> h02 = Interpolate(p0.y, p0.h, p2.y, p2.h);
            List<float> z02 = Interpolate(p0.y, 1 / (p0.z + 1), p2.y, 1 / (p2.z + 1));

            List<float> x012 = new List<float>();
            List<float> h012 = new List<float>();
            List<float> z012 = new List<float>();


            x01.Remove(x01.Last());
            h01.Remove(h01.Last());
            z01.Remove(z01.Last());

            if(x01.Count + x12.Count != x02.Count)
            {
                Console.WriteLine("Ошибка! индексы не совпадают!\n");
                Console.WriteLine(x01.Count + x12.Count + " " + x02.Count);
            }

            x012.AddRange(x01);
            x012.AddRange(x12);

            h012.AddRange(h01);
            h012.AddRange(h12);

            z012.AddRange(z01);
            z012.AddRange(z12);

            int m = (int)Math.Floor((double)x012.Count / 2);
            List<float> x_left;
            List<float> x_right;

            List<float> h_left;
            List<float> h_right;

            List<float> z_left;
            List<float> z_right;

            if (x02[m] < x012[m])
            {
                x_left = x02;
                h_left = h02;
                z_left = z02;

                x_right = x012;
                h_right = h012;
                z_right = z012;
            }
            else
            {
                x_left = x012;
                h_left = h012;
                z_left = z012;

                x_right = x02;
                h_right = h02;
                z_right = z02;
            }

            using (var fastBitmap = new FastBitmap(bmp))
            {
                int i = 0;
                for (int y = (int)p0.y; y < (int)p2.y; ++y)
                {
                    List<float> hs = Interpolate(x_left[i], h_left[i], x_right[i], h_right[i]);
                    List<float> zs = Interpolate(x_left[i], z_left[i], x_right[i], z_right[i]);
                    int j = 0;
                    for (int x = (int)x_left[i]; x < (int)x_right[i]; ++x)
                    {
                        Color shaded_color = Color.FromArgb((int)(color.R * hs[j]), (int)(color.G * hs[j]), (int)(color.B * hs[j]));
                        float z = zs[j];
                        if (zbuffer)
                        {
                            if (z < z_buff[x, y])
                            {
                                fastBitmap[x, y] = shaded_color;
                                z_buff[x, y] = z;
                            }
                        }
                        else
                        {
                            fastBitmap[x, y] = shaded_color;
                        }
                        j++;
                    }
                    i++;
                }
            }
            canvas.Image = bmp;
            canvas.Invalidate();
        }

        public void DrawLine(Vector4 p0, Vector4 p1, Color color)
        {
            if (Math.Abs(p1.x - p0.x) > Math.Abs(p1.y - p0.y))
            {
                //Прямая горизонтальная
                if (p0.x > p1.x) (p0, p1) = (p1, p0);
                List<float> ys = Interpolate(p0.x, p0.y, p1.x, p1.y);

                using (var fastBitmap = new FastBitmap(bmp))
                {
                    int i = 0;
                    for (int x = (int)p0.x; x < (int)p1.x; ++x)
                    {
                        fastBitmap[x, (int)ys[i++]] = color;
                    }
                }
                canvas.Image = bmp;
                canvas.Invalidate();

            }
            else
            {
                //Прямая вертикальная
                if (p0.y > p1.y) (p0, p1) = (p1, p0);
                List<float> xs = Interpolate(p0.y, p0.x, p1.y, p1.x);
                using (var fastBitmap = new FastBitmap(bmp))
                {
                    int i = 0;
                    for (int y = (int)p0.y; y < (int)p1.y; ++y)
                    {
                        fastBitmap[(int)xs[i++], y] = color;
                    }
                }
                canvas.Image = bmp;
                canvas.Invalidate();
            }
        }
    }
}
