﻿using System;
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
        private Graphics _graphics;
        private List<Object3D> _objects;
        private int zoom = 1;

        private PROJECTION_TYPE g_projection_type = PROJECTION_TYPE.ORTHO_Z_PLUS;

        private Line rotation_line;

        public Task1()
        {
            InitializeComponent();

            _bitmap = new Bitmap(canvas.Width, canvas.Height);
            _graphics = Graphics.FromImage(_bitmap);
            _graphics.Clear(Color.White);
            AddAllObjects();
            comboBox1.SelectedIndex = 0;
            canvas.Image = _bitmap;
        }

        private void AddAllObjects()
        {
            comboBox1.Items.Add("Cube");
            comboBox1.Items.Add("Tetrahedron");
            comboBox1.Items.Add("Octahedron");
            comboBox1.Items.Add("Icosahedron");
            comboBox1.Items.Add("Dodecahedron");
        }

        private Transform GetTransform()
        {
            return new Transform(new Vector4(0, 0, 3), new Vector4(0, 0, 0), new Vector4(1, 1, 1), new Vector4(1, 1, 1));
        }

        Matrix3D view_matrix = Matrix3D.LookAt(new Vector4(0, 0, 1), new Vector4(0, 0, 0), new Vector4(0, 1, 0));

        Matrix3D projection_matrix = Matrix3D.GetProjectionMatrix(45.0f, 1.2f, 0.1f, 10.0f);

        private void DrawAll()
        {
            _graphics.Clear(Color.White);
            DrawAxes();

            foreach (var obj in _objects)
            {
                foreach (var triangle in obj.mech.faces)
                {
                    DrawTriangle(triangle, obj.transform);
                }
            }

            canvas.Image = _bitmap;
            canvas.Invalidate();

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
            PointF[] points = new PointF[4];

            Matrix3D model_v0 = transform.ApplyTransform(triangle[0]);
            Matrix3D model_v1 = transform.ApplyTransform(triangle[1]);
            Matrix3D model_v2 = transform.ApplyTransform(triangle[2]);

            vertex_a.Text = model_v0.ToString();
            vertex_b.Text = model_v1.ToString();
            vertex_c.Text = model_v2.ToString();

            Matrix3D view_m = view_matrix;
            //Matrix3D view_m = GetIdentityMatrix();


            Matrix3D view_v0 = view_m * model_v0;
            Matrix3D view_v1 = view_m * model_v1;
            Matrix3D view_v2 = view_m * model_v2;

            //view_v0 /= view_v0[3, 0];
            //view_v1 /= view_v1[3, 0];
            //view_v2 /= view_v2[3, 0];

            // Matrix3D projection_m = projection_matrix;
            Matrix3D projection_m = Matrix3D.GetProjectionMatrix1();

            Matrix3D ortho_v0 = projection_m * view_v0;
            Matrix3D ortho_v1 = projection_m * view_v1;
            Matrix3D ortho_v2 = projection_m * view_v2;

            //ortho_v0 /= ortho_v0[3, 0];
            //ortho_v1 /= ortho_v1[3, 0];
            //ortho_v2 /= ortho_v2[3, 0];


            Matrix3D viewport_matrix = Matrix3D.GetViewPortMatrix(zoom, zoom, canvas.Width / 2, canvas.Height / 2);
            //Matrix3D viewport_matrix = Matrix3D.GetIdentityMatrix();

            Matrix3D canvas_v0 = viewport_matrix * ortho_v0;
            Matrix3D canvas_v1 = viewport_matrix * ortho_v1;
            Matrix3D canvas_v2 = viewport_matrix * ortho_v2;

            canvas_v0 /= canvas_v0[3, 0];
            canvas_v1 /= canvas_v1[3, 0];
            canvas_v2 /= canvas_v2[3, 0];

            cur_info.Text = "model a\n";
            cur_info.Text += model_v0.ToString();
            cur_info.Text += "view a\n";
            cur_info.Text += view_v0.ToString();
            cur_info.Text += "ortho b\n";
            cur_info.Text += ortho_v0;
            cur_info.Text += "canv c\n";
            cur_info.Text += canvas_v0.ToString();

            points[0] = canvas_v0.ToVector4().ToPointF();
            points[1] = canvas_v1.ToVector4().ToPointF();
            points[2] = canvas_v2.ToVector4().ToPointF();
            points[3] = canvas_v0.ToVector4().ToPointF();

            _graphics.DrawLines(new Pen(triangle.color, 1.0f), points);
            //_graphics.DrawLines(new Pen(Color.Black, 1.0f), points);

        }

        private void DrawTriangleOrtho(Triangle3D triangle, Transform transform)
        {
            PointF[] points = new PointF[4];

            Matrix3D model_v0 = transform.ApplyTransform(triangle[0]);
            Matrix3D model_v1 = transform.ApplyTransform(triangle[1]);
            Matrix3D model_v2 = transform.ApplyTransform(triangle[2]);

            vertex_a.Text = model_v0.ToString();
            vertex_b.Text = model_v1.ToString();
            vertex_c.Text = model_v2.ToString();

            Matrix3D view_v0 = view_matrix * model_v0;
            Matrix3D view_v1 = view_matrix * model_v1;
            Matrix3D view_v2 = view_matrix * model_v2;

            Matrix3D projection_m = Matrix3D.GetOrtho(g_projection_type);
            // Matrix3D projection_m = projection_matrix;

            Matrix3D ortho_v0 = projection_m * view_v0;
            Matrix3D ortho_v1 = projection_m * view_v1;
            Matrix3D ortho_v2 = projection_m * view_v2;

            //ortho_v0 /= ortho_v0[2, 0];
            //ortho_v1 /= ortho_v1[2, 0];
            //ortho_v2 /= ortho_v2[2, 0];

            //Vector4 a = new Vector4(ortho_v0[2, 0], ortho_v0[1, 0], ortho_v0[3, 0]);
            //Vector4 b = new Vector4(ortho_v1[2, 0], ortho_v1[1, 0], ortho_v0[3, 0]);
            //Vector4 c = new Vector4(ortho_v2[2, 0], ortho_v2[1, 0], ortho_v0[3, 0]);

            //a *= 1.0f / a.z;
            //b *= 1.0f / b.z;
            //c *= 1.0f / c.z;

            Matrix3D viewport_matrix = Matrix3D.GetViewPortMatrix(zoom, zoom, canvas.Width / 2, canvas.Height / 2);

            Matrix3D canvas_v0 = viewport_matrix * ortho_v0.ToVector3(g_projection_type);
            Matrix3D canvas_v1 = viewport_matrix * ortho_v1.ToVector3(g_projection_type);
            Matrix3D canvas_v2 = viewport_matrix * ortho_v2.ToVector3(g_projection_type);

            //canvas_v0 /= canvas_v0[3, 0];
            //canvas_v1 /= canvas_v1[3, 0];
            //canvas_v2 /= canvas_v2[3, 0];

            cur_info.Text = "model a\n";
            cur_info.Text += model_v0.ToString();
            cur_info.Text += "view a\n";
            cur_info.Text += view_v0.ToString();
            cur_info.Text += "ortho b\n";
            cur_info.Text += ortho_v0;
            cur_info.Text += "canv c\n";
            cur_info.Text += canvas_v0.ToString();

            points[0] = canvas_v0.ToVector4().ToPointF();
            points[1] = canvas_v1.ToVector4().ToPointF();
            points[2] = canvas_v2.ToVector4().ToPointF();
            points[3] = canvas_v0.ToVector4().ToPointF();

            _graphics.DrawLines(new Pen(triangle.color, 1.0f), points);

        }

        private void DrawAxes()
        {
            float aspect_ration = Math.Abs(canvas.Height - canvas.Width) / 2;
            float max = Math.Max(canvas.Width, canvas.Height);
            PointF y0 = new PointF(canvas.Width / 2, 0);
            PointF y1 = new PointF(canvas.Width / 2, canvas.Height);

            PointF x0 = new PointF(0, canvas.Height / 2);
            PointF x1 = new PointF(canvas.Width, canvas.Height / 2);

            PointF z0 = new PointF(max - aspect_ration, 0);
            PointF z1 = new PointF(0 + aspect_ration, canvas.Height);

            switch (g_projection_type)
            {
                case PROJECTION_TYPE.ORTHO_X_PLUS:
                    {
                        DrawAxis(x0, x1, AXIS_TYPE.X, "+Z", "-Z", Color.Red);
                        DrawAxis(y0, y1, AXIS_TYPE.Y, "-Y", "+Y", Color.Blue);
                        break;
                    }
                case PROJECTION_TYPE.ORTHO_X_MINUS:
                    {
                        DrawAxis(x0, x1, AXIS_TYPE.X, "-Z", "+Z", Color.Red);
                        DrawAxis(y0, y1, AXIS_TYPE.Y, "-Y", "+Y", Color.Blue);
                        break;
                    }
                case PROJECTION_TYPE.ORTHO_Y_PLUS:
                    {
                        DrawAxis(x0, x1, AXIS_TYPE.X, "+X", "-X", Color.Red);
                        DrawAxis(y0, y1, AXIS_TYPE.Y, "-Z", "+Z", Color.Blue);
                        break;
                    }
                case PROJECTION_TYPE.ORTHO_Y_MINUS:
                    {
                        DrawAxis(x0, x1, AXIS_TYPE.X, "-X", "+X", Color.Red);
                        DrawAxis(y0, y1, AXIS_TYPE.Y, "-Z", "+Z", Color.Blue);
                        break;
                    }
                case PROJECTION_TYPE.PERSPECTIVE:
                case PROJECTION_TYPE.ORTHO_Z_PLUS:
                    {
                        DrawAxis(x0, x1, AXIS_TYPE.X, "-X", "+X", Color.Red);
                        DrawAxis(y0, y1, AXIS_TYPE.Y, "-Y", "+Y", Color.Blue);
                        break;
                    }
                case PROJECTION_TYPE.ORTHO_Z_MINUS:
                    {
                        DrawAxis(x0, x1, AXIS_TYPE.X, "+X", "-X", Color.Red);
                        DrawAxis(y0, y1, AXIS_TYPE.Y, "-Y", "+Y", Color.Blue);
                        break;
                    }
            }

        }

        private void DrawAxis(PointF a, PointF b, AXIS_TYPE axis_type, string axis_name_n, string axis_name_p, Color color)
        {
            _graphics.DrawLine(new Pen(color), a, b);
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
                    return new Cube(GetTransform());
                case 1:
                    return new Tetrahedron(GetTransform());
                case 2:
                    return new Octahedron(GetTransform());
                case 3:
                    return new Icosahedron(GetTransform());
                case 4:
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
            int variant = comboBox1.SelectedIndex;
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
    }
}
