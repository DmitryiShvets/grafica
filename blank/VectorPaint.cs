
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace blank
{
    public partial class VectorPaint : UserControl
    {
        private List<Polygon> _polygons = new List<Polygon>();  //общее кол-во полигонов на холсте
        private Polygon cur_edit_polygon = null;                //текущий полигон с котором выполнятется поворот, масштабировани
        private int count_vertex = 0;                           //кол-во вершин
        private Bitmap _bitmap;
        private Graphics _graphics;

        private Pen pen_edge = new Pen(Color.LawnGreen, 3f);
        private Brush brush_vertes = new SolidBrush(Color.DarkMagenta);
        private STATE g_state = STATE.NONE;
        public VectorPaint()
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

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void ReCount()
        {
            count_vertex = 0;
            foreach (var item in _polygons)
            {
                count_vertex += item.Size;
            }
        }

        private Polygon GiftWrapHull(Point2D[] s, int n)
        {

            int a=0;
            for (int i = 1; i < n; i++)
            {
                if (s[i] < s[a]) a = i;  //Находим самую левую
            }

            s[n] = s[a]; //Запоминаем начальную точку

            Polygon result = new Polygon();

            for (int m = 0; m < n; m++)
            {
                SwapPoints(ref s[a], ref s[m]); 
                result.Insert(s[m]);
                a = m + 1;
                for (int i = m + 2; i <= n; i++)
                {
                    Point2D.ORIENTATION c = s[i].Classify(s[m], s[a]);
                    if (c == Point2D.ORIENTATION.LEFT || c == Point2D.ORIENTATION.BEYOND) a = i;
                }
                if (a == n) return result;
            }
            return new Polygon();
        }

        private void SwapPoints(ref Point2D a, ref Point2D b)
        {
            Point2D tmp = a;
            a = b;
            b = tmp;
        }

        private void btn_wrap_hull_Click(object sender, System.EventArgs e)
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
                Polygon polygon = GiftWrapHull(points, _polygons.Count);

                if (polygon.Size == 1)
                {
                    DrawVertexes(polygon);
                }
                if (polygon.Size > 1)
                {
                    DrawEdges(polygon);
                    DrawVertexes(polygon);
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
