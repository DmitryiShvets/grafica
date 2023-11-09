using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace blank
{
    public partial class GraphD : UserControl
    {

        private Graphics g;
        Pen pen_figure = new Pen(Color.Black, 3f);
        Pen pen_axes = new Pen(Color.Black, 1f);
        public GraphD()
        {
            InitializeComponent();
            comboBox1.Items.Add("sin(x)");
            comboBox1.Items.Add("x^2");
            comboBox1.Items.Add("1/x");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CanvasUpdate();
        }

        private void CanvasUpdate()
        {
            Func<float, float> func;
            switch (comboBox1.SelectedItem.ToString())
            {
                case "sin(x)":
                    func = x => (float)Math.Sin(x);
                    break;
                case "x^2":
                    func = x => x * x;
                    break;
                case "1/x":
                    func = x => 1 / x;
                    break;
                default:
                    func = x => x;
                    break;
            }
            Draw(func);
            label3.Text = "График: " + comboBox1.SelectedItem.ToString();
        }

        private void Draw(Func<float, float> function)
        {
            //очищаем буфер
            g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);

            //парсим промт
            var a = float.Parse(numericUpDown_x1.Text);
            var b = float.Parse(numericUpDown_x2.Text);
            var delta = 0.1f;
            int count = (int)((b - a) * 10);
            Console.WriteLine($"a = {a}, b = {b}");

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

        private float LinX(float x, float a, float b)
        {
            return (x - a) / (b - a) * pictureBox1.Width;
        }

        private float LinY(float y, float min, float max)
        {
            return (y - max) / (min - max) * pictureBox1.Height;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            CanvasUpdate();
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            CanvasUpdate();
        }
    }
}
