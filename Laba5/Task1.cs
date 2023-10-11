using System;
using System.Collections.Generic;

using System.Drawing;
using System.Globalization;
using System.Linq;

using System.Windows.Forms;
using System.IO;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Net.NetworkInformation;
using System.Reflection.Emit;

namespace Laba5
{
    public partial class Task1 : Form
    {
        private static string l_system_dir = "../../L-systems/";
        private Graphics _graphics;
        private Bitmap _bitmap;
        private string _cur_fractal = l_system_dir + "КриваяКоха.txt";
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
            private string _fractal_str;
            private Graphics m_graphics;
            private PictureBox m_pictureBox;
            private bool is_tree = false;
            private Pen pen = new Pen(Color.Black);
            private int rand_min;
            private int rand_max;

            // центр окна
            private PointF center;
            // центр полученного фрактала
            private PointF center_fractal;
            // шаг для масштабирования
            private float step;
            public FractalRenderer(LSystemParameters parameters, Graphics graphics, PictureBox pictureBox, TextBox min, TextBox max)
            {
                rand_min = min.Text != "" ? Int32.Parse(min.Text) : 0;
                rand_max = max.Text != "" ? Int32.Parse(max.Text) : 0;
                m_graphics = graphics;
                m_pictureBox = pictureBox;

                _parameters = parameters;
                _fractal_str = "";

                center = new PointF(m_pictureBox.Width / 2, m_pictureBox.Height / 2);

                pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

                if (_parameters.Name.Contains("Дерево") || _parameters.Name.Contains("Куст")) is_tree = true;
            }

            public void SetFractalString(string fractalString)
            {
                _fractal_str = fractalString;
            }

