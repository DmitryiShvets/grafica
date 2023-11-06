using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using blank.Primitives;
namespace blank.Shapes
{
    internal class Chart : Object3D
    {
        Func<float, float, float> func;
        int w;
        int h;
        public Chart(string _strFunc, string ax, string bx, string ay, string by, int _w, int _h) : base()
        {
            w = _w;
            h = _h;
            switch (_strFunc)
            {
                case "sin(x, y)":
                    func = (x, y) => (float)Math.Sin(x + y);
                    break;
                case "x^2 + y^2":
                    func = (x, y) => x * x + y * y;
                    break;
                case "1 / (x^2 + y^2)":
                    func = (x, y) => 1 / (x * x + y * y);
                    break;
                default:
                    func = (x, y) => x + y;
                    break;
            }

            // ВЫЧИСЛЕНИЕ КООРДИНАТ ГРАФИКА

            // Парсим промт для x и y
            var a_x = float.Parse(ax);
            var b_x = float.Parse(bx);
            var a_y = float.Parse(ay);
            var b_y = float.Parse(by);
            var delta = 0.1f;
            int count_x = (int)((b_x - a_x) * 10);
            int count_y = (int)((b_y - a_y) * 10);

            float[] z_values = new float[count_x * count_y];

            float min = float.MaxValue;
            float max = float.MinValue;

            // Вычисляем точки функции
            for (int i = 0; i < count_x; i++)
            {
                for (int j = 0; j < count_y; j++)
                {
                    float x = a_x + i * delta;
                    float y = a_y + j * delta;
                    z_values[i * count_y + j] = func(x, y);
                    if (z_values[i * count_y + j] < min) min = z_values[i * count_y + j];
                    if (z_values[i * count_y + j] > max) max = z_values[i * count_y + j];
                }
            }

            // Вычисляем график
            PointF[] x_axes = { new PointF(LinX(a_x, a_x, b_x), LinY(0, min, max) - 0.5f), new PointF(LinX(b_x, a_x, b_x), LinY(0, min, max) - 0.5f) };
            PointF[] y_axes = { new PointF(LinX(0, a_x, b_x), LinY(max, min, max)), new PointF(LinX(0, a_x, b_x), LinY(min, min, max)) };
            PointF[] points = new PointF[count_x * count_y];

            // Интерполяция точек
            for (int i = 0; i < count_x; i++)
            {
                for (int j = 0; j < count_y; j++)
                {
                    float x = a_x + i * delta;
                    float y = a_y + j * delta;
                    points[i * count_y + j] = new PointF(LinX(x, a_x, b_x), LinY(z_values[i * count_y + j], min, max));
                }
            }

            // СОЗДАНИЕ ТРЕУГОЛЬНИКОВ

            // Вычисляем график
            for (int i = 0; i < count_x - 1; i++)
            {
                for (int j = 0; j < count_y - 1; j++)
                {
                    // Вычисляем координаты вершин треугольников
                    Vector4 vertex1 = new Vector4(points[i * count_y + j].X - w/2, points[i * count_y + j].Y - h/2, z_values[i * count_y + j]);
                    Vector4 vertex2 = new Vector4(points[(i + 1) * count_y + j].X - w/2, points[(i + 1) * count_y + j].Y - h/2, z_values[(i + 1) * count_y + j]);
                    Vector4 vertex3 = new Vector4(points[i * count_y + (j + 1)].X - w/2, points[i * count_y + (j + 1)].Y - h/2, z_values[i * count_y + (j + 1)]);

                    // Добавляем треугольник в модель
                    mech.AddFace(vertex1, vertex2, vertex3, Color.Orange);
                }
            }

        }
        private float LinX(float x, float a, float b)
        {
            return (x - a) / (b - a) * w;
        }

        private float LinY(float y, float min, float max)
        {
            return (y - max) / (min - max) * h;
        }

        public Chart(Transform transform, string _strFunc, string ax, string bx, string ay, string by, int _w, int _h) : this(_strFunc, ax, bx, ay, by, _w, _h)
        {
            this.transform = transform;
        }
    }
}
