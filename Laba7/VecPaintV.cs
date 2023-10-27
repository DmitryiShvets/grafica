using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        Vector2 center;
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
                if (_polygons.Last().Size == 0) _polygons.Remove(_polygons.Last());

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
            ROTATE_POLYGON_CENTER,  // состояние вращение полигона в центре
            SCALE_POLYGON,          // состояние масштабирование полигона
            SCALE_POLYGON_CENTER,   // состояние масштабирования полигона в центре
        }

        Dictionary<STATE, string> state_names = new Dictionary<STATE, string> {
            {STATE.NONE,"" },
            {STATE.ADDING_POLYGON,"Создание полигона" },
            {STATE.EDITING_POLYGON,"Редактирование полигона" },
            {STATE.MOVE_POLYGON,"Смещение по dx, dy" },
            {STATE.ROTATE_POLYGON,"Вращение относительно точки" },
            {STATE.ROTATE_POLYGON_CENTER,"Вращение относительно центра" },
            {STATE.SCALE_POLYGON,"Масштабирование относительно точки" },
            {STATE.SCALE_POLYGON_CENTER,"Масштабирование относительно центра" },
        };

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
            Vertex2D start = polygon.Front;

            _graphics.FillEllipse(brush_vertes, polygon.Front.x - with_bar.Value / 2, polygon.Front.y - with_bar.Value / 2, with_bar.Value, with_bar.Value);
            polygon.Advance(Vertex2D.ROTATION.CLOCKWISE);

            while (polygon.Front != start)
            {
                _graphics.FillEllipse(brush_vertes, polygon.Front.x - with_bar.Value / 2, polygon.Front.y - with_bar.Value / 2, with_bar.Value, with_bar.Value);
                polygon.Advance(Vertex2D.ROTATION.CLOCKWISE);
            }
        }

        private void DrawEdges(Polygon polygon)
        {
            Vertex2D start = polygon.Front;

            _graphics.DrawLine(pen_edge, start.x, start.y, start.Next.x, start.Next.y);
            polygon.Advance(Vertex2D.ROTATION.CLOCKWISE);

            while (polygon.Front != start)
            {
                _graphics.DrawLine(pen_edge, polygon.Front.x, polygon.Front.y, polygon.Front.Next.x, polygon.Front.Next.y);
                polygon.Advance(Vertex2D.ROTATION.CLOCKWISE);
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
            mouse_start_position = e.Location;
            if (g_state == STATE.ROTATE_POLYGON_CENTER || g_state == STATE.SCALE_POLYGON_CENTER)
            {
                center = CalculateCenter();
            }
            else if (g_state == STATE.ROTATE_POLYGON || g_state == STATE.SCALE_POLYGON)
            {
                center = new Vector2(e.X, e.Y);
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_is_down = false;
        }

        //Смещение полигона по dx и dy
        public void Translate(Polygon polygon, float dx, float dy)
        {
            var translationMatrix = AffineTransformations.TranslationMatrix(dx, dy);


            Vertex2D start = polygon.Front;

            Matrix2D pointMatrix = new Matrix2D(new double[,]
            {
                { polygon.Point.x },
                { polygon.Point.y },
                { 1 }
            });

            Matrix2D result = Matrix2D.Multiply(translationMatrix, pointMatrix);
            polygon.Front.Point.x = (float)result.Values[0, 0];
            polygon.Front.Point.y = (float)result.Values[1, 0];

            polygon.Advance(Vertex2D.ROTATION.CLOCKWISE);

            while (polygon.Front != start)
            {
                pointMatrix = new Matrix2D(new double[,]
                {
                    { polygon.Point.x },
                    { polygon.Point.y },
                    { 1 }
                });

                result = Matrix2D.Multiply(translationMatrix, pointMatrix);
                polygon.Front.Point.x = (float)result.Values[0, 0];
                polygon.Front.Point.y = (float)result.Values[1, 0];

                polygon.Advance(Vertex2D.ROTATION.CLOCKWISE);
            }
            ReCount();
            UpdateUI();
        }

        //Вычисление центра полигона
        private Vector2 CalculateCenter()
        {
            float sumX = 0;
            float sumY = 0;

            Vertex2D start = cur_edit_polygon.Front;
            sumX += cur_edit_polygon.Front.Point.x;
            sumY += cur_edit_polygon.Front.Point.y;
            cur_edit_polygon.Advance(Vertex2D.ROTATION.CLOCKWISE);

            while (cur_edit_polygon.Front != start)
            {
                sumX += cur_edit_polygon.Front.Point.x;
                sumY += cur_edit_polygon.Front.Point.y;

                cur_edit_polygon.Advance(Vertex2D.ROTATION.CLOCKWISE);
            }

            return new Vector2(sumX / cur_edit_polygon.Size, sumY / cur_edit_polygon.Size);
        }
        //Вращение полигона
        public void Rotate(Polygon polygon, float angle, Vector2 center)
        {
            var rotationMatrix = AffineTransformations.RotationMatrix(angle, new Point2D(center.X, center.Y));
            
            Vertex2D start = polygon.Front;

            Matrix2D pointMatrix = new Matrix2D(new double[,]
            {
                { polygon.Point.x },
                { polygon.Point.y },
                { 1 }
            });

            Matrix2D result = Matrix2D.Multiply(rotationMatrix, pointMatrix);
            polygon.Front.Point.x = (float)result.Values[0, 0];
            polygon.Front.Point.y = (float)result.Values[1, 0];

            polygon.Advance(Vertex2D.ROTATION.CLOCKWISE);

            while (cur_edit_polygon.Front != start)
            {
                pointMatrix = new Matrix2D(new double[,]
                {
                    { polygon.Point.x },
                    { polygon.Point.y },
                    { 1 }
                });

                result = Matrix2D.Multiply(rotationMatrix, pointMatrix);
                polygon.Front.Point.x = (float)result.Values[0, 0];
                polygon.Front.Point.y = (float)result.Values[1, 0];

                polygon.Advance(Vertex2D.ROTATION.CLOCKWISE);
            }
            ReCount();
            UpdateUI();
        }
        //Масштабирование полигона
        public void Scale(Polygon polygon, float sx, float sy, Vector2 center)
        {
            var scaleMatrix = AffineTransformations.ScaleMatrix(sx, sy, new Point2D(center.X, center.Y));

            Vertex2D start = polygon.Front;

            Matrix2D pointMatrix = new Matrix2D(new double[,]
            {
                { polygon.Point.x },
                { polygon.Point.y },
                { 1 }
            });

            Matrix2D result = Matrix2D.Multiply(scaleMatrix, pointMatrix);
            polygon.Front.Point.x = (float)result.Values[0, 0];
            polygon.Front.Point.y = (float)result.Values[1, 0];

            polygon.Advance(Vertex2D.ROTATION.CLOCKWISE);

            while (cur_edit_polygon.Front != start)
            {
                pointMatrix = new Matrix2D(new double[,]
                {
                    { polygon.Point.x },
                    { polygon.Point.y },
                    { 1 }
                });

                result = Matrix2D.Multiply(scaleMatrix, pointMatrix);
                polygon.Front.Point.x = (float)result.Values[0, 0];
                polygon.Front.Point.y = (float)result.Values[1, 0];

                polygon.Advance(Vertex2D.ROTATION.CLOCKWISE);
            }
            ReCount();
            UpdateUI();
        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouse_is_down && cur_edit_polygon != null)
            {
                float dx = e.Location.X - mouse_start_position.X;
                float dy = e.Location.Y - mouse_start_position.Y;
                if (g_state == STATE.MOVE_POLYGON)
                {
                    Translate(cur_edit_polygon,dx, dy);
                }
                else if (g_state == STATE.ROTATE_POLYGON_CENTER || g_state == STATE.ROTATE_POLYGON)
                {
                    float rotationAngleRadians = (float)Math.PI / 64 * Math.Sign(dx);
                    Rotate(cur_edit_polygon, rotationAngleRadians, center);
                }
                else if (g_state == STATE.SCALE_POLYGON_CENTER || g_state == STATE.SCALE_POLYGON)
                {
                    Scale(cur_edit_polygon, 1 + dx / 100, 1 - dy / 100, center);
                }
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

        private void ChangeState(STATE state)
        {
            if (g_state != state)
                g_state = state;
            else
                g_state = STATE.NONE;
            label_state.Text = state_names[g_state];
        }
        private void btn_move_Click(object sender, EventArgs e)
        {
            ChangeState(STATE.MOVE_POLYGON);
        }

        private void btn_rotate_center_Click(object sender, EventArgs e)
        {
            ChangeState(STATE.ROTATE_POLYGON_CENTER);
        }

        private void btn_rotate_arround_dot_Click(object sender, EventArgs e)
        {
            ChangeState(STATE.ROTATE_POLYGON);
        }

        private void btn_scale_center_Click(object sender, EventArgs e)
        {
            ChangeState(STATE.SCALE_POLYGON_CENTER);
        }

        private void btn_scale_Click(object sender, EventArgs e)
        {
            ChangeState(STATE.SCALE_POLYGON);
        }

        private void btn_edge_rot_Click(object sender, EventArgs e)
        {
            if (cur_edit_polygon != null)
            {
                var editet_edge = cur_edit_polygon.RotateEdge();
                ReCount();
                UpdateUI();
            }
        }
    }
}

