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

namespace blank
{
    public partial class Task1 : Form
    {
        private Bitmap _bitmap;
        private Bitmap _bitmap_editor;
        private Graphics _graphics;
        private Graphics _graphics_editor;
        private List<Object3D> _objects;
        private int zoom = 1;
        private List<Vector4> editor_points;
        private PROJECTION_TYPE g_projection_type = PROJECTION_TYPE.ORTHO_Z_PLUS;
        private RotationFigure rotation_figure;
        public Task1()
        {
            InitializeComponent();

            _bitmap = new Bitmap(canvas.Width, canvas.Height);
            _bitmap_editor = new Bitmap(editor.Width, editor.Height);
            _graphics = Graphics.FromImage(_bitmap);
            _graphics_editor = Graphics.FromImage(_bitmap_editor);
            _graphics.Clear(Color.White);
            _graphics_editor.Clear(Color.White);
            rotation_figure = new RotationFigure(GetTransform());
            AddAllObjects();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

            canvas.Image = _bitmap;
            editor.Image = _bitmap_editor;

            editor_points = new List<Vector4>();

            _objects = new List<Object3D>
            {
                GetObject(0)
            };

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
        }

        private Transform GetTransform()
        {
            return new Transform(new Vector4(0, 0, 2), new Vector4(0, 0, 0), new Vector4(1, 1, 1), new Vector4(1, 1, 1));
        }

        Matrix3D view_matrix = Matrix3D.LookAt(new Vector4(0, 0, -1), new Vector4(0, 0, 0), new Vector4(0, -1, 0));

        Matrix3D projection_matrix = Matrix3D.GetProjectionMatrix(45.0f, 1.2f, 0.1f, 10.0f);

        private void DrawAll()
        {
            _graphics.Clear(Color.White);
            _graphics_editor.Clear(Color.White);
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
            if (g_projection_type == PROJECTION_TYPE.PERSPECTIVE)
            {
                DrawTrianglePerspective(triangle, transform);
            }
            else
            {
                DrawTriangleOrtho(triangle, transform);
            }
        }

        private void DrawTrianglePerspective(Triangle3D triangle, Transform transform)
        {
            List<PointF> points = new List<PointF>();
            Matrix3D viewport_matrix = Matrix3D.GetViewPortMatrix(zoom, zoom, canvas.Width / 2, canvas.Height / 2);

            for (int i = 0; i < triangle.Size; ++i)
            {
                Matrix3D model = transform.ApplyTransform(triangle[i]);
                if (model[2, 0] < 0) continue;
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
                e.Cancel = true;
                Hide();

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
            Vector4 offset = new Vector4();
            if (t_transform_dx.Text != "") offset.x = Int32.Parse(t_transform_dx.Text);
            if (t_transform_dy.Text != "") offset.y = Int32.Parse(t_transform_dy.Text);
            if (t_transform_dz.Text != "") offset.z = Int32.Parse(t_transform_dz.Text);
            _objects.Last().transform.Translate(offset);
            DrawAll();
        }

        private void btn_rotation_apply_Click(object sender, EventArgs e)
        {
            Vector4 offset = new Vector4();
            if (t_rotation_dx.Text != "") offset.x = Int32.Parse(t_rotation_dx.Text);
            if (t_rotation_dy.Text != "") offset.y = Int32.Parse(t_rotation_dy.Text);
            if (t_rotation_dz.Text != "") offset.z = Int32.Parse(t_rotation_dz.Text);
            _objects.Last().transform.Rotate(offset);
            DrawAll();
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
            }
            return new Cube(GetTransform());
        }

        private void btn_draw_Click(object sender, EventArgs e)
        {
            int variant = comboBox1.SelectedIndex;
            _objects = new List<Object3D>
            {
                GetObject(variant)
            };
            DrawAll();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            _objects.Clear();
            editor_points.Clear();
            //editor_points_mesh.Clear();
            int variant = comboBox1.SelectedIndex;
            rotation_figure = new RotationFigure(GetTransform());

            _objects = new List<Object3D>
            {
                GetObject(variant)
            };

            DrawAll();
        }

        private void track_zoom_ValueChanged(object sender, EventArgs e)
        {
            zoom = track_zoom.Value;
            DrawAll();
        }

        private void btn_scale_apply_Click(object sender, EventArgs e)
        {
            Vector4 offset = new Vector4();
            if (t_scale_dx.Text != "") offset.x = Int32.Parse(t_scale_dx.Text);
            if (t_scale_dy.Text != "") offset.y = Int32.Parse(t_scale_dy.Text);
            if (t_scale_dz.Text != "") offset.z = Int32.Parse(t_scale_dz.Text);
            _objects.Last().transform.Scale(offset);
            DrawAll();
        }

        private void btn_reflection_apply_Click(object sender, EventArgs e)
        {
            Vector4 offset = new Vector4(1, 1, 1);
            if (t_reflection_xy.Checked) offset.z *= -1;
            if (t_reflection_xz.Checked) offset.y *= -1;
            if (t_reflection_yz.Checked) offset.x *= -1;
            _objects.Last().transform.Reflection(offset);
            DrawAll();
        }

        private void btn_line_rotation_apply_Click(object sender, EventArgs e)
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

            _objects.Last().transform.RotateRelativeLine(point1, point2, angle);
            DrawAll();
        }

        private void editor_MouseClick(object sender, MouseEventArgs e)
        {
            float x = e.X - editor.Width / 2;
            float y = editor.Height / 2 - e.Y;
            int z = 0;

            editor_points.Add(new Vector4(x, y, z));

            x = LinX(x, editor.Width) + 1;
            y = LinY(y, editor.Height);
            rotation_figure.editor_points_mesh.Add(new Vector4(x, y, z));
            rotation_figure.BuildFormingMesh();
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
        }

        private void rb_axis_y_CheckedChanged(object sender, EventArgs e)
        {
            rotation_figure.rotation_axis = AXIS_TYPE.Y;
        }

        private void rb_axis_z_CheckedChanged(object sender, EventArgs e)
        {
            rotation_figure.rotation_axis = AXIS_TYPE.Z;
        }
    }
}
