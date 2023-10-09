using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastBitmaps;
using System.IO;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace Laba5
{
    public partial class Task1 : Form
    {
        private static string l_system_dir = "../../L-systems/";
        private Graphics _graphics;
        private Bitmap _bitmap;
        string _file_name = l_system_dir + "КриваяКоха.txt";
        public Task1()
        {
            InitializeComponent();
            _bitmap = new Bitmap(canvas.Width, canvas.Height);
            _graphics = Graphics.FromImage(_bitmap);
            _graphics.Clear(Color.White);
            canvas.Image = _bitmap;


        }

        private void Task1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        class FractalRenderer
        {
            private LSystemParameters _parameters;
            private string _fractalString;
            private Graphics m_graphics;
            private PictureBox m_pictureBox;
            private Pen pen = new Pen(Color.Black);
            List<Tuple<PointF, PointF>> points = new List<Tuple<PointF, PointF>>();
            // центр окна
            private PointF center;
            // центр полученного фрактала
            private PointF center_fractal;
            // шаг для масштабирования
            private float step;
            public FractalRenderer(LSystemParameters parameters, Graphics graphics, PictureBox pictureBox)
            {
                m_graphics = graphics;
                m_pictureBox = pictureBox;

                _parameters = parameters;
                _fractalString = "";

                center = new PointF(m_pictureBox.Width / 2, m_pictureBox.Height / 2);

                pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            }

            public void SetFractalString(string fractalString)
            {
                _fractalString = fractalString;
            }

            public void RenderFractal()
            {

                Stack<(PointF, float Angle)> stateStack = new Stack<(PointF, float)>();

                float cur_angle = 0;
                PointF point = new PointF(0, 0);

                foreach (char symbol in _fractalString)
                {
                    switch (symbol)
                    {
                        case 'F': // Движение вперед
                            float newX = point.X + (float)Math.Cos(cur_angle);
                            float newY = point.Y + (float)Math.Sin(cur_angle);
                            PointF new_point = new PointF(newX, newY);
                            points.Add(Tuple.Create(point, new_point));
                            point = new_point;
                            break;

                        case '+': // Поворот по часовой стрелке
                            cur_angle += _parameters.RAngle;
                            break;

                        case '-': // Поворот против часовой стрелки
                            cur_angle -= _parameters.RAngle;
                            break;

                        case '[': // Сохранение состояния
                            stateStack.Push((point, cur_angle));
                            break;

                        case ']': // Восстановление состояния
                            (point, cur_angle) = stateStack.Pop();
                            break;

                        default:
                            // Игнорируем неизвестные символы
                            break;
                    }
                }

                // находим минимум и максимум полученных точек для масштабирования
                float minX = points.Min(p => Math.Min(p.Item1.X, p.Item2.X));
                float maxX = points.Max(p => Math.Max(p.Item1.X, p.Item2.X));
                float minY = points.Min(p => Math.Min(p.Item1.Y, p.Item2.Y));
                float maxY = points.Max(p => Math.Max(p.Item1.Y, p.Item2.Y));

                // центр полученного фрактала
                center_fractal = new PointF(minX + (maxX - minX) / 2, minY + (maxY - minY) / 2);
                // шаг для масштабирования
                step = Math.Min(m_pictureBox.Width / (maxX - minX), (m_pictureBox.Height -1)/ (maxY - minY));

                List<Tuple<PointF, PointF>> scale_points = new List<Tuple<PointF, PointF>>(points);
                // масштабируем список точек
                for (int i = 0; i < points.Count(); i++)
                {
                    float scaleX = center.X + (points[i].Item1.X - center_fractal.X) * step;
                    float scaleY = center.Y + (points[i].Item1.Y - center_fractal.Y) * step;
                    float scaleNextX = center.X + (points[i].Item2.X - center_fractal.X) * step;
                    float scaleNextY = center.Y + (points[i].Item2.Y - center_fractal.Y) * step ;

                    scale_points[i] = new Tuple<PointF, PointF>(new PointF(scaleX, scaleY), new PointF(scaleNextX, scaleNextY));
                }

                for (int i = 0; i < points.Count(); i++)
                    m_graphics.DrawLine(pen, scale_points[i].Item1, scale_points[i].Item2);

                // Отобразим изображение
                m_pictureBox.Invalidate();
            }
        }

        class FractalGenerator
        {
            private LSystemParameters _parameters;
            private string _currentString;

            public FractalGenerator(LSystemParameters parameters)
            {
                _parameters = parameters;
                _currentString = _parameters.Axiom;
            }

            public string GenerateFractal(int iterations)
            {
                for (int i = 0; i < iterations; i++)
                {
                    _currentString = ProcessString(_currentString);
                }

                return _currentString;
            }

            private string ProcessString(string input)
            {
                string result = "";

                foreach (char symbol in input)
                {
                    if (_parameters.RuleDictionary.ContainsKey(symbol))
                    {
                        result += _parameters.RuleDictionary[symbol];
                    }
                    else
                    {
                        result += symbol;
                    }
                }

                return result;
            }
        }

        class LSystemParameters
        {
            public string Axiom { get; set; }
            public float RAngle { get; set; }
            public float RDirection { get; set; }
            public List<string> Rules { get; set; }
            public Dictionary<char, string> RuleDictionary { get; set; }

            public LSystemParameters(string filePath)
            {
                if (!ReadFromFile(filePath))
                {
                    throw new ArgumentException("Ошибка чтения параметров из файла.");
                }
            }

            private bool ReadFromFile(string filePath)
            {
                try
                {
                    string[] lines = File.ReadAllLines(filePath);

                    if (lines.Length >= 2)
                    {
                        Axiom = lines[0].Split(' ')[0];
                        RAngle = float.Parse(lines[0].Split(' ')[1], CultureInfo.InvariantCulture) * (float)Math.PI / 180;
                        RDirection = GetRotationDirection(lines[0].Split(' ')[2]);
                        Rules = new List<string>();
                        RuleDictionary = new Dictionary<char, string>();

                        for (int i = 1; i < lines.Length; i++)
                        {
                            Rules.Add(lines[i].Trim());
                            InitializeRules(lines[i].Trim());
                        }

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return false;
                }
            }
            private void InitializeRules(string ruleString)
            {
                string[] ruleParts = ruleString.Split(' ');
                char symbol = ruleParts[0][0];
                string replacement = ruleParts[1];
                RuleDictionary[symbol] = replacement;
            }
            private float GetRotationDirection(string direction)
            {
                if (direction.ToLower() == "up")
                {
                    return (float)(3 * Math.PI / 2);
                }
                else if (direction.ToLower() == "down")
                {
                    return (float)(Math.PI / 2);
                }
                else if (direction.ToLower() == "left")
                {
                    return (float)(Math.PI);
                }
                else if (direction.ToLower() == "right")
                {
                    return 0f;
                }
                else
                {
                    throw new ArgumentException("Неверное направление угла поворота.");
                }
            }
            public void PrintParameters()
            {
                Console.WriteLine("Axiom: " + Axiom);
                Console.WriteLine("Rotation Angle: " + RAngle);
                Console.WriteLine("Rotation Direction: " + RDirection);
                Console.WriteLine("Rules:");
                foreach (var kvp in RuleDictionary)
                {
                    Console.WriteLine(kvp.Key + " -> " + kvp.Value);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _graphics.Clear(Color.White);
            canvas.Invalidate();
            // Создание объекта LSystemParameters с параметрами из файла
            LSystemParameters parameters = new LSystemParameters(_file_name);

            // Вывод считанных параметров
            parameters.PrintParameters();

            FractalGenerator generator = new FractalGenerator(parameters);
            string fractal = generator.GenerateFractal(5);
            Console.WriteLine(fractal);

            // Создание рендерера фрактала
            FractalRenderer renderer = new FractalRenderer(parameters, _graphics, canvas);
            renderer.SetFractalString(fractal);

            // Рендеринг и отображение фрактала
            renderer.RenderFractal();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ind = comboBox1.SelectedIndex;
            switch (ind)
            {
                case 0:
                    _file_name = l_system_dir + "КриваяКоха.txt";
                    break;
                case 1:
                    _file_name = l_system_dir + "СнежинкаКоха.txt";
                    break;
                case 2:
                    _file_name = l_system_dir + "ТреугольникСерпинского.txt";
                    break;
                case 3:
                    _file_name = l_system_dir + "КоверСерпинского.txt";
                    break;
                case 4:
                    _file_name = l_system_dir + "ШестиугольнаяКриваяГоспера.txt";
                    break;
                case 5:
                    _file_name = l_system_dir + "КриваяГильберта.txt";
                    break;
                case 6:
                    _file_name = l_system_dir + "КриваяДракона.txt";
                    break;
                case 7:
                    _file_name = l_system_dir + "ВысокоеДерево.txt";
                    break;
                case 8:
                    _file_name = l_system_dir + "ШирокоеДерево.txt";
                    break;
                case 9:
                    _file_name = l_system_dir + "Куст.txt";
                    break;
            }
        }
    }
}
