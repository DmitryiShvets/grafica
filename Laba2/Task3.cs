using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastBitmap1;

namespace Laba2
{
    public partial class Task3 : Form
    {
        private Bitmap source_image; //Bitmap для открываемого изображения
        private Bitmap edited_image; //Bitmap для открываемого изображения
        public Task3()
        {
            InitializeComponent();
        }

        private void Task3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        struct ColorHSV
        {
            public float hue;
            public float saturation;
            public float value;
        }
        ColorHSV[,] mapHSV;

        private void button_LoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";

            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    source_image = new Bitmap(open_dialog.FileName);
                    edited_image = new Bitmap(source_image.Width, source_image.Height);
                    pictureBox.Image = source_image;
                    pictureBox.Invalidate();
                    mapHSV = new ColorHSV[source_image.Width, source_image.Height];
                    using (var fastBitmap = new FastBitmap(source_image))
                    {
                        for (var x = 0; x < fastBitmap.Width; ++x)
                            for (var y = 0; y < fastBitmap.Height; ++y)
                            {
                                RGBToHSV(fastBitmap[x, y], out mapHSV[x, y].hue, out mapHSV[x, y].saturation, out mapHSV[x, y].value);
                            }
                    }
                    ProcessImage();
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        float hue_change = 0;
        float saturation_change = 0;
        float value_change = 0;
        private void ProcessImage()
        {
            using (var fastBitmap = new FastBitmap(edited_image))
            {
                for (var x = 0; x < fastBitmap.Width; ++x)
                    for (var y = 0; y < fastBitmap.Height; ++y)
                    {
                        fastBitmap[x, y] = HSVToRGB(mapHSV[x, y].hue + hue_change, 
                            Math.Min(1, Math.Max(0, mapHSV[x, y].saturation + saturation_change)), 
                            Math.Min(1, Math.Max(0, mapHSV[x, y].value + value_change)));
                    }
            }
            pictureBox.Image = edited_image;
            pictureBox.Invalidate();
        }

        private void RGBToHSV(Color color, out float hue, out float saturation, out float value)
        {
            float r = color.R / 255.0f;
            float g = color.G / 255.0f;
            float b = color.B / 255.0f;

            float max = Math.Max(Math.Max(r, g), b);
            float min = Math.Min(Math.Min(r, g), b);
            hue = 0;

            if (min == max)
                hue = 0;
            else if (max == r && g >= b)
                hue = 60 * ((g - b) / (max - min)) + 0;
            else if (max == r && g < b)
                hue = 60 * ((g - b) / (max - min)) + 360;
            else if (max == g)
                hue = 60 * ((b - r) / (max - min)) + 120;
            else if (max == b)
                hue = 60 * ((r - g) / (max - min)) + 240;
            hue %= 360;

            value = max;

            if (max == 0)
                saturation = 0;
            else
                saturation = 1 - min / max;
        }
        private Color HSVToRGB(float hue, float saturation, float value)
        {
            int Hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);
            double v = value * 255;
            int vInt = Convert.ToInt32(v);
            int p = Convert.ToInt32(v * (1 - saturation));
            int q = Convert.ToInt32(v * (1 - f * saturation));
            int t = Convert.ToInt32(v * (1 - (1 - f) * saturation));

            switch (Hi)
            {
                case 0:
                    return Color.FromArgb(vInt, t, p);
                case 1:
                    return Color.FromArgb(q, vInt, p);
                case 2:
                    return Color.FromArgb(p, vInt, t);
                case 3:
                    return Color.FromArgb(p, q, vInt);
                case 4:
                    return Color.FromArgb(t, p, vInt);
                default:
                    return Color.FromArgb(vInt, p, q);
            }
        }
        private void SaveImageButton_Click(object sender, EventArgs e)
        {
            if (edited_image == null)
            {
                MessageBox.Show("Сначала загрузите изображение");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JPEG Image|*.jpg";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                edited_image.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
                MessageBox.Show("Изображение успешно сохранено");
            }
        }

        private void hueTrackBar_Scroll(object sender, EventArgs e)
        {
            HueLabel.Text = "Оттенок: " + hueTrackBar.Value;
            hue_change = hueTrackBar.Value;
        }

        private void saturationTrackBar_Scroll(object sender, EventArgs e)
        {
            SaturationLabel.Text = "Насыщенность: " + ((saturationTrackBar.Value - 50) / 50f).ToString(); 
            saturation_change = (saturationTrackBar.Value-50)/50f;
        }

        private void valueTrackBar_Scroll(object sender, EventArgs e)
        {
            ValueLabel.Text = "Интенсивность: " + ((valueTrackBar.Value - 50) / 50f).ToString();
            value_change = (valueTrackBar.Value-50)/50f;
        }

        private void hueTrackBar_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (edited_image != null)
                ProcessImage();
        }

        private void saturationTrackBar_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (edited_image != null)
                ProcessImage();
        }

        private void valueTrackBar_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (edited_image != null)
                ProcessImage();
        }
    }
}
