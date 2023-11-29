using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using blank.Utility;
using FastBitmaps;
using blank.Primitives;
using System.Reflection;
using static blank.Utility.Matrix3D;
using blank.Shapes;
using static blank.Vertex2D;
using System.Xml.Linq;

namespace blank
{
    public partial class Task1 : Form
    {
        private Bitmap _bitmap;
        private Bitmap _bitmap_editor;
        private Graphics _graphics;
        private Graphics _graphics_editor;
        private List<Object3D> _objects;
        private List<Object3D> _objects_loaded;
        private Object3D edit_object = null;
        private int zoom = 1;
        private List<Vector4> editor_points;
        private PROJECTION_TYPE g_projection_type = PROJECTION_TYPE.PERSPECTIVE;
        private RotationFigure rotation_figure;
        private Object3D imported_model;
        private List<Triangle3D> trianglesChart = new List<Triangle3D>();
        private bool _interactive_mode = false;
        private Vector4 light_source = new Vector4();
        Vector4 camera_pos = new Vector4(0.0f, 0.0f, -1.0f);
        Vector4 camera_front = new Vector4(0.0f, 0.0f, 1.0f);
        Vector4 camera_up = new Vector4(0.0f, -1.0f, 0.0f);
        private float lastX = 525;
        private float lastY = 300;
        private float yaw = 90.0f;
        private float pitch = 0.0f;

        private bool back_face_culling = false;
        private bool zbuffer = false;
        private bool lightning = false;
        private float[] arrzbuffer;

        private Render render;

        ChartFH chartFH = null;
        List<Func<double, double, double>> functions = new List<Func<double, double, double>>();
        public Task1()
        {
            InitializeComponent();

            _bitmap = new Bitmap(canvas.Width, canvas.Height);
            _bitmap_editor = new Bitmap(editor.Width, editor.Height);
            _graphics = Graphics.FromImage(_bitmap);
            _graphics_editor = Graphics.FromImage(_bitmap_editor);
            _graphics.Clear(Color.White);
            _graphics_editor.Clear(Color.White);

            int divisions = count_partition.Text == "" ? 1 : Int32.Parse(count_partition.Text);
            rotation_figure = new RotationFigure(GetTransform(), divisions, cb_active_mesh.SelectedIndex, GetAxisType());

            AddAllObjects();
            comboBox1.SelectedIndex = 9;
            cb_active_mesh.SelectedIndex = 0;

            canvas.Image = _bitmap;
            editor.Image = _bitmap_editor;

            editor_points = new List<Vector4>();

            _objects = new List<Object3D>
            {
                GetObject(0)
            };
            _objects_loaded = new List<Object3D>();

            arrzbuffer = new float[canvas.Width * canvas.Height];
            for (int i = 0; i < arrzbuffer.Count(); i++)
            {
                arrzbuffer[i] = Int32.MinValue;
            }

            render = new Render(canvas, _bitmap);
            light_info.Text = light_source.ToString();
            DrawAll();
        }

        private void AddAllObjects()
        {
            comboBox1.Items.Add("Rotation");
            comboBox1.Items.Add("Cube");
            comboBox1.Items.Add("Tetrahedron");
            comboBox1.Items.Add("Octahedron");
            comboBox1.Items.Add("Icosahedron");
            comboBox1.Items.Add("Dodecahedron");
            comboBox1.Items.Add("Import");
            comboBox1.Items.Add("Chart");
            comboBox1.Items.Add("ChartFH");
            comboBox1.Items.Add("Scene");

            // Добавить все функции из презентации
            comboBox_func.Items.Add("sin(x + y)");
            comboBox_func.Items.Add("cos(cos(y) - cos(x))");
            comboBox_func.Items.Add("e^(sin(sqrt(x*x + y*y)))");

            functions.Add((x, y) => (float)Math.Sin(x + y));
            functions.Add((x, y) => (float)Math.Cos(Math.Cos(y) - Math.Cos(x)));
            functions.Add((x, y) => (float)Math.Exp(Math.Sin(Math.Sqrt(x*x + y*y))));
        }

        private Transform GetTransform()
        {
            return new Transform(new Vector4(0, 0, 2), new Vector4(0, 0, 0), new Vector4(1, 1, 1), new Vector4(1, 1, 1));
        }

        Matrix3D view_matrix = Matrix3D.LookAt(new Vector4(0, 0, -1), new Vector4(0, 0, 0), new Vector4(0, -1, 0));

        Matrix3D projection_matrix = Matrix3D.GetProjectionMatrix(45.0f, 1.2f, 0.1f, 100.0f);

        private void DrawAll()
        {
            _graphics.Clear(Color.White);
            _graphics_editor.Clear(Color.White);
            //render.ClearZBuff();
            DrawAxes();

            if (editor_points.Count > 0) DrawEditor();

            foreach (var obj in _objects)
            {
                foreach (var triangle in obj.mech.faces)
                {
                    DrawTriangle(triangle, obj.transform);
                }
            }

            canvas.Image = _bitmap;
            canvas.Invalidate();
            editor.Image = _bitmap_editor;
            editor.Invalidate();
        }
        private void DrawTriangle(Triangle3D triangle, Transform transform)
        {
            if (zbuffer)
            {
                if (g_projection_type == PROJECTION_TYPE.PERSPECTIVE)
                {
                    DrawTriangleZBufferPerspective(triangle, transform);
                }
                else
                {
                    DrawTriangleZBufferOrtho(triangle, transform);
                }
            }
            else if (back_face_culling)
            {
                if (g_projection_type == PROJECTION_TYPE.PERSPECTIVE)
                {
                    DrawTrianglePerspectiveWithBackfaceCulling(triangle, transform);
                }
                else
                {
                    DrawTriangleOrthoWithBackfaceCulling(triangle, transform);
                }
            }
            else if (lightning)
            {
                DrawTriangleLightningPerspective(triangle, transform);
            }
            else
            {
                if (g_projection_type == PROJECTION_TYPE.PERSPECTIVE)
                {
                    DrawTrianglePerspective(triangle, transform);
                }
                else
                {
                    DrawTriangleOrtho(triangle, transform);
                }
            }
        }

