using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using FastBitmap1;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;

namespace Laba2
{
    public partial class Task1 : Form
    {
        public Task1()
        {
            InitializeComponent();
            chart1.Series[0].Name = "";
            chart1.Series[0].Color = Color.White;
        }
        private Bitmap source_image;
        private Bitmap gray_image_1;
        private Bitmap gray_image_2;
        private Bitmap compare_image;


        private void Task1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();

            }
        }

        private void clear_file_Click(object sender, EventArgs e)
        {

            source_pix.Image = null;
            source_pix.Invalidate();

            gray_pix1.Image = null;
            gray_pix1.Invalidate();

            gray_pix2.Image = null;
            gray_pix2.Invalidate();

            compare_pix.Image = null;
            compare_pix.Invalidate();

            source_image = null;
            gray_image_1 = null;
            gray_image_2 = null;
            compare_image = null;

            chart1.Series[0].Points.Clear();
            chart1.Series[0].Name = "";
            chart1.Series[0].Color = Color.White;
        }

        private void open_file_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";

            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    source_image = new Bitmap(open_dialog.FileName);
                    gray_image_1 = new Bitmap(source_image.Width, source_image.Height);
                    gray_image_2 = new Bitmap(source_image.Width, source_image.Height);
                    compare_image = new Bitmap(source_image.Width, source_image.Height);

                    source_pix.Image = source_image;
                    source_pix.Invalidate();
                    gray_pix1.Image = null;
                    gray_pix1.Invalidate();

                    gray_pix2.Image = null;
                    gray_pix2.Invalidate();

                    compare_pix.Image = null;
                    compare_pix.Invalidate();
                    chart1.Series[0].Points.Clear();
                    chart1.Series[0].Name = "";
                    chart1.Series[0].Color = Color.White;
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void convert_to_gray_Click(object sender, EventArgs e)
        {
            if (source_image != null)
            {
                using (var fastBitmap = new FastBitmap(source_image))
                {
                    using (var fast_gray_1 = new FastBitmap(gray_image_1))
                    {
                        using (var fast_gray_2 = new FastBitmap(gray_image_2))
                        {
                            for (var x = 0; x < fastBitmap.Width; x++)
                                for (var y = 0; y < fastBitmap.Height; y++)
                                {

                                    int ntsc = Convert.ToInt32(fastBitmap[x, y].R * 0.3 +
                                                               fastBitmap[x, y].G * 0.59 +
                                                               fastBitmap[x, y].B * 0.11);

                                    int srgb = Convert.ToInt32(fastBitmap[x, y].R * 0.21 +
                                                               fastBitmap[x, y].G * 0.72 +
                                                               fastBitmap[x, y].B * 0.07);

                                    fast_gray_1[x, y] = Color.FromArgb(ntsc, ntsc, ntsc);
                                    fast_gray_2[x, y] = Color.FromArgb(srgb, srgb, srgb);
                                }
                        }
                    }
                }
                gray_pix1.Image = gray_image_1;
                gray_pix1.Invalidate();
                gray_pix2.Image = gray_image_2;
                gray_pix2.Invalidate();
                compare_pix.Image = null;
                compare_pix.Invalidate();

            }
        }

        private void compare_Click(object sender, EventArgs e)
        {
            if (gray_pix1.Image != null && gray_pix2.Image != null 
                && gray_image_1 != null && gray_image_2 != null)
            {
                int min = 255;
                int max = 0;

                using (var fast_comp = new FastBitmap(compare_image))
                {
                    using (var fast_gray_1 = new FastBitmap(gray_image_1))
                    {
                        using (var fast_gray_2 = new FastBitmap(gray_image_2))
                        {
                            for (var x = 0; x < fast_comp.Width; x++)
                                for (var y = 0; y < fast_comp.Height; y++)
                                {
                                    var color = Math.Abs(fast_gray_1[x, y].R - fast_gray_2[x, y].R);
                                    fast_comp[x, y] = Color.FromArgb(color, color, color);
                                    if (color > max) max = color;
                                    if (color < min) min = color;
                                }
                        }
                    }
                    for (var x = 0; x < fast_comp.Width; x++)
                        for (var y = 0; y < fast_comp.Height; y++)
                        {
                            var lin = LinX(Convert.ToInt32(fast_comp[x, y].R), min, max);
                            fast_comp[x, y] = Color.FromArgb(lin, lin, lin);
                        }
                }
                compare_pix.Image = compare_image;
                compare_pix.Invalidate();
            }
        }

        private int LinX(int x, int a, int b)
        {
            return (x - a) * 255 / (b - a + 1);
        }

        private void GenerateColorHistogram(Bitmap mage, string name)
        {
            int[] histogram = new int[256]; // 256 possible color values
            using (var fastBitmap = new FastBitmap(mage))
            {
                for (int x = 0; x < fastBitmap.Width; x++)
                {
                    for (int y = 0; y < fastBitmap.Height; y++)
                    {
                        int value = fastBitmap[x, y].R;

                        histogram[value]++;
                    }
                }
            }
            chart1.Series[0].Points.Clear();
            for (int i = 0; i < histogram.Length - 1; i++)
            {
                chart1.Series[0].Points.Add(histogram[i]);
            }

            chart1.Series[0].Color = Color.Gray;
            chart1.Series[0].Name = name;
        }

        private void gray_pix1_Click(object sender, EventArgs e)
        {
            if (gray_pix1.Image != null && gray_image_1 != null)
            {
                GenerateColorHistogram(gray_image_1, "NTSC");
            }
        }

        private void gray_pix2_Click(object sender, EventArgs e)
        {
            if (gray_pix2.Image != null && gray_image_2 != null)
            {
                GenerateColorHistogram(gray_image_1, "sRGB");
            }
        }
    }
}
