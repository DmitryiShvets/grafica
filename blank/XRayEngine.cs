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
        private Color bg_col = Color.White;

        Double Infinity = Double.MaxValue;
        Double projection_plane_z = 1.0;
        Double viewport_size = 1;
        Vector4 camera_pos = new Vector4(0, 0, 0);

        public XRayEngine()
        {
            InitializeComponent();
            _bitmap = new Bitmap(canvas.Width, canvas.Height);
            _graphics = Graphics.FromImage(_bitmap);
            _graphics.Clear(Color.White);
            canvas.Image = _bitmap;
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
                        Vector4 rgb = TraceRay(camera_pos, direction, 1, Infinity, 1);
                        Color color = rgb.ToColor();
                        fastBitmap[x + canvas.Width / 2, canvas.Height / 2 - y - 1] = color;
                    }
            }
            canvas.Image = _bitmap;
            canvas.Invalidate();
        }

        private Vector4 TraceRay(Vector4 origin, Vector4 direction, Double min_t, Double max_t, int depth)
        {
            var (closest_obj, closest_t) = ClosestInIntersection(origin, direction, min_t, max_t);

            if (closest_obj == null) return new Vector4(bg_col.R, bg_col.G, bg_col.B);

            Vector4 p = origin + direction * closest_t;
            Vector4 normal = (closest_obj as IIntersect).GetNormal(p);

            double local_lighting = ComputateLightning(p, normal, -direction, closest_obj.specular);
            Vector4 local_color = Vector4.MixColor(closest_obj.color, local_lighting);

            if (closest_obj.reflective <= 0 || depth <= 0) return local_color;

            Vector4 reflect_ray = ReflectiveRay(-direction, normal);
            Vector4 reflected_color = TraceRay(p, reflect_ray, 0.001, Infinity, depth - 1);
            
            return  (reflected_color * closest_obj.reflective) + (local_color * (1 - closest_obj.reflective));
        }

        private double ComputateLightning(Vector4 point, Vector4 normal, Vector4 view, int specular)
        {
            double intensity = 0.0;
            foreach (var light in _scene.light_sources)
            {
                if (light.type == LIGHT_TYPE.AMBIENT) intensity += light.intensity;
                else
                {
                    double t_max;
                    Vector4 vec_light;
                    if (light.type == LIGHT_TYPE.POINT)
                    {
                        vec_light = light.position - point;
                        t_max = 1.0f;
                    }
                    else
                    {
                        vec_light = light.position;
                        t_max = Infinity;
                    }

                    var (shadow_obj, shadow_t) = ClosestInIntersection(point, vec_light, 0.001, t_max);
                    if (shadow_obj != null) continue;

                    double cos_light = Vector4.DotProduct(vec_light, normal);
                    if (cos_light > 0) intensity += light.intensity * cos_light / (normal.Length() * vec_light.Length());


                    if (specular >= 0)
                    {
                        Vector4 vec_ref = ReflectiveRay(vec_light, normal);
                        double cos_ref = Vector4.DotProduct(vec_ref, view);
                        if (cos_ref > 0) intensity += light.intensity * Math.Pow(cos_ref / (vec_ref.Length() * view.Length()), specular);
                    }
                }
            }
            return intensity;
        }

        private (Shape, double) ClosestInIntersection(Vector4 origin, Vector4 direction, Double min_t, Double max_t)
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
            return (closest_obj, closest_t);
        }

        private Vector4 ReflectiveRay(Vector4 ray, Vector4 normal)
        {
            return ((2 * normal * Vector4.DotProduct(ray, normal)) - ray);
        }

        private Vector4 CanvsToViewport(int x, int y)
        {
            return new Vector4(x * (viewport_size / canvas.Width), y * (viewport_size / canvas.Height), projection_plane_z);
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            DrawAll();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            viewport_size = trackBar1.Value;
            DrawAll();
        }
    }
}
