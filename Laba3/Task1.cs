using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using FastBitmaps;
using static System.Windows.Forms.AxHost;

namespace Laba3
{
    public partial class Task1 : Form
    {
        private Bitmap _bitmap;
        private Graphics _graphics;
        private PointArray _points = new PointArray(2);

        Pen pen_default = new Pen(Color.Black, 3f);
        Pen pen_filling = new Pen(Color.Black, 1f);
        Pen pen_eraser = new Pen(Color.White, 3f);

        private State g_state = State.PEN;
        private bool is_drawing = false;
        public Task1()
        {
            InitializeComponent();
            _bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            _graphics = Graphics.FromImage(_bitmap);
            _graphics.Clear(Color.White);
            pictureBox1.Image = _bitmap;

            pen_default.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen_default.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            pen_eraser.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen_eraser.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }
        enum State
        {
            NONE,
            FILLING,
            PEN,
            ERASER
        }

        private void Task1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            is_drawing = true;
            pictureBox1.Cursor = Cursors.Cross;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            is_drawing = false;
            _points.Clear();
            pictureBox1.Cursor = Cursors.Arrow;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (is_drawing)
            {
                switch (g_state)
                {
                    case State.NONE:
                        break;
                    case State.FILLING:

                        break;
                    case State.PEN:
                        Draw(e.X, e.Y, ref pen_default);
                        break;
                    case State.ERASER:
                        Draw(e.X, e.Y, ref pen_eraser);
                        break;
                }

            }
            {
                label1.Text = _bitmap.GetPixel(e.X, e.Y).ToString();
            }
        }

        private class PointArray
        {
            private int index = 0;
            private Point[] points;

            public Point[] Points { get => points; }

            public PointArray(int points_count)
            {
                if (points_count <= 0) points_count = 2;
                points = new Point[points_count];
            }

            public void SetPoint(int x, int y)
            {
                if (index >= points.Length)
                {
                    index = 0;
                }
                points[index] = new Point(x, y);
                index++;
            }

            public void Clear()
            {
                index = 0;
            }

            public int Count()
            {
                return index;
            }
        }

        private void Draw(int x, int y, ref Pen pen)
        {
            _points.SetPoint(x, y);

            if (_points.Count() >= 2)
            {
                _graphics.DrawLines(pen, _points.Points);
                pictureBox1.Image = _bitmap;
                // pictureBox1.Invalidate();
                _points.SetPoint(x, y);

            }
        }

        private void Fill(int x_start, int y_start)
        {
            int width = _bitmap.Width;
            int height = _bitmap.Height;

            Stack<Point> stack = new Stack<Point>();
            stack.Push(new Point(x_start, y_start));

            while (stack.Count > 0)
            {
                Point currentPoint = stack.Pop();
                int x = currentPoint.X;
                int y = currentPoint.Y;

                // Проверяем, что текущая точка внутри границ изображения
                if (x < 0 || x >= width || y < 0 || y >= height)
                    continue;
                int leftBoundary = x;
                int rightBoundary = x;

                using (var fastBitmap = new FastBitmap(_bitmap))
                {

                    // Получаем цвет текущей точки
                    Color currentColor = fastBitmap[x, y];

                    // Проверяем, что текущая точка не была уже закрашена и имеет нужный цвет
                    if (currentColor.Name == "ff000000" || currentColor == pen_filling.Color)
                        continue;

                    // Находим левую и правую границу
                    while (leftBoundary >= 0 && fastBitmap[leftBoundary, y].Name != "ff000000")
                        leftBoundary--;

                    while (rightBoundary < width && fastBitmap[rightBoundary, y].Name != "ff000000")
                        rightBoundary++;
                }
                //Рисуем линию от левой границы до правой границы(не включая границы)
                _graphics.DrawLine(pen_filling, leftBoundary, y, rightBoundary, y);
                int size = Convert.ToInt32(pen_filling.Width);
               // int size = 1;
                using (var fastBitmap = new FastBitmap(_bitmap))
                {
                    // Помещаем соседние точки в стек для последующей обработки
                    for (int i = leftBoundary + 1; i < rightBoundary; i++)
                    {

                        if (y < height - size && fastBitmap[i, y + size].Name != "ff000000"
                            && fastBitmap[i, y + size] != pen_filling.Color)
                            stack.Push(new Point(i, y + size)); // Ниже текущей точки

                        if (y > 0 + size && fastBitmap[i, y - size].Name != "ff000000"
                            && fastBitmap[i, y - size] != pen_filling.Color)
                            stack.Push(new Point(i, y - size)); // Выше текущей точки
                    }
                }
            }
        }



        private void btn_pen_Click(object sender, EventArgs e)
        {
            g_state = State.PEN;
        }

        private void btn_eraser_Click(object sender, EventArgs e)
        {
            g_state = State.ERASER;
        }

        private void btn_filling_Click(object sender, EventArgs e)
        {
            g_state = State.FILLING;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            g_state = State.PEN;
            _graphics.Clear(Color.White);
            pictureBox1.Invalidate();
        }

        private void with_bar_ValueChanged(object sender, EventArgs e)
        {
            pen_default.Width = (sender as TrackBar).Value;
            pen_eraser.Width = (sender as TrackBar).Value;
        }

        private void btn_color_Click(object sender, EventArgs e)
        {
            Button button = (sender as Button);
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            pen_default.Color = colorDialog1.Color;
            pen_filling.Color = colorDialog1.Color;
            button.BackColor = colorDialog1.Color;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (g_state == State.FILLING)
            {
                Fill(e.X, e.Y);
                pictureBox1.Image = _bitmap;
                //    pictureBox1.Invalidate();
            }
        }
    }
}
