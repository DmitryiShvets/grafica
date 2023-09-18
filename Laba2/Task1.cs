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
//using FastBitmap;
namespace Laba2
{
    public partial class Task1 : Form
    {
        public Task1()
        {
            InitializeComponent();
        }
        private Bitmap source_image; //Bitmap для открываемого изображения
        private Bitmap gray_image_1; //Bitmap для открываемого изображения
        private Bitmap gray_image_2; //Bitmap для открываемого изображения


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
            if (source_pix.Image != null)
            {
                //source_pix.Image.Dispose();
                source_pix.Image = null;
                source_pix.Invalidate();
            }

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
                    source_pix.Image = source_image;
                    source_pix.Invalidate();
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
            using (var fastBitmap = new FastBitmap.FastBitmap(source_image))
            {
                for (var x = 0; x < fastBitmap.Width; x++)
                    for (var y = 0; y < fastBitmap.Height; y++)
                    {
                        var gray_1 = new FastBitmap.FastBitmap(gray_image_1);
                        var gray_2 = new FastBitmap.FastBitmap(gray_image_2);

                        int ntsc = Convert.ToInt32(fastBitmap[x, y].R * 0.3 + fastBitmap[x, y].G * 0.59 + fastBitmap[x, y].B * 0.11);
                        int srgb = Convert.ToInt32(fastBitmap[x, y].R * 0.21 + fastBitmap[x, y].G * 0.72 + fastBitmap[x, y].B * 0.07);
                        gray_1[x, y] = Color.FromArgb(
                            ntsc,
                            ntsc,
                            ntsc
                        );
                        gray_2[x, y] = Color.FromArgb(
                            srgb,
                            srgb,
                            srgb
                        );
                    }
            }
            gray_pix1.Image = gray_image_1;
            gray_pix1.Invalidate();
            gray_pix2.Image = gray_image_2;
            gray_pix2.Invalidate();

        }

        private void compare_Click(object sender, EventArgs e)
        {

        }

        private void source_pix_Click(object sender, EventArgs e)
        {

        }
    }
}
