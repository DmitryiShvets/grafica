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

namespace blank
{
    public partial class Task1 : Form
    {
        private Bitmap _bitmap;
        private Graphics _graphics;
        private List<Triangle3D> _triangles;
        private List<Triangle3D> _triangles_proj;

        private Matrix3D.PROJECTION_TYPE g_projection_type = Matrix3D.PROJECTION_TYPE.ORTHO_Z_PLUS;

        public Task1()
        {
            InitializeComponent();

            _bitmap = new Bitmap(canvas.Width, canvas.Height);
            _graphics = Graphics.FromImage(_bitmap);
            _graphics.Clear(Color.White);
            canvas.Image = _bitmap;
            _triangles = new List<Triangle3D>
            {
                new Triangle3D(new Vector4(100, 100, 1), new Vector4(100, 10, 1), new Vector4(10, 10, 1))
            };
            _triangles_proj = new List<Triangle3D>
            {
                new Triangle3D(new Vector4(0, 40, 0), new Vector4(0, 0, 40), new Vector4(0, 0, 0)),
                new Triangle3D(new Vector4(0, 40, 0), new Vector4(0, 40, 40), new Vector4(0, 0, 40))
            };
        }

        Matrix3D view_matrix = Matrix3D.LookAt(new Vector4(0, 0, 1), new Vector4(0, 0, 0), new Vector4(0, 1, 0));
        Transform transform = new Transform(new Vector4(10, 5, 50), new Vector4(0, 0, 0), new Vector4(1, 1, 1));

        Matrix3D projection_matrix = Matrix3D.GetProjectionMatrix(60.0f, 1, 0.1f, 100.0f);

        private void DrawAll()
        {   _graphics.Clear(Color.White);
            DrawAxes();

            foreach (var triangle in _triangles)
            {
                DrawTriangle(triangle);
            }

            foreach (var triangle in _triangles_proj)
            {
                DrawTriangleP(triangle);
            }
            canvas.Image = _bitmap;
            canvas.Invalidate();


        }


        private void DrawTriangleP(Triangle3D triangle)
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

            Matrix3D ortho_v0 = Matrix3D.GetOrtho(g_projection_type) * view_v0;
            Matrix3D ortho_v1 = Matrix3D.GetOrtho(g_projection_type) * view_v1;
            Matrix3D ortho_v2 = Matrix3D.GetOrtho(g_projection_type) * view_v2;

            //ortho_v0 /= ortho_v0[3, 0];
            //ortho_v1 /= ortho_v1[3, 0];
            //ortho_v2 /= ortho_v2[3, 0];

            Vector4 a = new Vector4(ortho_v0[2, 0], ortho_v0[1, 0], ortho_v0[3, 0]);
            Vector4 b = new Vector4(ortho_v1[2, 0], ortho_v1[1, 0], ortho_v0[3, 0]);
            Vector4 c = new Vector4(ortho_v2[2, 0], ortho_v2[1, 0], ortho_v0[3, 0]);

            //a *= 1.0f / a.z;
            //b *= 1.0f / b.z;
            //c *= 1.0f / c.z;

            Matrix3D viewport_matrix = Matrix3D.GetViewPortMatrix(1, 1, canvas.Width / 2, canvas.Height / 2);

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
            cur_info.Text += a.ToString();
            cur_info.Text += "canv c\n";
            cur_info.Text += canvas_v0.ToString();

            points[0] = canvas_v0.ToVector4().ToPointF();
            points[1] = canvas_v1.ToVector4().ToPointF();
            points[2] = canvas_v2.ToVector4().ToPointF();
            points[3] = canvas_v0.ToVector4().ToPointF();

            _graphics.DrawLines(new Pen(Color.Black), points);

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
                        DrawAxis(x0, x1,AXIS_TYPE.X ,"+Z","-Z", Color.Red);
                        DrawAxis(y0, y1, AXIS_TYPE.Y , "-Y", "+Y", Color.Blue);
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
          
            // DrawAxis(z0, z1, 'z', Color.Green);

        }

        private void DrawAxis(PointF a, PointF b,AXIS_TYPE axis_type , string axis_name_n, string axis_name_p, Color color)
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
        private void DrawTriangle(Triangle3D triangle)
        {
            PointF[] points = new PointF[4];

            points[0] = triangle[0].ToPointF();
            points[1] = triangle[1].ToPointF();
            points[2] = triangle[2].ToPointF();
            points[3] = triangle[0].ToPointF();

            _graphics.DrawLines(new Pen(Color.Blue), points);

        }


        private void Task1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawAll();
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
    }
}
