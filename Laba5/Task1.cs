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

namespace Laba5
{
    public partial class Task1 : Form
    {
        public Task1()
        {
            InitializeComponent();
        }

        private void Task1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();

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

            public bool ReadFromFile(string filePath)
            {
                try
                {
                    string[] lines = File.ReadAllLines(filePath);

                    if (lines.Length >= 2)
                    {
                        Axiom = lines[0].Trim();
                        RAngle = float.Parse(lines[1].Split(' ')[0], CultureInfo.InvariantCulture);
                        RDirection = GetRotationDirection(lines[1].Split(' ')[1]);
                        Rules = new List<string>();
                        RuleDictionary = new Dictionary<char, string>();

                        for (int i = 2; i < lines.Length; i++)
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
                catch (Exception)
                {
                    return false;
                }
            }

            private void InitializeRules(string ruleString)
            {
                // Разделить строку правил на части, используя пробел в качестве разделителя
                string[] ruleParts = ruleString.Split(' ');

                // Первая часть строки - символ, который будет заменен
                char symbol = ruleParts[0][0];

                // Вторая часть строки - последовательность символов и операций, которой будет заменен символ
                string replacement = ruleParts[1];

                // Добавить правило в словарь
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
            string filePath = "..\\..\\..\\L-systems\\КриваяКоха.txt";
            // Создание объекта LSystemParameters с параметрами из файла
            LSystemParameters parameters = new LSystemParameters(filePath);

            // Вывод считанных параметров
            parameters.PrintParameters();
        }
    }
}
