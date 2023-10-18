using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace blank
{
    public partial class VectorPaintD : UserControl
    {
        private List<Polygon> _polygons = new List<Polygon>();  //общее кол-во полигонов на холсте
        private Polygon cur_edit_polygon = null;                //текущий полигон с котором выполнятется поворот, масштабировани
        private int count_vertex = 0;                           //кол-во вершин
        private Bitmap _bitmap;
        private Graphics _graphics;

        private Pen pen_edge = new Pen(Color.LawnGreen, 3f);
        private Brush brush_vertes = new SolidBrush(Color.DarkMagenta);
        private STATE g_state = STATE.NONE;
        public VectorPaintD()
        {
            InitializeComponent();
            _bitmap = new Bitmap(canvas.Width, canvas.Height);
            _graphics = Graphics.FromImage(_bitmap);
            _graphics.Clear(Color.White);
            canvas.Image = _bitmap;

            UpdateUI();
        }

        private void btn_add_polygon_Click(object sender, System.EventArgs e)
        {
            if (g_state == STATE.NONE)
            {
                g_state = STATE.ADDING_POLYGON;
                UpdateUI();
            }
            else status.Text = "Ошибка добавления полигона";
        }

        private void btn_apply_Click(object sender, System.EventArgs e)
        {
            if (g_state == STATE.ADDING_POLYGON)
            {
                g_state = STATE.NONE;
                ReCount();
                UpdateUI();
            }
            else status.Text = "Ошибка приминения полигона";
        }

        private void btn_clear_Click(object sender, System.EventArgs e)
        {
            g_state = STATE.NONE;
            ClearPoligons();
            UpdateUI();
        }

        private enum STATE
        {
            NONE,                   // IDLE
            ADDING_POLYGON,         // состояние добавления полигона
        }

        private void UpdateUI()
        {
            ClearCanvas();
            status.Text = "статус";

            switch (g_state)
            {
                case STATE.NONE: btn_clear.Select(); break;
                case STATE.ADDING_POLYGON:
                    {
                        btn_add_polygon.Select();
                        status.Text = "Добавление полигонов";
                        break;
                    }
            }
            cur_info.Text = "полигонов: " + _polygons.Count + " вершин: " + count_vertex;
            if (_polygons.Count > 0) DrawAll();
        }

        private void ClearCanvas()
        {
            _graphics.Clear(Color.White);
            canvas.Invalidate();
        }

        private void ClearPoligons()
        {
            _polygons.Clear();
            ReCount();
        }

        private void DrawAll()
        {
            foreach (var polygon in _polygons)
            {
                if (polygon.Size == 1)
                {
                    DrawVertexes(polygon);
                }
                if (polygon.Size > 1)
                {
                    DrawEdges(polygon);
                    DrawVertexes(polygon);
                }
            }
            canvas.Image = _bitmap;
            canvas.Invalidate();
        }

        private void DrawVertexes(Polygon polygon, int s = 0)
        {
            Vertex start = polygon.Front;

            _graphics.FillEllipse(brush_vertes, polygon.Front.x - with_bar.Value / 2 - s/2, polygon.Front.y - with_bar.Value / 2 - s / 2, with_bar.Value + s, with_bar.Value + s);
            polygon.Advance(Vertex.ROTATION.CLOCKWISE);

            while (polygon.Front != start)
            {
                _graphics.FillEllipse(brush_vertes, polygon.Front.x - with_bar.Value / 2 - s / 2, polygon.Front.y - with_bar.Value / 2 - s / 2, with_bar.Value + s, with_bar.Value + s);
                polygon.Advance(Vertex.ROTATION.CLOCKWISE);
            }
        }

        private void DrawEdges(Polygon polygon)
        {
            Vertex start = polygon.Front;

            _graphics.DrawLine(pen_edge, start.x, start.y, start.Next.x, start.Next.y);
            polygon.Advance(Vertex.ROTATION.CLOCKWISE);

            while (polygon.Front != start)
            {
                _graphics.DrawLine(pen_edge, polygon.Front.x, polygon.Front.y, polygon.Front.Next.x, polygon.Front.Next.y);
                polygon.Advance(Vertex.ROTATION.CLOCKWISE);
            }
        }

        private void btn_color_Click(object sender, System.EventArgs e)
        {
            Button button = (sender as Button);
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            pen_edge.Color = colorDialog1.Color;
            button.BackColor = colorDialog1.Color;
            UpdateUI();
        }

        private void btn_color_2_Click(object sender, System.EventArgs e)
        {
            Button button = (sender as Button);
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            brush_vertes = new SolidBrush(colorDialog1.Color);
            button.BackColor = colorDialog1.Color;
            UpdateUI();
        }

        private void with_bar_ValueChanged(object sender, System.EventArgs e)
        {
            if (g_state == STATE.NONE)
            {
                pen_edge.Width = (sender as TrackBar).Value;
                UpdateUI();
            }
        }

        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (g_state == STATE.ADDING_POLYGON)
            {
                _polygons.Add(new Polygon());
                _polygons.Last().Insert(new Point2D(e.X, e.Y));
                _graphics.FillEllipse(brush_vertes, e.X - with_bar.Value / 2, e.Y - with_bar.Value / 2, with_bar.Value, with_bar.Value);
                canvas.Invalidate();
            }
        }

        private void ReCount()
        {
            count_vertex = 0;
            foreach (var item in _polygons)
            {
                count_vertex += item.Size;
            }
        }

        private Polygon HullAndrew(Point2D[] s, int n)
        {
            Polygon result = new Polygon();

            int min = 0;
            int max = 0;

            for (int i = 0; i < n; i++)
            {
                if (s[max] < s[i])
                    max = i;
                if (s[min] > s[i])
                    min = i;
            }

            _graphics.DrawLine(new Pen(Color.Black, 3f), s[min].x, s[min].y, s[max].x, s[max].y);

            Edge e = new Edge(s[max], s[min]);
            List<Point2D> upper = new List<Point2D>() { s[min], s[max] };
            List<Point2D> lower = new List<Point2D>() { s[min], s[max] };

            for (int i = 0; i < n; i++)
            {
                if (i != min && i != max)
                {
                    if (s[i].Classify(e) == Point2D.ORIENTATION.LEFT)
                        upper.Add(s[i]);
                    else if (s[i].Classify(e) == Point2D.ORIENTATION.RIGHT)
                        lower.Add(s[i]);
                }
            }

            Brush brushRed = new SolidBrush(Color.Red);
            Brush brushBlue = new SolidBrush(Color.Blue);

            // Нижняя оболочка
            for (int i = 0; i < lower.Count(); i++)
            {
                _graphics.FillEllipse(brushRed, lower[i].x - 5, lower[i].y - 5, 10, 10);
            }

            lower.Sort((a, b) =>
            {
                if (a.x == b.x)
                    return a.y.CompareTo(b.y);
                return a.x.CompareTo(b.x);
            });

            //Поиск оболочки для lower
            List<Point2D> hullLower = new List<Point2D>();
            for (int i = 0; i < lower.Count(); i++)
            {
                while (hullLower.Count >= 2 && lower[i].Classify(hullLower[hullLower.Count - 2], hullLower[hullLower.Count - 1]) == Point2D.ORIENTATION.LEFT)
                {
                    hullLower.RemoveAt(hullLower.Count - 1);
                }
                hullLower.Add(lower[i]);
            }

            // Верхняя оболочка
            for (int i = 0; i < upper.Count(); i++)
            {
                _graphics.FillEllipse(brushBlue, upper[i].x - 5, upper[i].y - 5, 10, 10);
            }

            upper.Sort((a, b) =>
            {
                if (a.x == b.x)
                    return a.y.CompareTo(b.y);
                return a.x.CompareTo(b.x);
            });

            //Поиск оболочки для upper
            List<Point2D> hullUpper = new List<Point2D>();

            for (int i = 0; i < upper.Count(); i++)
            {
                while (hullUpper.Count >= 2 && upper[i].Classify(hullUpper[hullUpper.Count - 2], hullUpper[hullUpper.Count - 1]) == Point2D.ORIENTATION.RIGHT)
                {
                    hullUpper.RemoveAt(hullUpper.Count - 1);
                }
                hullUpper.Add(upper[i]);
            }

            hullUpper.RemoveAt(0);
            hullUpper.RemoveAt(hullUpper.Count - 1);

            //Объединение
            List<Point2D> hull = new List<Point2D>();
            for (int i = 0; i < hullLower.Count(); i++)
            {
                hull.Add(hullLower[i]);
            }
            for (int i = hullUpper.Count - 1; i >= 0; i--)
            {
                hull.Add(hullUpper[i]);
            }
            for (int i = 0; i < hull.Count(); i++)
            {
                result.Insert(hull[i]);
            }
            return result;
        }

        private void button_Andrew_Click(object sender, System.EventArgs e)
        {
            if (g_state == STATE.NONE)
            {
                Point2D[] points = new Point2D[_polygons.Count + 1];
                int i = 0;
                foreach (var item in _polygons)
                {
                    points[i] = item.Point;
                    i++;
                }
                points[i] = new Point2D();
                Polygon polygon = HullAndrew(points, _polygons.Count);

                if (polygon.Size == 1)
                {
                    DrawVertexes(polygon, 5);
                }
                if (polygon.Size > 1)
                {
                    DrawEdges(polygon);
                    DrawVertexes(polygon, 5);
                }

                canvas.Image = _bitmap;
                canvas.Invalidate();
            }
            else
            {
                status.Text = "Ошибка! Сначала сохраните полигоны";
            }
        }
    }
}
