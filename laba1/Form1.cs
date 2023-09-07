using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba1
{
    public partial class Form1 : Form
    {
        private Graphics g;
        Pen pen_figure = new Pen(Color.Black, 3f);
        Pen pen_axes = new Pen(Color.Black, 1f);
        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.SelectedIndex=0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (listBox1.SelectedIndex)
            {
                case 0: Draw(Linear); break;
                case 1: Draw(Parabola); break;
                case 2: Draw(CubeParabola); break;
                case 3: Draw(Giperbola); break;
                case 4: Draw(Sin); break;
                case 5: Draw(Exponent); break;
                case 6: Draw(SinMinusX); break;
                case 7: Draw(Const2); break;
            }

        }

        private void Draw(Func<float, float> function)
        {
            //очищаем буфер
            g.Clear(Color.White);

            //парсим промт
            var a = float.Parse(textBox1.Text);
            var b = float.Parse(textBox2.Text);
            var delta = 0.1f;
            int count = (int)((b - a) * 10);


            float[] y_values = new float[count];

            float min = float.MaxValue;
            float max = float.MinValue;

            //вычисляем точки функции
            float x = a;
            for (int i = 0; i < y_values.Length; i++, x += delta)
            {
                y_values[i] = function(x);
                if (y_values[i] < min) min = y_values[i];
                if (y_values[i] > max) max = y_values[i];
            }

            //вычисляем графика
            PointF[] x_axes = { new PointF(LinX(a, a, b), LinY(0, min, max) - 0.5f), new PointF(LinX(b, a, b), LinY(0, min, max) - 0.5f) };
            PointF[] y_axes = { new PointF(LinX(0, a, b), LinY(max, min, max)), new PointF(LinX(0, a, b), LinY(min, min, max)) };
            PointF[] points = new PointF[count];

            //интерполяция точек
            x = a;
            for (int i = 0; i < points.Length; i++, x += delta)
            {
                points[i] = new PointF(LinX(x, a, b), LinY(y_values[i], min, max));
            }


            g.DrawLines(pen_axes, x_axes);
            g.DrawLines(pen_axes, y_axes);
            g.DrawLines(pen_figure, points);
        }

        private float Const2(float x) { return x + 2.0f; }
        private float SinMinusX(float x) { return Sin(x) - x; }

        private float Parabola(float x)
        {
            return x * x;
        }

        private float CubeParabola(float x)
        {
            return x * x * x;
        }

        private float Sin(float x)
        {
            return (float)Math.Sin(x);
        }

        private float Linear(float x) { return x; }

        private float Giperbola(float x)
        {
            return 1 / x;
        }

        private float Exponent(float x)
        {
            return (float)Math.Pow(Math.E, x);
        }

        private float LinX(float x, float a, float b)
        {
            return (x - a) / (b - a) * pictureBox1.Width;
        }

        private float LinY(float y, float min, float max)
        {
            return (y - max) / (min - max) * pictureBox1.Height;
        }
    }
}
