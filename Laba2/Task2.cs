using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastBitmap;

namespace Laba2
{
    public partial class Task2 : Form
    {
        private Image image;
        private Bitmap editedImage;

        public Task2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.png)|*.jpg;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Загрузка изображения
                image = Image.FromFile(openFileDialog.FileName);
                pictureBox.Image = image;

                // Создание Bitmap для редактирования и отображения
                editedImage = new Bitmap(image.Width, image.Height);
                button_red.Enabled = true;
                button_green.Enabled = true;
                button_blue.Enabled = true;
            }
        }

        private void Task2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void button_red_Click(object sender, EventArgs e)
        {
            ExtractChannel("red");
        }

        private void button_green_Click(object sender, EventArgs e)
        {
            ExtractChannel("green");
        }

        private void button_blue_Click(object sender, EventArgs e)
        {
            ExtractChannel("blue");
        }

        private void ExtractChannel(string color)
        {
            // Проход по каждому пикселю изображения
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    // Получение цвета пикселя
                    Color pixelColor = ((Bitmap)image).GetPixel(x, y);
                    Color newColor = Color.White;
                    switch (color)
                    {
                        case "red":
                            newColor = Color.FromArgb(pixelColor.R, 0, 0);
                            break;
                        case "green":
                            newColor = Color.FromArgb(0, pixelColor.G, 0);
                            break;
                        case "blue":
                            newColor = Color.FromArgb(0, 0, pixelColor.B);
                            break;
                    }

                    // Установка нового цвета для пикселя в отредактированном изображении
                    editedImage.SetPixel(x, y, newColor);
                }
            }

            // Отображение отредактированного изображения на PictureBox
            pictureBox.Image = editedImage;
        }
    }
}
