using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba3
{
    public partial class Task2 : Form
    {
        Point[] points = new Point[4];
        int point = 0;
        bool isPaint = true;
        bool isTracking = false;
        private Graphics g;
        Pen penLines = new Pen(Color.Black, 1f);
        Color[] colors = new Color[3];
        Pen pen = new Pen(Color.Black, 3f);
        Point point1 = new Point(0, 0);
        Point point2 = new Point(0, 0);
        public Task2()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            trackBar1.Value = 3;
            button_pen_color.BackColor = Color.Black;
        }

        private void button_drawTriangle_Click(object sender, EventArgs e)
        {
            //g.Clear(Color.White);
            g.DrawLines(penLines, points);
        }

        private void button_point_Click(object sender, EventArgs e)
        {
            Button button = (sender as Button);
            point = Convert.ToInt32(button.Name.Substring(button.Name.Length-1))-1;
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            button.BackColor = colorDialog1.Color;
            colors[point] = colorDialog1.Color;
            isPaint = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var mouse = e as MouseEventArgs;
            if (isPaint)
            {
                isTracking = !isTracking;
                point1 = new Point(mouse.X, mouse.Y);
            }
            else
            {
                Pen penC = new Pen(colors[point], 3f);
                g.DrawRectangle(penC, mouse.X, mouse.Y, 3, 3);
                if (point == 0)
                {
                    points[3] = new Point(mouse.X, mouse.Y);
                }
                points[point] = new Point(mouse.X, mouse.Y);
            }
        }

        private void button_gradient_Click(object sender, EventArgs e)
        {

        }

        private void button_pen_color_Click(object sender, EventArgs e)
        {
            Button button = (sender as Button);
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            pen.Color = colorDialog1.Color;
            //pen.Width = 3f;
            button.BackColor = colorDialog1.Color;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Cursor = Cursors.Hand;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Cursor = Cursors.Default;
            isTracking = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            point2 = point1;
            point1 = new Point(e.X, e.Y);
            if (isTracking)
            {
                g.DrawLine(pen, point1.X, point1.Y, point2.X, point2.Y);
                //Console.WriteLine($"point1: x={point1.X}, y={point1.Y}");
                //Console.WriteLine($"point2: x={point2.X}, y={point2.Y}\n");
                //g.DrawRectangle(pen, point1.X, point1.Y, pen.Width, pen.Width);
                //g.DrawEllipse(pen, point1.X, point1.Y, pen.Width, pen.Width);
                //g.FillRectangle(new SolidBrush(Color.Blue), point1.X, point1.Y, 1, 1);
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            pen.Width = (sender as TrackBar).Value;
        }

        private void button_choose_pen_Click(object sender, EventArgs e)
        {
            isPaint = true;
        }

        private void button_choose_cleaner_Click(object sender, EventArgs e)
        {
            isPaint = true;
            pen.Color = Color.White;
        }

        private void button_clean_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
        }

        private void Task3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();

            }
        }
    }
}
