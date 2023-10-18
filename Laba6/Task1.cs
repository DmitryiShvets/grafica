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
namespace blank
{
    public partial class Task1 : Form
    {
        private Bitmap _bitmap;
        private Graphics _graphics;
        private List<Triangle3D> _triangles;
        private List<Triangle3D> _triangles_proj;
        private float aspect;
        public Task1()
        {
            InitializeComponent();

            _bitmap = new Bitmap(canvas.Width, canvas.Height);
            _graphics = Graphics.FromImage(_bitmap);
            _graphics.Clear(Color.White);
            canvas.Image = _bitmap;
            aspect = canvas.Height / canvas.Width;
            _triangles = new List<Triangle3D>
            {
                new Triangle3D(new Vector4(100, 100, 1), new Vector4(100, 10, 1), new Vector4(10, 10, 1))
            };
            _triangles_proj = new List<Triangle3D>
            {
                new Triangle3D(new Vector4(0, 4, 0), new Vector4(0, 0, 4), new Vector4(0, 0, 0)),
                new Triangle3D(new Vector4(0, 4, 0), new Vector4(0, 4, 4), new Vector4(0, 0, 4))
            };
        }

        Matrix3D view_matrix1 = Matrix3D.LookAt1(new Vector4(4, 3, 3), new Vector4(0, 0, 0), new Vector4(0, 1, 0));
        Matrix3D view_matrix = Matrix3D.LookAt(new Vector4(0, 0, -1), new Vector4(0, 0, 0), new Vector4(0, 1, 0));

        Matrix3D projection_matrix = Matrix3D.GetProjectionMatrix(60.0f, 1, 0.1f, 100.0f);

        private void DrawAll()
        {
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

        Transform transform = new Transform(new Vector4(0, 0, 5), new Vector4(0, 0, 0), new Vector4(1, 1, 1));

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

            Matrix3D ortho_v0 = Matrix3D.GetOrtho() * view_v0;
            Matrix3D ortho_v1 = Matrix3D.GetOrtho() * view_v1;
            Matrix3D ortho_v2 = Matrix3D.GetOrtho() * view_v2;

            //ortho_v0 /= ortho_v0[3, 0];
            //ortho_v1 /= ortho_v1[3, 0];
            //ortho_v2 /= ortho_v2[3, 0];

            Vector4 a = new Vector4(ortho_v0[1, 0], ortho_v0[2, 0], ortho_v0[3, 0]);
            Vector4 b = new Vector4(ortho_v1[1, 0], ortho_v1[2, 0], ortho_v0[3, 0]);
            Vector4 c = new Vector4(ortho_v2[1, 0], ortho_v2[2, 0], ortho_v0[3, 0]);

            a *= 1.0f / a.z;
            b *= 1.0f / b.z;
            c *= 1.0f / c.z;

            Matrix3D viewport_matrix = Matrix3D.GetViewPortMatrix(canvas.Width, canvas.Height, canvas.Width / 2, canvas.Height / 2);

            Matrix3D canvas_v0 = viewport_matrix * Matrix3D.GetVector4(a);
            Matrix3D canvas_v1 = viewport_matrix * Matrix3D.GetVector4(b);
            Matrix3D canvas_v2 = viewport_matrix * Matrix3D.GetVector4(c);

            //  canvas_v0 /= canvas_v0[3, 0];
            //   canvas_v1 /= canvas_v1[3, 0];
            //   canvas_v2 /= canvas_v2[3, 0];

            cur_info.Text = "model a\n";
            cur_info.Text += model_v0.ToString();
            cur_info.Text += "view a\n";
            cur_info.Text += view_v0.ToString();
            cur_info.Text += "ortho b\n";
            cur_info.Text += ortho_v0.ToString();
            cur_info.Text += "canv c\n";
            cur_info.Text += canvas_v0.ToString();

            points[0] = canvas_v0.ToVector4().ToPointF();
            points[1] = canvas_v1.ToVector4().ToPointF();
            points[2] = canvas_v2.ToVector4().ToPointF();
            points[3] = canvas_v0.ToVector4().ToPointF();



            _graphics.DrawLines(new Pen(Color.Red), points);

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
            Matrix3D model = Matrix3D.GetIdentityMatrix();
            //cur_info.Text = "model matrix\n";
            //cur_info.Text += model.ToString();
            //cur_info.Text += "view matrix\n";
            //cur_info.Text += view_matrix.ToString();
            //cur_info.Text += "view matrix1\n";
            //cur_info.Text += view_matrix1.ToString();
            //cur_info.Text += "projection matrix\n";
            //cur_info.Text += projection_matrix.ToString();


        }
    }
}
