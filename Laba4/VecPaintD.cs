using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using System.Numerics;

namespace blank
{
    public partial class VecPaintD : UserControl
    {
        private List<Polygon> _polygons = new List<Polygon>();  //общее кол-во полигонов на холсте
        private Polygon cur_edit_polygon = null;                //текущий полигон с котором выполнятется поворот, масштабировани
        private int count_vertex = 0;                           //кол-во вершин
        private Bitmap _bitmap;
        private Graphics _graphics;

        private Pen pen_edge = new Pen(Color.LimeGreen, 3f);
        private Pen pen_selected_edge = new Pen(Color.Red, 3f);
        private Pen pen_point = new Pen(Color.Blue, 3f);
        private Brush brush_vertes = new SolidBrush(Color.DarkMagenta);
        private STATE g_state = STATE.NONE;
        private List<EdgeD> selected_edges = new List<EdgeD>();
        public VecPaintD()
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
                _polygons.Add(new Polygon());
                UpdateUI();
            }
            else status.Text = "Ошибка добавления полигона";

        }

        private void btn_apply_Click(object sender, System.EventArgs e)
        {
            if (g_state == STATE.ADDING_POLYGON)
            {
                if (_polygons.Last().Size == 1)
                {
                    listBox_polygons.Items.Add("Vertex " + _polygons.Count);
                }
                else if (_polygons.Last().Size == 2)
                {
                    listBox_polygons.Items.Add("Edge " + _polygons.Count);
                }
                else
                {
                    listBox_polygons.Items.Add("Polygon " + _polygons.Count);
                }
                cur_edit_polygon = _polygons.Last();
                g_state = STATE.NONE;
                ReCount();
                UpdateUI();
            }
            else status.Text = "Ошибка приминения полигона";
        }

        private void btn_clear_Click(object sender, System.EventArgs e)
        {
            listBox_polygons.Items.Clear();
            g_state = STATE.NONE;
            ClearPoligons();
            UpdateUI();
        }

        private enum STATE
        {
            NONE,                   // IDLE
            ADDING_POLYGON,         // состояние добавления полигона
            EDITING_POLYGON,        // состояние изменения полигона
            MOVE_POLYGON,           // состояние перемещение полигона
            ROTATE_POLYGON,         // состояние вращение полигона
            SCALE_POLYGON,          // состояние масштабирование полигона
            POINT_IN_POLYGON,       // состояние выбора точки для проверки принадлежности выпуклому полигону
            POINT_IN_POLYGON2,      // состояние выбора точки для проверки принадлежности невыпуклому полигону
            POINT_NEAR_EDGE,        // состояние выбора точки около ребра
            EDGES_CROSS             // состояние выбора ребер для поиска точки пересечения
        }

        private void UpdateUI()
        {
            ClearCanvas();
            switch (g_state)
            {
                case STATE.NONE: btn_clear.Select(); break;
                case STATE.ADDING_POLYGON: btn_add_polygon.Select(); break;
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
                    DrawEdges(polygon, pen_edge);
                    DrawVertexes(polygon);
                }
            }
            canvas.Image = _bitmap;
            canvas.Invalidate();
        }

        private void DrawVertexes(Polygon polygon)
        {
            Vertex start = polygon.Front;

            _graphics.FillEllipse(brush_vertes, polygon.Front.x - with_bar.Value / 2, polygon.Front.y - with_bar.Value / 2, with_bar.Value, with_bar.Value);
            polygon.Advance(Vertex.ROTATION.CLOCKWISE);

            while (polygon.Front != start)
            {
                _graphics.FillEllipse(brush_vertes, polygon.Front.x - with_bar.Value / 2, polygon.Front.y - with_bar.Value / 2, with_bar.Value, with_bar.Value);
                polygon.Advance(Vertex.ROTATION.CLOCKWISE);
            }
        }

        private void DrawEdges(Polygon polygon, Pen pen)
        {
            Vertex start = polygon.Front;

            _graphics.DrawLine(pen, start.x, start.y, start.Next.x, start.Next.y);
            polygon.Advance(Vertex.ROTATION.CLOCKWISE);

            while (polygon.Front != start)
            {
                _graphics.DrawLine(pen, polygon.Front.x, polygon.Front.y, polygon.Front.Next.x, polygon.Front.Next.y);
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
                _polygons.Last().Insert(new Point2D(e.X, e.Y));
                _graphics.FillEllipse(brush_vertes, e.X - with_bar.Value / 2, e.Y - with_bar.Value / 2, with_bar.Value, with_bar.Value);
                canvas.Invalidate();
            }
            else if (g_state == STATE.POINT_IN_POLYGON)
            {
                Point2D point = new Point2D(e.X, e.Y);
                Console.WriteLine($"Выбрана точка: {point.x}, {point.y}");
                bool f = IsPointInPolygon(point);
                label_count.Text = Convert.ToString(Convert.ToInt32(label_count.Text) + 1);
                textBox1.Text = "";
                textBox1.Text += $"Принадлежит многоугольнику: {f}\n";
                Console.WriteLine($"Принадлежит многоугольнику: {f}");
                //g_state = STATE.NONE;
            }
            else if (g_state == STATE.POINT_IN_POLYGON)
            {
                Point2D point = new Point2D(e.X, e.Y);
                Console.WriteLine($"Выбрана точка: {point.x}, {point.y}");
                bool f = IsPointInPolygon(point);
                label_count.Text = Convert.ToString(Convert.ToInt32(label_count.Text) + 1);
                textBox1.Text = "";
                textBox1.Text += "Вызвана функция: Принадлежности точки выпуклому полигону\n";
                textBox1.Text += $"Принадлежит многоугольнику: {f}\n";
                Console.WriteLine($"Принадлежит многоугольнику: {f}");
                //g_state = STATE.NONE;
            }
            else if (g_state == STATE.POINT_IN_POLYGON2)
            {
                Point2D point = new Point2D(e.X, e.Y);
                Console.WriteLine($"Выбрана точка: {point.x}, {point.y}");
                bool f = IsPointInPolygon2(point);
                label_count.Text = Convert.ToString(Convert.ToInt32(label_count.Text) + 1);
                textBox1.Text = "";
                textBox1.Text += "Вызвана функция: Принадлежности точки невыпуклому полигону\n";
                textBox1.Text += $"Принадлежит многоугольнику: {f}\n";
                Console.WriteLine($"Принадлежит многоугольнику: {f}");
                //g_state = STATE.NONE;
            }
            else if (g_state == STATE.POINT_NEAR_EDGE)
            {
                Point2D point = new Point2D(e.X, e.Y);
                Point2D.ORIENTATION orient = point.Classify(cur_edit_polygon.Edge());
                Console.WriteLine(orient);
                label_count.Text = Convert.ToString(Convert.ToInt32(label_count.Text) + 1);
                textBox1.Text = "";
                textBox1.Text += $"Положение точки: {orient}\n";
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

        private void btn_dot_classify_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text += "Вызвана функция: Принадлежности точки выпуклому полигону(выберите полигон)\n";
            g_state = STATE.POINT_IN_POLYGON;
        }


        private void btn_dot_classify2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text += "Вызвана функция: Принадлежности точки невыпуклому полигону(выберите полигон)\n";
            g_state = STATE.POINT_IN_POLYGON2;
        }

        private void btn_cross_Click(object sender, EventArgs e) // 4) Поиск точки пересечения двух ребер
        {
            label_count.Text = Convert.ToString(Convert.ToInt32(label_count.Text) + 1);
            textBox1.Text = "";
            textBox1.Text += "Вызвана функция: Поиска точки пересечения двух ребер(выберите два ребра)\n";
            g_state = STATE.EDGES_CROSS;
        }

        private void btn_rotate_edge_Click(object sender, EventArgs e) // 7) Классифицировать положение точки относительно ребра
        {
            textBox1.Text = "";
            textBox1.Text += "Вызвана функция: Классифицирования положения точки относительно ребра(выберите ребро)\n";
            g_state = STATE.POINT_NEAR_EDGE;
        }

        private void CrossEdges(EdgeD e1, EdgeD e2)
        {
            double x1 = e1.origin.x;
            double y1 = e1.origin.y;
            double x2 = e1.dest.x;
            double y2 = e1.dest.y;

            double x3 = e2.origin.x;
            double y3 = e2.origin.y;
            double x4 = e2.dest.x;
            double y4 = e2.dest.y;

            double xIntersect, yIntersect;

            double a1 = y2 - y1;
            double b1 = x1 - x2;
            double c1 = a1 * x1 + b1 * y1;

            double a2 = y4 - y3;
            double b2 = x3 - x4;
            double c2 = a2 * x3 + b2 * y3;

            double determiant = a1 * b2 - a2 * b1;

            if (Math.Abs(determiant) < 1e-9)
            {
                textBox1.Text = "Parallel\n";
            }
            else
            {
                xIntersect = (b2 * c1 - b1 * c2) / determiant;
                yIntersect = (a1 * c2 - a2 * c1) / determiant;
                textBox1.Text += $"Точка пересечения: {xIntersect}, {yIntersect}";
                _graphics.DrawEllipse(pen_point, (int)xIntersect, (int)yIntersect, 3, 3);
                canvas.Invalidate();
            }
        }

        private bool IsPointInPolygon(Point2D point) // 5) Принадлежит ли точка выпуклому многоугольнику
        {
            PolygonD polygonD = new PolygonD(cur_edit_polygon);
            if (polygonD.IsPointInPolygon(point)) return true;
            return false;
        }

        private bool IsPointInPolygon2(Point2D point) // 6) Принадлежит ли точка невыпуклому многоугольнику
        {
            PolygonD polygonD = new PolygonD(cur_edit_polygon);
            if (polygonD.IsPointInPolygon2(point)) return true;
            return false;
        }

        private void listBox_polygons_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawEdges(cur_edit_polygon, pen_edge);
            cur_edit_polygon = _polygons[listBox_polygons.SelectedIndex];
            DrawEdges(cur_edit_polygon, pen_selected_edge);
            canvas.Invalidate();

            if (g_state == STATE.EDGES_CROSS)
            {
                textBox1.Text = "";
                textBox1.Text += "cur_edit_polygon.Size = " + cur_edit_polygon.Size + "\n";
                if (cur_edit_polygon.Size == 2)
                {
                    Edge curEdge = cur_edit_polygon.Edge();
                    selected_edges.Add(new EdgeD(curEdge.origin, curEdge.dest));
                    textBox1.Text += $"Добавлено ребро, кол-во ребер: {selected_edges.Count}" + "\n";
                    if (selected_edges.Count == 2)
                    {
                        CrossEdges(selected_edges[0], selected_edges[1]);
                        selected_edges.Clear();
                        textBox1.Text += "Ребра очищены\n";
                    }
                }
            }

        }

        // Поиск точки пересечения двух ребер +
        // Принадлежит ли точка выпуклому многоугольнику +
        // Принадлежит ли точка невыпуклому многоугольнику +
        // Классифицировать положение точки относительно ребра +
    }
}