        private void DrawTrianglePerspective(Triangle3D triangle, Transform transform)
        {
            List<PointF> points = new List<PointF>();
            Matrix3D viewport_matrix = Matrix3D.GetViewPortMatrix(zoom, zoom, canvas.Width / 2, canvas.Height / 2);

            for (int i = 0; i < triangle.Size; ++i)
            {
                Matrix3D model = transform.ApplyTransform(triangle[i]);
                //if (model[2, 0] - camera_pos.z < 0) continue;
                Matrix3D view = view_matrix * model;
                Matrix3D projection = projection_matrix * view;
                projection /= projection[3, 0];
                Matrix3D canvas = viewport_matrix * projection;
                points.Add(canvas.ToVector4().ToPointF());
            }
            if (points.Count >= 3)
            {
                points.Add(points.First());
                _graphics.DrawLines(new Pen(triangle.color, 1.0f), points.ToArray());
            }
        }

        private void DrawTriangleOrtho(Triangle3D triangle, Transform transform)
        {
            List<PointF> points = new List<PointF>();
            Matrix3D viewport_matrix = Matrix3D.GetViewPortMatrix(zoom, zoom, canvas.Width / 2, canvas.Height / 2);
            Matrix3D projection_m = Matrix3D.GetOrtho(g_projection_type);

            for (int i = 0; i < triangle.Size; ++i)
            {
                Matrix3D model = transform.ApplyTransform(triangle[i]);
                Matrix3D view = view_matrix * model;
                Matrix3D projection = projection_m * view;
                Matrix3D canvas = viewport_matrix * projection.ToVector3(g_projection_type);
                points.Add(canvas.ToVector4().ToPointF());
            }
            if (points.Count >= 3)
            {
                points.Add(points.First());
                _graphics.DrawLines(new Pen(triangle.color, 1.0f), points.ToArray());
            }
        }

        private void DrawTrianglePerspectiveWithBackfaceCulling(Triangle3D triangle, Transform transform)
        {
            List<PointF> points = new List<PointF>();
            Matrix3D viewport_matrix = Matrix3D.GetViewPortMatrix(zoom, zoom, canvas.Width / 2, canvas.Height / 2);

            List<Vector4> v = new List<Vector4>();
            for (int i = 0; i < triangle.Size; ++i)
            {
                Matrix3D model = transform.ApplyTransform(triangle[i]);
                //if (model[2, 0] - camera_pos.z < 0) continue;
                Matrix3D view = view_matrix * model;
                Matrix3D projection = projection_matrix * view;
                projection /= projection[3, 0];
                Matrix3D canvas = viewport_matrix * projection;
                v.Add(canvas.ToVector4());
                points.Add(canvas.ToVector4().ToPointF());
            }
            var normal = Vector4.CrossProduct(v[1] - v[0], v[2] - v[0]);

            // new Vector4(0.0f, 0.0f, -1.0f) это начальная позиция камеры
            if (Vector4.DotProduct(normal, new Vector4(0.0f, 0.0f, -1.0f)) > 0)
            {
                if (points.Count >= 3)
                {
                    points.Add(points.First());
                    _graphics.DrawLines(new Pen(triangle.color, 1.0f), points.ToArray());
                }
            }
        }

        private void DrawTriangleOrthoWithBackfaceCulling(Triangle3D triangle, Transform transform)
        {
            List<PointF> points = new List<PointF>();
            Matrix3D viewport_matrix = Matrix3D.GetViewPortMatrix(zoom, zoom, canvas.Width / 2, canvas.Height / 2);
            Matrix3D projection_m = Matrix3D.GetOrtho(g_projection_type);

            List<Vector4> v = new List<Vector4>();
            for (int i = 0; i < triangle.Size; ++i)
            {
                Matrix3D model = transform.ApplyTransform(triangle[i]);
                Matrix3D view = view_matrix * model;
                Matrix3D projection = projection_m * view;
                Matrix3D canvas = viewport_matrix * projection.ToVector3(g_projection_type);
                v.Add(canvas.ToVector4());
                points.Add(canvas.ToVector4().ToPointF());
            }
            var normal = Vector4.CrossProduct(v[1] - v[0], v[2] - v[0]);

            // new Vector4(0.0f, 0.0f, -1.0f) это начальная позиция камеры
            if (Vector4.DotProduct(normal, new Vector4(0.0f, 0.0f, -1.0f)) > 0)
            {
                if (points.Count >= 3)
                {
                    points.Add(points.First());
                    _graphics.DrawLines(new Pen(triangle.color, 1.0f), points.ToArray());
                }
            }
        }

