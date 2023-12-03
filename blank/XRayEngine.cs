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
        private Shape selected_obj = null;
        private LightSource selected_light = null;
        Double Infinity = Double.MaxValue;
        Double projection_plane_z = 1.0;
        Double viewport_size = 1.5;
        Vector4 camera_pos = new Vector4(0, 0, 0);

        public XRayEngine()
        {
            InitializeComponent();
            _bitmap = new Bitmap(canvas.Width, canvas.Height);
            _graphics = Graphics.FromImage(_bitmap);
            _graphics.Clear(Color.White);
            canvas.Image = _bitmap;
            _scene = new Scene();
            cb_light_type.Items.Add(LIGHT_TYPE.AMBIENT);
            cb_light_type.Items.Add(LIGHT_TYPE.POINT);
            cb_light_type.Items.Add(LIGHT_TYPE.DIRECTIONAL);
            UdateUi();

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

            if (depth <= 0) return local_color;

            Vector4 reflect_ray = ReflectiveRay(-direction, normal);
            Vector4 reflected_color = TraceRay(p, reflect_ray, 0.001, Infinity, depth - 1);
            Vector4 blend_color = (reflected_color * closest_obj.reflective) + (local_color * (1 - closest_obj.reflective));
            if (closest_obj.transparency <= 0) return blend_color;

            var (t1, t2) = (closest_obj as IIntersect).Intersect(origin, direction);
            var tmax = Math.Max(t1, t2);
            Vector4 transparent_color = TraceRay(origin, direction, tmax, max_t, 0);

            Vector4 mixed_color = (transparent_color * closest_obj.transparency) + (blend_color * (1 - closest_obj.transparency));

            return mixed_color;
        }

        private double ComputateLightning(Vector4 point, Vector4 normal, Vector4 view, double specular)
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
                    if (shadow_obj != null && shadow_obj.transparency < 1) continue;

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
                if ((obj as Shape).transparency == 1 || !(obj as Shape).visible) continue;
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

        private void UdateUi()
        {
            if (selected_light != null)
            {
                num_x.Value = (decimal)selected_light.position.x;
                num_y.Value = (decimal)selected_light.position.y;
                num_z.Value = (decimal)selected_light.position.z;

                cb_light_type.SelectedItem = selected_light.type;
                n_intensity.Value = (decimal)selected_light.intensity;
            }
            if (selected_obj != null)
            {
                n_specular.Value = (decimal)selected_obj.specular;
                n_reflective.Value = (decimal)selected_obj.reflective;
                n_transparency.Value = (decimal)selected_obj.transparency;
                chb_visible.Checked = selected_obj.visible;

                pos_x.Value = (decimal)selected_obj.position.x;
                pos_y.Value = (decimal)selected_obj.position.y;
                pos_z.Value = (decimal)selected_obj.position.z;

                color_r.Value = selected_obj.color.R;
                color_g.Value = selected_obj.color.G;
                color_b.Value = selected_obj.color.B;
            }
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            foreach (var item in _scene.objects)
            {
                listBox1.Items.Add(item);
            }
            foreach (var item in _scene.light_sources)
            {
                listBox2.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawAll();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            viewport_size = 1.5 + -trackBar1.Value * 0.25;
            DrawAll();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected_obj = (Shape)listBox1.SelectedItem;
            UdateUi();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected_light = (LightSource)listBox2.SelectedItem;
            UdateUi();
        }

        private void chb_visible_CheckedChanged(object sender, EventArgs e)
        {
            if (selected_obj != null)
            {
                selected_obj.visible = chb_visible.Checked;
                DrawAll();
            }
        }


        private void btn_flip_Click(object sender, EventArgs e)
        {
            viewport_size *= -1;
            DrawAll();
        }
        private void btn_add_light_Click(object sender, EventArgs e)
        {
            _scene.light_sources.Add(new LightSource());
            UdateUi();
            DrawAll();
        }

        private void btn_add_box_Click(object sender, EventArgs e)
        {
            _scene.objects.Add(new Box());
            UdateUi();
            DrawAll();
        }

        private void btn_add_sphere_Click(object sender, EventArgs e)
        {
            _scene.objects.Add(new Sphere());
            UdateUi();
            DrawAll();
        }

        private void btn_delete_obj_Click(object sender, EventArgs e)
        {
            if (selected_obj != null)
            {
                _scene.objects.Remove((IIntersect)selected_obj);
                selected_obj = null;
                listBox1.SelectedItem = null;
            }
            if (selected_light != null)
            {
                _scene.light_sources.Remove(selected_light);
                selected_light = null;
                listBox2.SelectedItem = null;
            }
            UdateUi();
            DrawAll();
        }

        private void btn_change_Click(object sender, EventArgs e)
        {
            if (selected_obj != null)
            {
                selected_obj.color = Color.FromArgb((int)color_r.Value, (int)color_g.Value, (int)color_b.Value);
                selected_obj.position = new Vector4((double)pos_x.Value, (double)pos_y.Value, (double)pos_z.Value);
                selected_obj.specular = (double)n_specular.Value;
                selected_obj.visible = chb_visible.Checked;
                selected_obj.reflective = (double)n_reflective.Value;
                selected_obj.transparency = (double)n_transparency.Value;

            }
            if (selected_light != null)
            {
                selected_light.position = new Vector4((double)num_x.Value, (double)num_y.Value, (double)num_z.Value);
                selected_light.intensity = (double)n_intensity.Value;
                selected_light.type = (LIGHT_TYPE)cb_light_type.SelectedItem;
            }
            UdateUi();
            DrawAll();
        }
    }
}
