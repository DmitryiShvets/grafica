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
        private Bitmap _image_filling;
        private Graphics _graphics;
        private PointArray _points = new PointArray(2);

        private Pen pen_default = new Pen(Color.Black, 1f);
        private Pen pen_second = new Pen(Color.Yellow, 1f);
        private Pen pen_filling = new Pen(Color.Black, 1f);
        private Pen pen_eraser = new Pen(Color.White, 1f);

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

            UpdateUI();
        }

        private void Task1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void Draw(int x, int y, ref Pen pen)
        {
            _points.SetPoint(x, y);

            if (_points.Count() >= 2)
            {
                _graphics.DrawLines(pen, _points.Points);
                pictureBox1.Image = _bitmap;
                pictureBox1.Invalidate();
                _points.SetPoint(x, y);

            }
        }

        private void Fill(int x_start, int y_start, Color target)
        {
            int width = _bitmap.Width;
            int height = _bitmap.Height;

            pen_filling.Color = target;
            int offset = Convert.ToInt32(pen_filling.Width);

            Stack<Point> stack = new Stack<Point>();
            stack.Push(new Point(x_start, y_start));

            while (stack.Count > 0)
            {
                Point currentPoint = stack.Pop();
                int x = currentPoint.X;
                int y = currentPoint.Y;

                if (x < 0 || x >= width || y < 0 || y >= height)
                    continue;
                int leftBoundary = x;
                int rightBoundary = x;

                using (var fastBitmap = new FastBitmap(_bitmap))
                {

                    Color currentColor = fastBitmap[x, y];

                    if (is_equal(currentColor, target) || is_equal(currentColor, Color.Black))
                        continue;

                    while (leftBoundary >= 0 && !is_equal(fastBitmap[leftBoundary, y], Color.Black))
                        leftBoundary--;

                    while (rightBoundary < width && !is_equal(fastBitmap[rightBoundary, y], Color.Black))
                        rightBoundary++;
                }
                _graphics.DrawLine(pen_filling, leftBoundary + 1, y, rightBoundary - 1, y);

                using (var fastBitmap = new FastBitmap(_bitmap))
                {
                    for (int i = leftBoundary + 1; i < rightBoundary; i++)
                    {
                        if (y < height - offset && !is_equal(fastBitmap[i, y + offset], Color.Black)
                            && !is_equal(fastBitmap[i, y + offset], target))
                            stack.Push(new Point(i, y + offset));

                        if (y > 0 + offset && !is_equal(fastBitmap[i, y - offset], Color.Black)
                            && !is_equal(fastBitmap[i, y - offset], target))
                            stack.Push(new Point(i, y - offset));
                    }
                }
            }
        }

        private void FillImage(int x_start, int y_start)
        {
            int width = _bitmap.Width;
            int height = _bitmap.Height;

            int offset = 1;

            bool[,] visited = new bool[width, height];
            Stack<Point> stack = new Stack<Point>();
            stack.Push(new Point(x_start, y_start));

            using (var fbm_paint = new FastBitmap(_bitmap))
            {
                using (var fbm_pattern = new FastBitmap(_image_filling))
                {
                    while (stack.Count > 0)
                    {
                        Point currentPoint = stack.Pop();
                        int x = currentPoint.X;
                        int y = currentPoint.Y;

                        if (x < 0 || x >= width || y < 0 || y >= height || visited[x, y])
                            continue;
                        int leftBoundary = x;
                        int rightBoundary = x;

                        Color currentColor = fbm_paint[x, y];

                        if (is_equal(currentColor, Color.Black)) continue;

                        while (leftBoundary >= 0 && !is_equal(fbm_paint[leftBoundary, y], Color.Black))
                            leftBoundary--;

                        while (rightBoundary < width && !is_equal(fbm_paint[rightBoundary, y], Color.Black))
                            rightBoundary++;
                        for (int i = leftBoundary + 1; i < rightBoundary; i++)
                        {

                            int patternX = i  % fbm_pattern.Width;
                            int patternY = y  % fbm_pattern.Height;
                            Color patternColor = fbm_pattern[patternX, patternY];
                            if(patternColor.Name == "0") patternColor= Color.White;
                            fbm_paint[i, y] = patternColor;
                            visited[i, y] = true;

                            if (y < height - offset && !is_equal(fbm_paint[i, y + offset], Color.Black)
                                && !visited[i, y + offset])
                                stack.Push(new Point(i, y + offset));

                            if (y > 0 && !is_equal(fbm_paint[i, y - offset], Color.Black)
                                && !visited[i, y - offset])
                                stack.Push(new Point(i, y - offset));


                        }

                    }
                }
            }
        }

        private Rectangle FindBlackBoundaries(Bitmap image, Color targetColor)
        {
            // Реализуйте ваш алгоритм определения границ
            // Возвращайте прямоугольник, описывающий границы черного цвета
            // Примерно так:
            int left = 0, top = 0, right = image.Width, bottom = image.Height;
            using (var fastBitmap = new FastBitmap(_bitmap))
            {
                for (int x = 0; x < image.Width; x++)
                {
                    for (int y = 0; y < image.Height; y++)
                    {
                        if (image.GetPixel(x, y) == targetColor)
                        {
                            left = Math.Min(left, x);
                            top = Math.Min(top, y);
                            right = Math.Max(right, x);
                            bottom = Math.Max(bottom, y);
                        }
                    }
                }
            }

            return new Rectangle(left, top, right - left + 1, bottom - top + 1);
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
                        if (e.Button == MouseButtons.Left) Draw(e.X, e.Y, ref pen_default);
                        if (e.Button == MouseButtons.Right) Draw(e.X, e.Y, ref pen_second);
                        break;
                    case State.ERASER:
                        Draw(e.X, e.Y, ref pen_eraser);
                        break;
                }

            }
            if (e.X >= 0 && e.X < _bitmap.Width && e.Y >= 0 && e.Y < _bitmap.Height)
            {
                label1.Text = _bitmap.GetPixel(e.X, e.Y).Name + _bitmap.GetPixel(e.X, e.Y).ToString();
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (g_state == State.FILLING)
            {
                if (e.Button == MouseButtons.Left) Fill(e.X, e.Y, pen_default.Color);
                if (e.Button == MouseButtons.Right) Fill(e.X, e.Y, pen_second.Color);

                pictureBox1.Image = _bitmap;
                pictureBox1.Invalidate();
            }
            if (g_state == State.PEN)
            {
                if (e.Button == MouseButtons.Left) _graphics.FillRectangle(new SolidBrush(pen_default.Color), e.X, e.Y, with_bar.Value, with_bar.Value);
                if (e.Button == MouseButtons.Right) _graphics.FillRectangle(new SolidBrush(pen_second.Color), e.X, e.Y, with_bar.Value, with_bar.Value);
                pictureBox1.Invalidate();
            }
            if (g_state == State.FILLING_IMAGE)
            {
                if (_image_filling != null)
                {
                    FillImage(e.X, e.Y);

                    pictureBox1.Image = _bitmap;
                    pictureBox1.Invalidate();
                }
            }
        }

        private bool is_equal(Color lhs, Color rhs)
        {
            return (lhs.R == rhs.R) && (lhs.G == rhs.G) && (lhs.B == rhs.B);
        }

        private void btn_pen_Click(object sender, EventArgs e)
        {
            g_state = State.PEN;
            UpdateUI();
        }

        private void btn_eraser_Click(object sender, EventArgs e)
        {
            g_state = State.ERASER;
            UpdateUI();
        }

        private void btn_filling_Click(object sender, EventArgs e)
        {
            g_state = State.FILLING;
            UpdateUI();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            _graphics.Clear(Color.White);
            pictureBox1.Invalidate();
            UpdateUI();

        }

        private void with_bar_ValueChanged(object sender, EventArgs e)
        {
            pen_default.Width = (sender as TrackBar).Value;
            pen_eraser.Width = (sender as TrackBar).Value;
            pen_second.Width = (sender as TrackBar).Value;
            UpdateUI();
        }

        private void btn_color_Click(object sender, EventArgs e)
        {
            Button button = (sender as Button);
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            pen_default.Color = colorDialog1.Color;
            button.BackColor = colorDialog1.Color;
            UpdateUI();
        }

        private void btn_color_2_Click(object sender, EventArgs e)
        {
            Button button = (sender as Button);
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            pen_second.Color = colorDialog1.Color;
            button.BackColor = colorDialog1.Color;
            UpdateUI();
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

        enum State
        {
            NONE,
            FILLING,
            FILLING_IMAGE,
            FILLING_BORDER,
            PEN,
            ERASER
        }

        private void UpdateUI()
        {
            switch (g_state)
            {
                case State.NONE: btn_clear.Select(); break;
                case State.FILLING: btn_filling.Select(); break;
                case State.FILLING_IMAGE: btn_filling_image.Select(); break;
                case State.FILLING_BORDER: btn_filling_border.Select(); break;
                case State.PEN: btn_pen.Select(); break;
                case State.ERASER: btn_eraser.Select(); break;
            }
        }

        private void btn_filling_image_Click(object sender, EventArgs e)
        {
            g_state = State.FILLING_IMAGE;
            UpdateUI();

        }

        private void btn_filling_border_Click(object sender, EventArgs e)
        {
            g_state = State.FILLING_BORDER;
            UpdateUI();

        }

        private void btn_load_image_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG|All files (*.*)|*.*";

            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _image_filling = new Bitmap(open_dialog.FileName);
                    filling_pix.Image = _image_filling;
                    filling_pix.Invalidate();
                }
                catch
                {
                    DialogResult result = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            UpdateUI();
        }
    }
}