        private void ZBuffer(Vector4 t0, Vector4 t1, Vector4 t2, Color c)
        {
            if (t0.y == t1.y && t0.y == t2.y) return;
            if (t0.y > t1.y) (t0, t1) = (t1, t0);
            if (t0.y > t2.y) (t0, t2) = (t2, t0);
            if (t1.y > t2.y) (t1, t2) = (t2, t1);

            Func<double, double> func1 = y => (y - t0.y) / (t1.y - t0.y + 1) * (t1.x - t0.x + 1) + t0.x; // 0->1
            Func<double, double> func2 = y => (y - t0.y) / (t2.y - t0.y + 1) * (t2.x - t0.x + 1) + t0.x; // 0->2
            Func<double, double> func3 = y => (y - t1.y) / (t2.y - t1.y + 1) * (t2.x - t1.x + 1) + t1.x; // 1->2

            using (var fastBitmap = new FastBitmap(_bitmap))
            {
                int yMin = (int)t0.y;
                int yMax = (int)t1.y;

                int x1, x2;
                float zVal1, zVal2, zVal3;
                for (int i = (int)t0.y; i <= (int)t1.y; i++)
                {
                    x1 = (int)func1(i);
                    x2 = (int)func2(i);

                    yMin = (int)t0.y;
                    yMax = (int)t1.y;

                    zVal1 = LinY(i, yMin, yMax, t0.z, t1.z);

                    int idx = x1 + i * canvas.Width;
                    if (arrzbuffer[idx] <= zVal1)
                    {
                        arrzbuffer[idx] = zVal1;
                        fastBitmap[x1, i] = c;
                    }

                    yMin = (int)t0.y;
                    yMax = (int)t2.y;

                    zVal2 = LinY(i, yMin, yMax, t0.z, t2.z);

                    idx = x2 + i * canvas.Width;
                    if (arrzbuffer[idx] <= zVal2)
                    {
                        arrzbuffer[idx] = zVal2;
                        fastBitmap[x2, i] = c;
                    }

                    int minX = Math.Min(x1, x2);
                    int maxX = Math.Max(x1, x2);

                    if (minX == x1)
                    {
                        for (int j = minX; j < maxX; j++)
                        {
                            idx = j + i * canvas.Width;
                            zVal3 = LinY(j, minX, maxX, zVal1, zVal2);
                            if (arrzbuffer[idx] <= zVal3)
                            {
                                arrzbuffer[idx] = zVal3;
                                fastBitmap[j, i] = c;
                            }
                        }
                    }
                    else
                    {
                        for (int j = minX; j < maxX; j++)
                        {
                            idx = j + i * canvas.Width;
                            zVal3 = LinY(j, minX, maxX, zVal2, zVal1);
                            if (arrzbuffer[idx] <= zVal3)
                            {
                                arrzbuffer[idx] = zVal3;
                                fastBitmap[j, i] = c;
                            }
                        }
                    }
                }
                for (int i = (int)t1.y; i <= (int)t2.y; i++)
                {
                    yMin = (int)t0.y;
                    yMax = (int)t2.y;
                    x1 = (int)func3(i);
                    x2 = (int)func2(i);

                    zVal1 = LinY(i, yMin, yMax, t0.z, t2.z);

                    int idx = x1 + i * canvas.Width;
                    if (arrzbuffer[idx] <= zVal1)
                    {
                        arrzbuffer[idx] = zVal1;
                        fastBitmap[x1, i] = c;
                    }

                    yMin = (int)t1.y;
                    yMax = (int)t2.y;

                    zVal2 = LinY(i, yMin, yMax, t1.z, t2.z);

                    idx = x2 + i * canvas.Width;
                    if (arrzbuffer[idx] <= zVal2)
                    {
                        arrzbuffer[idx] = zVal2;
                        fastBitmap[x2, i] = c;
                    }

                    int minX = Math.Min(x1, x2);
                    int maxX = Math.Max(x1, x2);

                    if (minX == x1)
                    {
                        for (int j = minX; j < maxX; j++)
                        {
                            idx = j + i * canvas.Width;
                            zVal3 = LinY(j, minX, maxX, zVal2, zVal1);
                            if (arrzbuffer[idx] <= zVal3)
                            {
                                arrzbuffer[idx] = zVal3;
                                fastBitmap[j, i] = c;
                            }
                        }
                    }
                    else
                    {
                        for (int j = minX; j < maxX; j++)
                        {
                            idx = j + i * canvas.Width;
                            zVal3 = LinY(j, minX, maxX, zVal1, zVal2);
                            if (arrzbuffer[idx] <= zVal3)
                            {
                                arrzbuffer[idx] = zVal3;
                                fastBitmap[j, i] = c;
                            }
                        }
                    }
                }
            }
            canvas.Image = _bitmap;
        }

        private void DrawTriangleZBufferPerspective(Triangle3D triangle, Transform transform)
        {
            List<Vector4> points = new List<Vector4>();
            Matrix3D viewport_matrix = Matrix3D.GetViewPortMatrix(zoom, zoom, canvas.Width / 2, canvas.Height / 2);

            for (int i = 0; i < triangle.Size; ++i)
            {
                Matrix3D model = transform.ApplyTransform(triangle[i]);
                //if (model[2, 0] - camera_pos.z < 0) continue;
                Matrix3D view = view_matrix * model;
                Matrix3D projection = projection_matrix * view;
                projection /= projection[3, 0];
                Matrix3D canvas = viewport_matrix * projection;
                points.Add(canvas.ToVector4());
            }

            ZBuffer(points[0], points[1], points[2], triangle.color);

        }

        private void DrawTriangleZBufferOrtho(Triangle3D triangle, Transform transform)
        {
            List<Vector4> points = new List<Vector4>();
            Matrix3D viewport_matrix = Matrix3D.GetViewPortMatrix(zoom, zoom, canvas.Width / 2, canvas.Height / 2);
            Matrix3D projection_m = Matrix3D.GetOrtho(g_projection_type);

            for (int i = 0; i < triangle.Size; ++i)
            {
                Matrix3D model = transform.ApplyTransform(triangle[i]);
                Matrix3D view = view_matrix * model;
                Matrix3D projection = projection_m * view;
                Matrix3D canvas = viewport_matrix * projection.ToVector3(g_projection_type);
                points.Add(canvas.ToVector4());
            }

            ZBuffer(points[0], points[1], points[2], triangle.color);

        }

