using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Laba5
{
    public partial class Paint : UserControl
    {
        private Bitmap _bitmap;
        private Graphics _graphics;
        private PointArray _points = new PointArray(2);

        private Pen pen_default = new Pen(Color.Black, 3f);
        private Pen pen_second = new Pen(Color.Yellow, 3f);
        private Pen pen_eraser = new Pen(Color.White, 3f);

        private State g_state = State.PEN;
        private bool is_drawing = false;

        public Paint()
        {
            InitializeComponent();
            _bitmap = new Bitmap(canvas.Width, canvas.Height);
            _graphics = Graphics.FromImage(_bitmap);
            _graphics.Clear(Color.White);
            canvas.Image = _bitmap;

            pen_default.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen_default.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            pen_eraser.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen_eraser.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            UpdateUI();
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
                case State.PEN: btn_pen.Select(); break;
                case State.ERASER: btn_eraser.Select(); break;
            }
        }

        private void Draw(int x, int y, ref Pen pen)
        {
            _points.SetPoint(x, y);

            if (_points.Count() >= 2)
            {
                _graphics.DrawLines(pen, _points.Points);
                canvas.Image = _bitmap;
                canvas.Invalidate();
                _points.SetPoint(x, y);

            }
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

        private void btn_clear_Click(object sender, EventArgs e)
        {
            _graphics.Clear(Color.White);
            canvas.Invalidate();
            UpdateUI();
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            is_drawing = true;
            canvas.Cursor = Cursors.Cross;
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
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
                status.Text = _bitmap.GetPixel(e.X, e.Y).Name + _bitmap.GetPixel(e.X, e.Y).ToString();
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            is_drawing = false;
            _points.Clear();
            canvas.Cursor = Cursors.Arrow;
        }

        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {

            if (g_state == State.PEN)
            {
                if (e.Button == MouseButtons.Left) _graphics.FillRectangle(new SolidBrush(pen_default.Color), e.X, e.Y, with_bar.Value, with_bar.Value);
                if (e.Button == MouseButtons.Right) _graphics.FillRectangle(new SolidBrush(pen_second.Color), e.X, e.Y, with_bar.Value, with_bar.Value);
                canvas.Invalidate();
            }
          
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

        [Browsable(true)]
        public  string MyText
        {
            get => this.Text;
            set => this.Text = value;
        }

        [Browsable(true)]
        public  event EventHandler MyEvent
        {
            add => status.TextChanged += value;
            remove => status.TextChanged -= value;
        }
    }
}
