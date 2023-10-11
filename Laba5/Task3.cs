﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace Laba5
{
    public partial class Task3 : Form
    {
        private List<VectorD> points;
        private int selectedPoint = -1;
        private bool isSelectedPoint = false;
        private STATE g_state = STATE.NONE;

        private Bitmap bitmap;
        private Graphics graphics;
        private Pen pen = new Pen(Color.Black, 3f);
        bool isButton = false;
        public Task3()
        {
            InitializeComponent();
            points = new List<VectorD>();
            label_state.Text = "NONE";
            bitmap = new Bitmap(canvas.Width, canvas.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            canvas.Image = bitmap;
        }

        private void Task3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        public VectorD GetPoint(float t)
        {
            int n = points.Count - 1;
            VectorD point = VectorD.Zero;
            for (int i = 0; i <= n; i++)
            {
                float blend = (float)BinomialCoefficient(n, i) * (float)Math.Pow(t, i) * (float)Math.Pow(1 - t, n - i);
                point += blend * points[i];
            }
            return point;
        }

        private decimal BinomialCoefficient(int n, int k)
        {
            if (k == 0 || k == n)
            {
                return 1;
            }

            decimal result = 1;
            for (int i = 1; i <= k; i++)
            {
                try
                {
                    result *= n - i + 1;
                    result /= i;
                }
                catch
                {
                    Console.WriteLine("Слишком много точек");
                }
            }

            return result;
        }
        
        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (g_state == STATE.ADDING_POINT)
            {
                points.Add(new VectorD(e.X, e.Y));
                textBox1.Text += "Добавлена точка" + Environment.NewLine;
                label_count.Text = points.Count().ToString();
                graphics.DrawEllipse(pen, e.X, e.Y, 2, 2);
                canvas.Invalidate();
                if (isButton)
                {
                    graphics.Clear(Color.White);
                    DrawPoints();
                    DrawCurve2();
                }
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
            canvas.Invalidate();
            points.Clear();
            textBox1.Text += "Точки очищены" + Environment.NewLine;
            label_count.Text = points.Count().ToString();
            ChangeState(STATE.NONE);
        }

        private void button_add_point_Click(object sender, EventArgs e)
        {
            ChangeState(STATE.ADDING_POINT);
        }

        private void button_delete_point_Click(object sender, EventArgs e)
        {
            ChangeState(STATE.DELETING_POINT);
        }

        private void button_move_point_Click(object sender, EventArgs e)
        {
            ChangeState(STATE.MOVING_POINT);
        }

        private enum STATE
        {
            NONE,                   // IDLE
            ADDING_POINT,           // состояние добавления точки
            DELETING_POINT,         // состояние удаления точки
            MOVING_POINT            // состояние перемещения точки
        }

        private void ChangeState(STATE newState)
        {
            if (newState == STATE.NONE)
            {
                g_state = STATE.NONE;
                label_state.Text = "NONE";
                button_add_point.BackColor = Color.FromArgb(255, 255, 255, 255);
                button_delete_point.BackColor = Color.FromArgb(255, 255, 255, 255);
                button_move_point.BackColor = Color.FromArgb(255, 255, 255, 255);
            }
            else if (newState == STATE.ADDING_POINT)
            {
                g_state = STATE.ADDING_POINT;
                label_state.Text = "Добавление точки";
                button_add_point.BackColor = Color.FromArgb(255, 0, 0, 0);
                button_delete_point.BackColor = Color.FromArgb(255, 255, 255, 255);
                button_move_point.BackColor = Color.FromArgb(255, 255, 255, 255);
            }
            else if (newState == STATE.DELETING_POINT)
            {
                g_state = STATE.DELETING_POINT;
                label_state.Text = "Удаление точки";
                button_add_point.BackColor = Color.FromArgb(255, 255, 255, 255);
                button_delete_point.BackColor = Color.FromArgb(255, 0, 0, 0);
                button_move_point.BackColor = Color.FromArgb(255, 255, 255, 255);
            }
            else if (newState == STATE.MOVING_POINT)
            {
                g_state = STATE.MOVING_POINT;
                label_state.Text = "Перемещение точки";
                button_add_point.BackColor = Color.FromArgb(255, 255, 255, 255);
                button_delete_point.BackColor = Color.FromArgb(255, 255, 255, 255);
                button_move_point.BackColor = Color.FromArgb(255, 0, 0, 0);
            }
        }

        private void button_draw_Click(object sender, EventArgs e)
        {
            textBox1.Text += "Визуализация составной кубической кривой Безье\n";
            isButton = true;
            DrawCurve2();
        }

        private void DrawPoints()
        {
            foreach (var p in points)
            {
                graphics.DrawEllipse(pen, p.X, p.Y, 2, 2);
            }
            canvas.Invalidate();
        }

        private Point B(double t, VectorD point1, VectorD point2, VectorD point3, VectorD point4)
        {
            double x = (1 - t) * (1 - t) * (1 - t) * point1.X + (1 - t) * (1 - t) * 3 * t * point2.X + (1 - t) * t * 3 * t * point3.X + t * t * t * point4.X;
            double y = (1 - t) * (1 - t) * (1 - t) * point1.Y + (1 - t) * (1 - t) * 3 * t * point2.Y + (1 - t) * t * 3 * t * point3.Y + t * t * t * point4.Y;
            return new Point((int)x, (int)y);
        }

        private void DrawCurve2()
        {
            graphics.Clear(Color.White);

            if (points.Count() < 4)
            {
                DrawPoints();
                return;
            }

            List<VectorD> newPoints = new List<VectorD>();
            newPoints.Add(points[0]);
            newPoints.Add(points[1]);
            newPoints.Add(points[2]);

            for (int i = 3; i < points.Count; i++)
            {
                if (i != points.Count - 1)
                {
                    if (i % 2 == 0)
                        newPoints.Add(points[i]);
                    if (i % 2 != 0)
                    {
                        newPoints.Add(new VectorD(points[i - 1].X + (points[i].X - points[i - 1].X) / 2, points[i - 1].Y + (points[i].Y - points[i - 1].Y) / 2));
                        newPoints.Add(points[i]);
                    }
                }
                else
                {
                    if (i % 2 == 0)
                    {
                        newPoints.Add(points[i]);
                        newPoints.Add(points[i]);
                    }
                    if (i % 2 != 0)
                        newPoints.Add(points[i]);
                }
            }

            List<Point> drawingPoints = new List<Point>();

            VectorD point1, point2, point3, point4;

            for (int i = 0; i < newPoints.Count - 3; i += 3)
            {
                point1 = newPoints[i];
                point2 = newPoints[i + 1];
                point3 = newPoints[i + 2];
                point4 = newPoints[i + 3];

                for (float t = 0; t <= 1; t += 0.01f)
                {
                    drawingPoints.Add(B(t, point1, point2, point3, point4));
                }

            }
            graphics.DrawLines(pen, drawingPoints.ToArray());
            for (int i = 0; i < newPoints.Count; i++)
            {
                if (points.Contains(newPoints[i]))
                    graphics.FillEllipse(Brushes.Red, newPoints[i].X - 2, newPoints[i].Y - 2, 7, 7);
            }
            canvas.Invalidate();
        }

        
        private void DrawCurve1()
        {
            List<PointF> p = new List<PointF>();
            for (float t = 0; t <= 1; t += 0.01f)
            {
                VectorD point = GetPoint(t);
                p.Add(new PointF(point.X, point.Y));
                //Console.WriteLine($"Point at t = {t}: ({point.X}, {point.Y})");
            }
            graphics.DrawLines(pen, p.ToArray());
            canvas.Invalidate();
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (g_state == STATE.DELETING_POINT)
            {
                for (int i = 0; i < points.Count(); i++)
                {
                    Rectangle bounds = new Rectangle((int)points[i].X - 5, (int)points[i].Y - 5, 10, 10);
                    if (bounds.Contains(e.Location))
                    {
                        points.Remove(points[i]);
                        label_count.Text = points.Count().ToString();
                        DrawCurve2();
                        break;
                    }
                }
            }
            else if (g_state == STATE.MOVING_POINT)
            {
                if (!isSelectedPoint)
                {
                    for (int i = 0; i < points.Count(); i++)
                    {
                        Rectangle bounds = new Rectangle((int)points[i].X - 5, (int)points[i].Y - 5, 10, 10);
                        if (bounds.Contains(e.Location))
                        {
                            selectedPoint = i;
                            isSelectedPoint = true;
                            break;
                        }
                    }
                }
                else
                {
                    selectedPoint = -1;
                    isSelectedPoint = false;
                }

            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (g_state == STATE.MOVING_POINT)
            {
                if (selectedPoint != -1)
                {
                    points[selectedPoint] = new VectorD(e.Location.X, e.Location.Y);
                    DrawCurve2();
                }
            }    
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.Text += "Визуализация составной кубической кривой Безье\n";
                isButton = true;
                DrawCurve2();
            }
            else
            {
                isButton = false;
            }
        }
    }
}