        private void DrawTriangleLightningPerspective(Triangle3D triangle, Transform transform)
        {
            Matrix3D viewport_matrix = Matrix3D.GetViewPortMatrix(zoom, zoom, canvas.Width / 2, canvas.Height / 2);
            List<Vector4> v = new List<Vector4>();
            for (int i = 0; i < triangle.Size; ++i)
            {
                Matrix3D projection = projection_matrix * view_matrix * transform.ApplyTransform(triangle[i]);
                projection /= projection[3, 0];
                Matrix3D canvas = viewport_matrix * projection;
                v.Add(canvas.ToVector4());
            }

            if (v.Count == 3)
            {
                var normal = Vector4.CrossProduct(v[1] - v[0], v[2] - v[0]);

                foreach (var vertex in v)
                {
                    double lambert = Render.GetLambertLightnes(vertex, light_source, normal);
                    vertex.h = Render.GetIntensive(lambert);
                }

                if (render.cull_backfaces)
                {
                    if ((double)Vector4.DotProduct(normal, camera_pos) > 0)
                    {
                        render.DrawTriangle(v[0], v[1], v[2], triangle.color);
                    }
                }
                else
                {
                    render.DrawTriangle(v[0], v[1], v[2], triangle.color);
                }
            }
        }

        private float LinX(int x, float a, float b, float c1, float c2)
        {
            if (c2 > c1)
            {
                return c1 + (x - a) * (c2 - c1) / (b - a + 1);
            }
            else
            {
                return c1 - (x - a) * (c1 - c2) / (b - a + 1);
            }
        }
        private float LinY(int y, float a, float b, float c1, float c2)
        {
            if (c2 > c1)
            {
                if (b - a == 0)
                {
                    b++;
                }
                return c1 + (y - a) * (c2 - c1) / (b - a);
            }
            else
            {
                if (b - a == 0)
                {
                    b++;
                }
                return c1 - (y - a) * (c1 - c2) / (b - a);
            }
        }

        private void DrawAxes()
        {
            //оси для канваса
            PointF y0 = new PointF(canvas.Width / 2, 0);
            PointF y1 = new PointF(canvas.Width / 2, canvas.Height);

            PointF x0 = new PointF(0, canvas.Height / 2);
            PointF x1 = new PointF(canvas.Width, canvas.Height / 2);

            //оси для редактора фигуры
            PointF yy0 = new PointF(editor.Width / 2, 0);
            PointF yy1 = new PointF(editor.Width / 2, editor.Height);

            PointF xx0 = new PointF(0, editor.Height / 2);
            PointF xx1 = new PointF(editor.Width, editor.Height / 2);

            switch (g_projection_type)
            {
                case PROJECTION_TYPE.ORTHO_X_PLUS:
                    {
                        DrawAxis(x0, x1, xx0, xx1, AXIS_TYPE.X, "+Z", "-Z", Color.Red);
                        DrawAxis(y0, y1, yy0, yy1, AXIS_TYPE.Y, "-Y", "+Y", Color.Blue);
                        break;
                    }
                case PROJECTION_TYPE.ORTHO_X_MINUS:
                    {
                        DrawAxis(x0, x1, xx0, xx1, AXIS_TYPE.X, "-Z", "+Z", Color.Red);
                        DrawAxis(y0, y1, yy0, yy1, AXIS_TYPE.Y, "-Y", "+Y", Color.Blue);
                        break;
                    }
                case PROJECTION_TYPE.ORTHO_Y_PLUS:
                    {
                        DrawAxis(x0, x1, xx0, xx1, AXIS_TYPE.X, "+X", "-X", Color.Red);
                        DrawAxis(y0, y1, yy0, yy1, AXIS_TYPE.Y, "-Z", "+Z", Color.Blue);
                        break;
                    }
                case PROJECTION_TYPE.ORTHO_Y_MINUS:
                    {
                        DrawAxis(x0, x1, xx0, xx1, AXIS_TYPE.X, "-X", "+X", Color.Red);
                        DrawAxis(y0, y1, yy0, yy1, AXIS_TYPE.Y, "-Z", "+Z", Color.Blue);
                        break;
                    }
                case PROJECTION_TYPE.PERSPECTIVE:
                case PROJECTION_TYPE.ORTHO_Z_PLUS:
                    {
                        DrawAxis(x0, x1, xx0, xx1, AXIS_TYPE.X, "-X", "+X", Color.Red);
                        DrawAxis(y0, y1, yy0, yy1, AXIS_TYPE.Y, "-Y", "+Y", Color.Blue);
                        break;
                    }
                case PROJECTION_TYPE.ORTHO_Z_MINUS:
                    {
                        DrawAxis(x0, x1, xx0, xx1, AXIS_TYPE.X, "+X", "-X", Color.Red);
                        DrawAxis(y0, y1, yy0, yy1, AXIS_TYPE.Y, "-Y", "+Y", Color.Blue);
                        break;
                    }
            }

        }

        private void DrawAxis(PointF a, PointF b, PointF aa, PointF bb, AXIS_TYPE axis_type, string axis_name_n, string axis_name_p, Color color)
        {
            _graphics.DrawLine(new Pen(color), a, b);

            _graphics_editor.DrawLine(new Pen(color), aa, bb);
            switch (axis_type)
            {
                case AXIS_TYPE.X:
                    {
                        _graphics.DrawString(axis_name_p, new Font("Arial", 10, FontStyle.Regular),
                            new SolidBrush(Color.Red), b.X - 30, b.Y);
                        _graphics.DrawString(axis_name_n, new Font("Arial", 10, FontStyle.Regular),
                            new SolidBrush(Color.Red), a.X, a.Y);
                        break;
                    }
                case AXIS_TYPE.Y:
                    {
                        _graphics.DrawString(axis_name_p, new Font("Arial", 10, FontStyle.Regular),
                            new SolidBrush(Color.Blue), a.X, a.Y);
                        _graphics.DrawString(axis_name_n, new Font("Arial", 10, FontStyle.Regular),
                            new SolidBrush(Color.Blue), b.X, b.Y - 20);
                        break;
                    }
                case AXIS_TYPE.Z:
                    {
                        _graphics.DrawString(axis_name_n, new Font("Arial", 10, FontStyle.Regular),
                            new SolidBrush(Color.Green), a.X, a.Y);
                        _graphics.DrawString(axis_name_p, new Font("Arial", 10, FontStyle.Regular),
                            new SolidBrush(Color.Green), b.X + 10, b.Y - 20);
                        break;
                    }
            }
        }

