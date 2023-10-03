using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace blank
{
    public partial class VecPaintV : UserControl
    {
        private List<Polygon> _polygons = new List<Polygon>();  //общее кол-во полигонов на холсте
        private Polygon cur_edit_polygon = null;                //текущий полигон с котором выполнятется поворот, масштабировани
        private int count_vertex = 0;                           //кол-во вершин
        private Bitmap _bitmap;
        private Graphics _graphics;

        private Pen pen_edge = new Pen(Color.Black, 3f);
        private Brush brush_vertes = new SolidBrush(Color.DarkMagenta);
        private STATE g_state = STATE.NONE;

        //Движение полигона на dx, dy
        private Point mouse_start_position;
        private bool mouse_is_down = false;
        public VecPaintV()
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
                cur_edit_polygon = new Polygon();
                _polygons.Add(cur_edit_polygon);
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
            EDITING_POLYGON,        // состояние изменения полигона
            MOVE_POLYGON,           // состояние перемещение полигона
            ROTATE_POLYGON,         // состояние вращение полигона
            SCALE_POLYGON,          // состояние масштабирование полигона
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
                _polygons.Last().Insert(new Point2D(e.X, e.Y));
                _graphics.FillEllipse(brush_vertes, e.X - with_bar.Value / 2, e.Y - with_bar.Value / 2, with_bar.Value, with_bar.Value);
                canvas.Invalidate();
            }
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_is_down = true;
            if (g_state == STATE.MOVE_POLYGON)
            {
                mouse_start_position = e.Location;
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_is_down = false;
        }

        //Смещение полигона по dx и dy
        public void Translate(float dx, float dy)
        {
            Matrix3x2 translationMatrix = Matrix3x2.CreateTranslation(dx, dy);
            Vertex start = cur_edit_polygon.Front;

            var point = Vector2.Transform(new Vector2(cur_edit_polygon.Point.x, cur_edit_polygon.Point.y), translationMatrix);
            cur_edit_polygon.Front.Point.x = point.X;
            cur_edit_polygon.Front.Point.y = point.Y;
            cur_edit_polygon.Advance(Vertex.ROTATION.CLOCKWISE);

            while (cur_edit_polygon.Front != start)
            {
                point = Vector2.Transform(new Vector2(cur_edit_polygon.Point.x, cur_edit_polygon.Point.y), translationMatrix);
                cur_edit_polygon.Front.Point.x = point.X;
                cur_edit_polygon.Front.Point.y = point.Y;
                cur_edit_polygon.Advance(Vertex.ROTATION.CLOCKWISE);
            }
            ReCount();
            UpdateUI();
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (g_state == STATE.MOVE_POLYGON && mouse_is_down && cur_edit_polygon != null)
            {
                float dx = e.Location.X - mouse_start_position.X;
                float dy = e.Location.Y - mouse_start_position.Y;
                Translate(dx, dy);
                mouse_start_position = e.Location;
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

        private void btn_move_Click(object sender, EventArgs e)
        {
            g_state = STATE.MOVE_POLYGON;
        }
    }
}