            public void RenderFractal()
            {

                Stack<(PointF, float, Color, float, bool)> stateStack = new Stack<(PointF, float, Color, float, bool)>();
                List<Tuple<PointF, PointF>> points = new List<Tuple<PointF, PointF>>();
                Dictionary<PointF, Tuple<Color, float>> gr = new Dictionary<PointF, Tuple<Color, float>>();
                Random rand = new Random();

                if (rand_min > rand_max)
                {
                    (rand_min, rand_max) = (rand_max, rand_min);
                }

                bool randomize = false;
                bool thin = false;

                int count = 0;
                float width = 7;
                if (_parameters.Name.Contains("ВысокоеДерево")) width = 10;
                if (_parameters.Name.Contains("ШирокоеДерево")) width = 11;
                if (_parameters.Name.Contains("СлучайноеДерево")) width = 10;
                if (is_tree) randomize = true;

                Color color = Color.FromArgb(64, 0, 0);
                PointF point = new PointF(0, 0);
                float cur_angle = _parameters.RDirection;

                foreach (char symbol in _fractal_str)
                {
                    switch (symbol)
                    {
                        case 'F': // Движение вперед
                            float newX = point.X + (float)Math.Cos(cur_angle);
                            float newY = point.Y + (float)Math.Sin(cur_angle);
                            PointF new_point = new PointF(newX, newY);
                            points.Add(Tuple.Create(point, new_point));

                            if (is_tree)
                            {
                                if (count < 3)
                                {
                                    width--;
                                    count++;
                                }
                                gr[point] = new Tuple<Color, float>(color, width);
                            }
                            point = new_point;

                            break;

                        case '+': // Поворот по часовой стрелке
                            if (randomize)
                            {
                                float rand_angle = rand.Next(rand_min, rand_max + 1) * (float)Math.PI / 180;
                                cur_angle += rand_angle;
                            }
                            else
                            {
                                cur_angle += _parameters.RAngle;
                            }
                            break;

                        case '-': // Поворот против часовой стрелки
                            if (randomize)
                            {
                                float rand_angle = rand.Next(rand_min, rand_max + 1) * (float)Math.PI / 180;
                                cur_angle -= rand_angle;
                            }
                            else
                            {
                                cur_angle -= _parameters.RAngle;
                            }
                            break;

                        case '[': // Сохранение состояния
                            stateStack.Push((point, cur_angle, color, width, thin));

                            if (is_tree && thin)
                            {
                                color = color.G + 20 > 255 ? Color.FromArgb(color.R, 255, color.B) : Color.FromArgb(color.R, color.G + 20, color.B);
                                width--;
                            }

                            break;

                        case ']': // Восстановление состояния

                            if (is_tree && thin)
                            {
                                color = color.G - 20 < 0 ? Color.FromArgb(color.R, 0, color.B) : Color.FromArgb(color.R, color.G - 20, color.B);
                            }
                            (point, cur_angle, color, width, thin) = stateStack.Pop();
                            if (thin == true) thin = false;

                            break;
                        case '@': // для осветления текущего цвета рисования, уменьшения толщины и длины штрихов
                            thin = true;
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
                step = Math.Min(m_pictureBox.Width / (maxX - minX), (m_pictureBox.Height - 1) / (maxY - minY));

                List<Tuple<PointF, PointF>> scale_points = new List<Tuple<PointF, PointF>>(points);
                // масштабируем список точек
                for (int i = 0; i < points.Count(); i++)
                {
                    float scaleX = center.X + (points[i].Item1.X - center_fractal.X) * step;
                    float scaleY = center.Y + (points[i].Item1.Y - center_fractal.Y) * step;
                    float scaleNextX = center.X + (points[i].Item2.X - center_fractal.X) * step;
                    float scaleNextY = center.Y + (points[i].Item2.Y - center_fractal.Y) * step;

                    scale_points[i] = new Tuple<PointF, PointF>(new PointF(scaleX, scaleY), new PointF(scaleNextX, scaleNextY));
                }

                if (is_tree)
                {
                    for (int i = 0; i < points.Count(); ++i)
                        m_graphics.DrawLine(new Pen(gr[points[i].Item1].Item1, gr[points[i].Item1].Item2), scale_points[i].Item1, scale_points[i].Item2);
                }
                else
                {
                    for (int i = 0; i < points.Count(); ++i)
                        m_graphics.DrawLine(new Pen(Color.Black), scale_points[i].Item1, scale_points[i].Item2);
                }

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
                if (iterations > _parameters.GMax) iterations = _parameters.GMax;
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
            public int GMax { get; set; }
            public string Name { get; set; }
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
                        GMax = Int32.Parse(lines[0].Split(' ')[3]);
                        RuleDictionary = new Dictionary<char, string>();
                        Name = filePath;
                        for (int i = 1; i < lines.Length; i++)
                        {
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

        private void Draw()
        {
            _graphics.Clear(Color.White);
            LSystemParameters parameters = new LSystemParameters(_cur_fractal);

            FractalGenerator generator = new FractalGenerator(parameters);
            string fractal = generator.GenerateFractal(track_gen.Value);
            Console.WriteLine(fractal);

            // Создание рендерера фрактала
            FractalRenderer renderer = new FractalRenderer(parameters, _graphics, canvas, min_rand, max_rand);
            renderer.SetFractalString(fractal);

            // Рендеринг и отображение фрактала
            renderer.RenderFractal();
            label5.Text = "";
            label5.Text += "Фрактал инфо:\n";
            label5.Text += "Axiom: " + parameters.Axiom + '\n';
            label5.Text += "Rotation Angle: " + parameters.RAngle + '\n';
            label5.Text += "Rotation Direction: " + parameters.RDirection + '\n';
            label5.Text += "Rules:";
            foreach (var kvp in parameters.RuleDictionary)
            {
                label5.Text += kvp.Key + " -> " + kvp.Value + '\n';
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ind = list_fractals.SelectedIndex;
            switch (ind)
            {
                case 0:
                    _cur_fractal = l_system_dir + "КриваяКоха" + ".txt";
                    break;
                case 1:
                    _cur_fractal = l_system_dir + "СнежинкаКоха" + ".txt";
                    break;
                case 2:
                    _cur_fractal = l_system_dir + "КвадратныйОстровКоха" + ".txt";
                    break;
                case 3:
                    _cur_fractal = l_system_dir + "ТреугольникСерпинского" + ".txt";
                    break;
                case 4:
                    _cur_fractal = l_system_dir + "НаконечникСерпинского" + ".txt";
                    break;
                case 5:
                    _cur_fractal = l_system_dir + "КриваяГильберта" + ".txt";
                    break;
                case 6:
                    _cur_fractal = l_system_dir + "КриваяДракона" + ".txt";
                    break;
                case 7:
                    _cur_fractal = l_system_dir + "ШестиугольнаяКриваяГоспера" + ".txt";
                    break;
                case 8:
                    _cur_fractal = l_system_dir + "Куст1" + ".txt";
                    break;
                case 9:
                    _cur_fractal = l_system_dir + "Куст2" + ".txt";
                    break;
                case 10:
                    _cur_fractal = l_system_dir + "Куст3" + ".txt";
                    break;
                case 11:
                    _cur_fractal = l_system_dir + "ШестиугольнаяМозаика" + ".txt";
                    break;
                case 12:
                    _cur_fractal = l_system_dir + "ВысокоеДерево" + ".txt";
                    break;
                case 13:
                    _cur_fractal = l_system_dir + "ШирокоеДерево" + ".txt";
                    break;
                case 14:
                    _cur_fractal = l_system_dir + "СлучайноеДерево" + ".txt";
                    break;
            }
            Draw();
        }
        private void btn_draw_Click(object sender, EventArgs e)
        {
            Draw();
        }
        private void btn_gen_KeyPress(object sender, KeyPressEventArgs e)
        {
            char el = e.KeyChar;
            if (!Char.IsDigit(el) && el != (char)Keys.Back) // можно вводить только цифры и стирать
                e.Handled = true;
        }
        private void track_gen_ValueChanged(object sender, EventArgs e)
        {
            Draw();
            label6.Text = track_gen.Value.ToString();
        }
        private void min_rand_KeyPress(object sender, KeyPressEventArgs e)
        {
            char el = e.KeyChar;
            if (!Char.IsDigit(el) && el != (char)Keys.Back && el != '-') // можно вводить только цифры, минус и стирать
                e.Handled = true;
        }
        private void btn_clear_Click(object sender, EventArgs e)
        {
            _graphics.Clear(Color.White);
            canvas.Invalidate();
        }
    }
}