        private void Task1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //e.Cancel = true;
                //Hide();
            }
        }

        private void ortho_x_plus_CheckedChanged(object sender, EventArgs e)
        {
            g_projection_type = PROJECTION_TYPE.ORTHO_X_PLUS;
            DrawAll();
        }

        private void ortho_x_minus_CheckedChanged(object sender, EventArgs e)
        {
            g_projection_type = PROJECTION_TYPE.ORTHO_X_MINUS;
            DrawAll();
        }

        private void ortho_y_plus_CheckedChanged(object sender, EventArgs e)
        {
            g_projection_type = PROJECTION_TYPE.ORTHO_Y_PLUS;
            DrawAll();
        }

        private void ortho_y_minus_CheckedChanged(object sender, EventArgs e)
        {
            g_projection_type = PROJECTION_TYPE.ORTHO_Y_MINUS;
            DrawAll();
        }

        private void ortho_z_plus_CheckedChanged(object sender, EventArgs e)
        {
            g_projection_type = PROJECTION_TYPE.ORTHO_Z_PLUS;
            DrawAll();
        }

        private void ortho_z_minus_CheckedChanged(object sender, EventArgs e)
        {
            g_projection_type = PROJECTION_TYPE.ORTHO_Z_MINUS;
            DrawAll();
        }

        private void perstective_CheckedChanged(object sender, EventArgs e)
        {
            g_projection_type = PROJECTION_TYPE.PERSPECTIVE;
            DrawAll();
        }

        private void t_transform_dx_KeyPress(object sender, KeyPressEventArgs e)
        {
            char el = e.KeyChar;
            if (!Char.IsDigit(el) && el != (char)Keys.Back && el != '-') // можно вводить только цифры, минус и стирать
                e.Handled = true;
        }

        private void btn_transform_apply_Click(object sender, EventArgs e)
        {
            if (edit_object != null)
            {
                Vector4 offset = new Vector4();
                if (t_transform_dx.Text != "") offset.x = Int32.Parse(t_transform_dx.Text);
                if (t_transform_dy.Text != "") offset.y = Int32.Parse(t_transform_dy.Text);
                if (t_transform_dz.Text != "") offset.z = Int32.Parse(t_transform_dz.Text);
                //_objects.Last().transform.Translate(offset);
                edit_object.transform.Translate(offset);
                DrawAll();
            }
        }

        private void btn_rotation_apply_Click(object sender, EventArgs e)
        {
            if (edit_object != null)
            {
                Vector4 offset = new Vector4();
                if (t_rotation_dx.Text != "") offset.x = Int32.Parse(t_rotation_dx.Text);
                if (t_rotation_dy.Text != "") offset.y = Int32.Parse(t_rotation_dy.Text);
                if (t_rotation_dz.Text != "") offset.z = Int32.Parse(t_rotation_dz.Text);
                //_objects.Last().transform.Rotate(offset);
                edit_object.transform.Rotate(offset);
                DrawAll();
            }
        }

        Object3D GetObject(int v)
        {
            switch (v)
            {
                case 0:
                    return rotation_figure;
                case 1:
                    return new Cube(GetTransform());
                case 2:
                    return new Tetrahedron(GetTransform());
                case 3:
                    return new Octahedron(GetTransform());
                case 4:
                    return new Icosahedron(GetTransform());
                case 5:
                    return new Dodecahedron(GetTransform());
                case 6:
                    return imported_model;
                case 7:
                    return new Chart(GetTransform(), trianglesChart);
            }
            return new Cube(GetTransform());
        }

        private void btn_draw_Click(object sender, EventArgs e)
        {
            int variant = comboBox1.SelectedIndex;
            if (comboBox1.SelectedItem.ToString() == "Chart")
            {
                trianglesChart = GetTriangleschart();
            }
            if (comboBox1.SelectedItem.ToString() == "ChartFH")
            {
                chartFH = new ChartFH(canvas.Width, canvas.Height, Color.Blue, Color.Black);
                double x1 = double.Parse(numericUpDown_x1.Text);
                double x2 = double.Parse(numericUpDown_x2.Text);
                double y1 = double.Parse(numericUpDown_y1.Text);
                double y2 = double.Parse(numericUpDown_y2.Text);
                double step = double.Parse(textBox_step.Text);
                chartFH.SetParameters(x1, x2, y1, y2, step, trackBarX.Value, trackBarY.Value, trackBarZ.Value);
                DrawChartFH();
                return;
            }
            if (comboBox1.SelectedItem.ToString() == "Scene")
            {
                _objects = new List<Object3D>(_objects_loaded);
                if (scene_list.SelectedItems.Count == 1)
                {
                    edit_object = scene_list.SelectedItems[0] as Object3D;
                }
            }
            else
            {
                _objects = new List<Object3D> { GetObject(variant) };
                edit_object = _objects.Last();
            }

            DrawAll();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            _objects.Clear();
            editor_points.Clear();
            int variant = comboBox1.SelectedIndex;

            int divisions = count_partition.Text == "" ? 1 : Int32.Parse(count_partition.Text);

            rotation_figure = new RotationFigure(GetTransform(), divisions, cb_active_mesh.SelectedIndex, GetAxisType());
            if (comboBox1.SelectedItem.ToString() == "Scene")
            {
                _objects = new List<Object3D>(_objects_loaded);
                scene_list.Items.Clear();
                foreach (var item in _objects)
                {
                    scene_list.Items.Add(item);
                }
            }
            else
            {
                _objects = new List<Object3D> { GetObject(variant) };
                edit_object = _objects.Last();
            }

            DrawAll();
        }

        private AXIS_TYPE GetAxisType()
        {
            if (rb_axis_x.Checked) return AXIS_TYPE.X;
            if (rb_axis_y.Checked) return AXIS_TYPE.Y;
            if (rb_axis_z.Checked) return AXIS_TYPE.Z;
            else return AXIS_TYPE.Y;
        }

        private void track_zoom_ValueChanged(object sender, EventArgs e)
        {
            zoom = track_zoom.Value;
            DrawAll();
        }

        private void btn_scale_apply_Click(object sender, EventArgs e)
        {
            if (edit_object != null)
            {
                Vector4 offset = new Vector4();
                if (t_scale_dx.Text != "") offset.x = Int32.Parse(t_scale_dx.Text);
                if (t_scale_dy.Text != "") offset.y = Int32.Parse(t_scale_dy.Text);
                if (t_scale_dz.Text != "") offset.z = Int32.Parse(t_scale_dz.Text);
                //_objects.Last().transform.Scale(offset);
                edit_object.transform.Scale(offset);
                DrawAll();
            }
        }

        private void btn_reflection_apply_Click(object sender, EventArgs e)
        {
            if (edit_object != null)
            {
                Vector4 offset = new Vector4(1, 1, 1);
                if (t_reflection_xy.Checked) offset.z *= -1;
                if (t_reflection_xz.Checked) offset.y *= -1;
                if (t_reflection_yz.Checked) offset.x *= -1;
                //_objects.Last().transform.Reflection(offset);
                edit_object.transform.Reflection(offset);
                DrawAll();
            }
        }

        private void btn_line_rotation_apply_Click(object sender, EventArgs e)
        {
            if (edit_object != null)
            {
                Vector4 point1 = new Vector4();
                Vector4 point2 = new Vector4();
                float angle = 0;

                if (tb_line_x1.Text != "") point1.x = Int32.Parse(tb_line_x1.Text);
                if (tb_line_y1.Text != "") point1.y = Int32.Parse(tb_line_y1.Text);
                if (tb_line_z1.Text != "") point1.z = Int32.Parse(tb_line_z1.Text);

                if (tb_line_x2.Text != "") point2.x = Int32.Parse(tb_line_x2.Text);
                if (tb_line_y2.Text != "") point2.y = Int32.Parse(tb_line_y2.Text);
                if (tb_line_z2.Text != "") point2.z = Int32.Parse(tb_line_z2.Text);

                if (tb_line_rotation_angle.Text != "") angle = Int32.Parse(tb_line_rotation_angle.Text);

                //_objects.Last().transform.RotateRelativeLine(point1, point2, angle);
                edit_object.transform.RotateRelativeLine(point1, point2, angle);
                DrawAll();
            }
        }

        private void editor_MouseClick(object sender, MouseEventArgs e)
        {
            float x = e.X - editor.Width / 2;
            float y = editor.Height / 2 - e.Y;

            editor_points.Add(new Vector4(x, y, 0));

            x = LinX(x, editor.Width) + 1;
            y = LinY(y, editor.Height);
            rotation_figure.editor_points_mesh_x.Add(new Vector4(y, 0, x));
            rotation_figure.editor_points_mesh_y.Add(new Vector4(x, y, 0));
            rotation_figure.editor_points_mesh_z.Add(new Vector4(x, 0, y));
            rotation_figure.Build();
            DrawAll();

        }

        private void DrawEditor()
        {
            Color c = Color.Green;
            float center_x = editor.Width / 2;
            float center_y = editor.Height / 2;

            _graphics_editor.DrawEllipse(new Pen(Color.Black), editor_points.First().x - 1 + center_x, center_y - editor_points.First().y - 1, 2, 2);
            for (int i = 1; i < editor_points.Count(); ++i)
            {
                _graphics_editor.DrawLine(new Pen(c), editor_points[i - 1].x + center_x, center_y - editor_points[i - 1].y, editor_points[i].x + center_x, center_y - editor_points[i].y);
            }
            _graphics_editor.DrawLine(new Pen(c), editor_points.Last().x + center_x, center_y - editor_points.Last().y, editor_points.First().x + center_x, center_y - editor_points.First().y);

        }

        private void editor_MouseMove(object sender, MouseEventArgs e)
        {
            float x = e.X - editor.Width / 2;
            x = LinX(x, editor.Width) + 1;
            float y = editor.Height / 2 - e.Y;
            y = LinY(y, editor.Height);
            cur_info.Text = "x = " + x.ToString() + " | y = " + y.ToString();
        }

        private float LinX(float x, int b)
        {
            return 2 * (x / b) - 1;
        }

        private float LinY(float y, float max)
        {
            return 2 * (y / max);
        }

        private void rb_axis_x_CheckedChanged(object sender, EventArgs e)
        {
            rotation_figure.rotation_axis = AXIS_TYPE.X;
            rotation_figure.Build();
            DrawAll();
        }

        private void rb_axis_y_CheckedChanged(object sender, EventArgs e)
        {
            rotation_figure.rotation_axis = AXIS_TYPE.Y;
            rotation_figure.Build();
            DrawAll();
        }

        private void rb_axis_z_CheckedChanged(object sender, EventArgs e)
        {
            rotation_figure.rotation_axis = AXIS_TYPE.Z;
            rotation_figure.Build();
            DrawAll();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            rotation_figure.SetIndexActiveMesh(cb_active_mesh.SelectedIndex);
            if (rotation_figure.PointCount > 0) DrawAll();
        }

        private void count_partition_KeyPress(object sender, KeyPressEventArgs e)
        {
            char el = e.KeyChar;
            if (!Char.IsDigit(el) && el != (char)Keys.Back) // можно вводить только цифры и стирать
                e.Handled = true;
        }

        private void count_partition_TextChanged(object sender, EventArgs e)
        {
            if (rotation_figure.PointCount > 0)
            {
                int divisions = count_partition.Text == "" ? 1 : Int32.Parse(count_partition.Text);
                rotation_figure.SetDivisionsCount(divisions);
                rotation_figure.Build();
                DrawAll();
            }

        }

        private void btn_save_model_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.Filter = "Text Files(*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStorage.ExportModel(saveFileDialog1.FileName, _objects.Last());
            }
        }

        private void btn_load_model_Click(object sender, EventArgs e)
        {
            OpenFileDialog saveFileDialog1 = new OpenFileDialog();
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.Filter = "Text Files(*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imported_model = FileStorage.ImportModel(saveFileDialog1.FileName);
                comboBox1.SelectedIndex = 6;
                _objects = new List<Object3D> { GetObject(comboBox1.SelectedIndex) };
                edit_object = _objects.Last();
                DrawAll();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Chart" || comboBox1.SelectedItem.ToString() == "ChartFH")
            {
                comboBox_func.Visible = true;
                comboBox_func.SelectedIndex = 0;
                groupBox_chart.Visible = true;
            }
            else
            {
                comboBox_func.Visible = false;
                groupBox_chart.Visible = false;
            }
        }

        private List<Triangle3D> GetTriangleschart()
        {
            List<Triangle3D> newTrianglesChart = new List<Triangle3D>();
            Func<float, float, float> func;

            switch (comboBox_func.SelectedItem.ToString())
            {
                case "sin(x, y)":
                    func = (x, y) => (float)Math.Sin(x + y);
                    break;
                case "x^2 + y^2":
                    func = (x, y) => x * x + y * y;
                    break;
                case "1 / (x^2 + y^2)":
                    func = (x, y) => 1 / (x * x + y * y);
                    break;
                default:
                    func = (x, y) => x + y;
                    break;
            }

            // ВЫЧИСЛЕНИЕ КООРДИНАТ ГРАФИКА

            // Парсим промт для x и y
            var x0 = float.Parse(numericUpDown_x1.Text);
            var x1 = float.Parse(numericUpDown_x2.Text);
            var y0 = float.Parse(numericUpDown_y1.Text);
            var y1 = float.Parse(numericUpDown_y2.Text);
            var delta = float.Parse(textBox_step.Text);
            int count_x = (int)((x1 - x0) / delta);
            int count_y = (int)((y1 - y0) / delta);

            float[,] z_values = new float[count_x + 1, count_y + 1];


            // Вычисляем точки функции
            for (int i = 0; i < count_x + 1; i++)
            {
                for (int j = 0; j < count_y + 1; j++)
                {
                    float x = x0 + i * delta;
                    float y = y0 + j * delta;
                    z_values[i, j] = func(x, y);
                }
            }

            // СОЗДАНИЕ ТРЕУГОЛЬНИКОВ
            for (int i = 0; i < count_x; i++)
            {
                for (int j = 0; j < count_y; j++)
                {
                    float xx1 = x0 + i * delta;
                    float xx2 = x0 + (i + 1) * delta;
                    float yy1 = y0 + j * delta;
                    float yy2 = y0 + (j + 1) * delta;


                    Vector4 v1 = new Vector4(xx1, yy1, z_values[i, j]);
                    Vector4 v2 = new Vector4(xx2, yy1, z_values[i + 1, j]);
                    Vector4 v3 = new Vector4(xx1, yy2, z_values[i, j + 1]);
                    Vector4 v4 = new Vector4(xx2, yy2, z_values[i + 1, j + 1]);
                    newTrianglesChart.Add(new Triangle3D(v1, v2, v3, Color.Black)); // Первый треугольник
                    newTrianglesChart.Add(new Triangle3D(v2, v3, v4, Color.Black)); // Второй треугольник
                }
            }


            return newTrianglesChart;
        }

        private void Task1_KeyDown(object sender, KeyEventArgs e)
        {

            const float camera_speed = 0.05f;
            //клавиша i
            if (e.KeyValue == 73)
            {
                cb_interactive_mode.Checked = !cb_interactive_mode.Checked;
            }
            if (_interactive_mode)
            {
                //клавиша w
                if (e.KeyValue == 87)
                {
                    camera_pos += camera_speed * camera_front;
                    input_info.Text = "W";
                }
                //клавиша a
                if (e.KeyValue == 65)
                {
                    camera_pos -= Vector4.Normalize(Vector4.CrossProduct(camera_front, camera_up)) * camera_speed;
                    input_info.Text = "A";
                }
                //клавиша s
                if (e.KeyValue == 83)
                {
                    camera_pos -= camera_speed * camera_front;
                    input_info.Text = "S";
                }
                //клавиша d
                if (e.KeyValue == 68)
                {
                    camera_pos += Vector4.Normalize(Vector4.CrossProduct(camera_front, camera_up)) * camera_speed;
                    input_info.Text = "D";
                }
                //клавиша esc
                if (e.KeyValue == 27)
                {
                    cb_interactive_mode.Checked = false;
                }
                view_matrix = Matrix3D.LookAt(camera_pos, camera_pos + camera_front, camera_up);
                DrawAll();
                //Console.WriteLine(e.KeyValue);
            }
        }
        Point fixed_pos;
        private void cb_interactive_mode_CheckedChanged(object sender, EventArgs e)
        {
            _interactive_mode = (sender as CheckBox).Checked;
            Capture = _interactive_mode;

            if (!_interactive_mode)
            {
                mouse_info.Text = "мышь";
                input_info.Text = "ввод";
            }
            else
            {
                fixed_pos = Cursor.Position;
                lastX = 525;
                lastY = 300;
            }
        }
        private void Task1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_interactive_mode)
            {
                float xpos = Cursor.Position.X;
                float ypos = Cursor.Position.Y;

                float xoffset = xpos - fixed_pos.X;
                float yoffset = fixed_pos.Y - ypos;

                Cursor.Position = fixed_pos;

                const float sensitivity = 0.1f;
                xoffset *= sensitivity;
                yoffset *= sensitivity;

                yaw -= xoffset;
                pitch += yoffset;

                if (pitch > 89.0f) pitch = 89.0f;
                if (pitch < -89.0f) pitch = -89.0f;

                Vector4 direction = new Vector4();

                float ryaw = Matrix3D.ToRadians(yaw);
                float rpitch = Matrix3D.ToRadians(pitch);
                direction.x = (float)(Math.Cos(ryaw) * Math.Cos(rpitch));
                direction.y = (float)Math.Sin(rpitch);
                direction.z = (float)(Math.Sin(ryaw) * Math.Cos(rpitch));
                camera_front = Vector4.Normalize(direction);

                mouse_info.Text = "x = " + xpos + " | y = " + ypos;
                view_matrix = Matrix3D.LookAt(camera_pos, camera_pos + camera_front, camera_up);
                DrawAll();

            }
        }

        private void btn_back_face_culling_CheckedChanged(object sender, EventArgs e)
        {
            back_face_culling = btn_back_face_culling.Checked;
            if (back_face_culling)
            {
                zbuffer = !btn_back_face_culling.Checked;
                btn_zbuffer.Checked = !btn_back_face_culling.Checked;
                lightning = !btn_back_face_culling.Checked;
                cb_lightning.Checked = !btn_back_face_culling.Checked;
            }
            DrawAll();
        }

        private void Task1_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (_interactive_mode)
            {
                _interactive_mode = false;
                cb_interactive_mode.Checked = false;
            }
        }

        private void btn_zbuffer_CheckedChanged(object sender, EventArgs e)
        {
            zbuffer = btn_zbuffer.Checked;
            if (zbuffer)
            {
                back_face_culling = !btn_zbuffer.Checked;
                btn_back_face_culling.Checked = !btn_zbuffer.Checked;
                lightning = !btn_zbuffer.Checked;
                cb_lightning.Checked = !btn_zbuffer.Checked;
            }
            DrawAll();
        }

        private void ClearZbuffer()
        {
            for (int i = 0; i < arrzbuffer.Count(); i++)
            {
                arrzbuffer[i] = Int32.MinValue;
            }
        }

        private void btn_clear_zbuff_Click(object sender, EventArgs e)
        {
            ClearZbuffer();
        }

        private void btn_add_obj_Click(object sender, EventArgs e)
        {
            OpenFileDialog saveFileDialog1 = new OpenFileDialog();
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.Filter = "Text Files(*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imported_model = FileStorage.ImportModel(saveFileDialog1.FileName);
                string file_name = saveFileDialog1.FileName.Split('\\').Last();
                imported_model.obj_name = file_name.Substring(0, file_name.Length - 4);
                _objects_loaded.Add(imported_model);
                scene_list.Items.Add(imported_model);
                DrawAll();
            }
        }

        private void btn_delete_obj_Click(object sender, EventArgs e)
        {
            if (scene_list.SelectedItems.Count > 0)
            {
                foreach (Object3D item in scene_list.SelectedItems)
                {
                    _objects_loaded.Remove(item);
                }
                scene_list.Items.Clear();
                foreach (var item in _objects_loaded)
                {
                    scene_list.Items.Add(item);
                }
                DrawAll();
            }
        }

        private void btn_hide_obj_Click(object sender, EventArgs e)
        {
            if (scene_list.SelectedItems.Count > 0)
            {
                foreach (Object3D item in scene_list.SelectedItems)
                {
                    if (_objects.Contains(item)) _objects.Remove(item);
                    else _objects.Add(item);
                }
                DrawAll();
            }
        }

        private void scene_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (scene_list.SelectedItems.Count == 1)
            {
                edit_object = scene_list.SelectedItems[0] as Object3D;
            }
            else edit_object = null;
        }

        private void cb_lightning_CheckedChanged(object sender, EventArgs e)
        {
            lightning = cb_lightning.Checked;
            if (lightning)
            {
                zbuffer = !cb_lightning.Checked;
                btn_zbuffer.Checked = !cb_lightning.Checked;
                back_face_culling = !cb_lightning.Checked;
                btn_back_face_culling.Checked = !cb_lightning.Checked;

            }
            DrawAll();
        }

        private void btn_move_light_pos_Click(object sender, EventArgs e)
        {
            Vector4 offset = new Vector4();
            if (light_x.Text != "") offset.x = Int32.Parse(light_x.Text);
            if (light_y.Text != "") offset.y = Int32.Parse(light_y.Text);
            if (light_z.Text != "") offset.z = Int32.Parse(light_z.Text);
            light_source += offset;
            light_info.Text = light_source.ToString();
            DrawAll();

        }

        private void cb_light_cull_back_CheckedChanged(object sender, EventArgs e)
        {
            render.cull_backfaces = cb_light_cull_back.Checked;
            DrawAll();
        }

        private void cb_light_zbuff_CheckedChanged(object sender, EventArgs e)
        {
            render.zbuffer = cb_light_zbuff.Checked;
            DrawAll();
        }

        private void DrawChartFH()
        { 
            Graphics chartGraphics = canvas.CreateGraphics();
            chartFH.Draw(chartGraphics, functions[comboBox_func.SelectedIndex]);
        }

        private void trackBarX_ValueChanged(object sender, EventArgs e)
        {
            chartFH.SetAngleX(trackBarX.Value);
            DrawChartFH();
        }

        private void trackBarY_ValueChanged(object sender, EventArgs e)
        {
            chartFH.SetAngleY(trackBarY.Value);
            DrawChartFH();
        }

        private void trackBarZ_ValueChanged(object sender, EventArgs e)
        {
            chartFH.SetAngleZ(trackBarZ.Value);
            DrawChartFH();
        }
    }
}
