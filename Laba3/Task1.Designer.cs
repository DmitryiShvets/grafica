namespace Laba3
{
    partial class Task1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.with_bar = new System.Windows.Forms.TrackBar();
            this.btn_color = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_color_2 = new System.Windows.Forms.Button();
            this.filling_pix = new System.Windows.Forms.PictureBox();
            this.btn_filling_border = new System.Windows.Forms.Button();
            this.btn_filling_image = new System.Windows.Forms.Button();
            this.btn_load_image = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_eraser = new System.Windows.Forms.Button();
            this.btn_filling = new System.Windows.Forms.Button();
            this.btn_pen = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.with_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filling_pix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // with_bar
            // 
            this.with_bar.Location = new System.Drawing.Point(302, 17);
            this.with_bar.Minimum = 1;
            this.with_bar.Name = "with_bar";
            this.with_bar.Size = new System.Drawing.Size(77, 45);
            this.with_bar.TabIndex = 44;
            this.with_bar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip1.SetToolTip(this.with_bar, "Толщина кисти");
            this.with_bar.Value = 3;
            this.with_bar.ValueChanged += new System.EventHandler(this.with_bar_ValueChanged);
            // 
            // btn_color
            // 
            this.btn_color.BackColor = System.Drawing.Color.Black;
            this.btn_color.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_color.Location = new System.Drawing.Point(385, 17);
            this.btn_color.Name = "btn_color";
            this.btn_color.Size = new System.Drawing.Size(40, 40);
            this.btn_color.TabIndex = 43;
            this.toolTip1.SetToolTip(this.btn_color, "Основной цвет (ЛКМ)");
            this.btn_color.UseVisualStyleBackColor = false;
            this.btn_color.Click += new System.EventHandler(this.btn_color_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(578, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "label1";
            // 
            // btn_color_2
            // 
            this.btn_color_2.BackColor = System.Drawing.Color.Yellow;
            this.btn_color_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_color_2.Location = new System.Drawing.Point(431, 17);
            this.btn_color_2.Name = "btn_color_2";
            this.btn_color_2.Size = new System.Drawing.Size(40, 40);
            this.btn_color_2.TabIndex = 43;
            this.toolTip1.SetToolTip(this.btn_color_2, "Дополнительный цвет (ПКМ)");
            this.btn_color_2.UseVisualStyleBackColor = false;
            this.btn_color_2.Click += new System.EventHandler(this.btn_color_2_Click);
            // 
            // filling_pix
            // 
            this.filling_pix.BackColor = System.Drawing.Color.Transparent;
            this.filling_pix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filling_pix.Location = new System.Drawing.Point(773, 62);
            this.filling_pix.Name = "filling_pix";
            this.filling_pix.Size = new System.Drawing.Size(72, 73);
            this.filling_pix.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.filling_pix.TabIndex = 46;
            this.filling_pix.TabStop = false;
            this.toolTip1.SetToolTip(this.filling_pix, "Паттерн для заливки");
            // 
            // btn_filling_border
            // 
            this.btn_filling_border.BackColor = System.Drawing.Color.Transparent;
            this.btn_filling_border.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_filling_border.Image = global::Laba3.Properties.Resources.icons8_bord;
            this.btn_filling_border.Location = new System.Drawing.Point(73, 108);
            this.btn_filling_border.Name = "btn_filling_border";
            this.btn_filling_border.Size = new System.Drawing.Size(40, 40);
            this.btn_filling_border.TabIndex = 43;
            this.toolTip1.SetToolTip(this.btn_filling_border, "Выделение границы");
            this.btn_filling_border.UseVisualStyleBackColor = false;
            this.btn_filling_border.Click += new System.EventHandler(this.btn_filling_border_Click);
            // 
            // btn_filling_image
            // 
            this.btn_filling_image.BackColor = System.Drawing.Color.Transparent;
            this.btn_filling_image.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_filling_image.Image = global::Laba3.Properties.Resources.icons8_filling_file;
            this.btn_filling_image.Location = new System.Drawing.Point(73, 62);
            this.btn_filling_image.Name = "btn_filling_image";
            this.btn_filling_image.Size = new System.Drawing.Size(40, 40);
            this.btn_filling_image.TabIndex = 43;
            this.toolTip1.SetToolTip(this.btn_filling_image, "Заливка изображения");
            this.btn_filling_image.UseVisualStyleBackColor = false;
            this.btn_filling_image.Click += new System.EventHandler(this.btn_filling_image_Click);
            // 
            // btn_load_image
            // 
            this.btn_load_image.BackColor = System.Drawing.Color.Transparent;
            this.btn_load_image.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_load_image.Image = global::Laba3.Properties.Resources.icons8_load_file;
            this.btn_load_image.Location = new System.Drawing.Point(118, 17);
            this.btn_load_image.Name = "btn_load_image";
            this.btn_load_image.Size = new System.Drawing.Size(40, 40);
            this.btn_load_image.TabIndex = 43;
            this.toolTip1.SetToolTip(this.btn_load_image, "Выбрать файл");
            this.btn_load_image.UseVisualStyleBackColor = false;
            this.btn_load_image.Click += new System.EventHandler(this.btn_load_image_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Image = global::Laba3.Properties.Resources.icons8_clear;
            this.btn_clear.Location = new System.Drawing.Point(256, 17);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(40, 40);
            this.btn_clear.TabIndex = 43;
            this.toolTip1.SetToolTip(this.btn_clear, "Очистить");
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_eraser
            // 
            this.btn_eraser.Image = global::Laba3.Properties.Resources.icons8_eraser;
            this.btn_eraser.Location = new System.Drawing.Point(210, 17);
            this.btn_eraser.Name = "btn_eraser";
            this.btn_eraser.Size = new System.Drawing.Size(40, 40);
            this.btn_eraser.TabIndex = 43;
            this.toolTip1.SetToolTip(this.btn_eraser, "Стерка");
            this.btn_eraser.UseVisualStyleBackColor = true;
            this.btn_eraser.Click += new System.EventHandler(this.btn_eraser_Click);
            // 
            // btn_filling
            // 
            this.btn_filling.Image = global::Laba3.Properties.Resources.icons8_filling_border;
            this.btn_filling.Location = new System.Drawing.Point(73, 154);
            this.btn_filling.Name = "btn_filling";
            this.btn_filling.Size = new System.Drawing.Size(40, 40);
            this.btn_filling.TabIndex = 43;
            this.toolTip1.SetToolTip(this.btn_filling, "Обычная заливка");
            this.btn_filling.UseVisualStyleBackColor = true;
            this.btn_filling.Click += new System.EventHandler(this.btn_filling_Click);
            // 
            // btn_pen
            // 
            this.btn_pen.Image = global::Laba3.Properties.Resources.icons8_pen;
            this.btn_pen.Location = new System.Drawing.Point(164, 17);
            this.btn_pen.Name = "btn_pen";
            this.btn_pen.Size = new System.Drawing.Size(40, 40);
            this.btn_pen.TabIndex = 43;
            this.toolTip1.SetToolTip(this.btn_pen, "Кисть");
            this.btn_pen.UseVisualStyleBackColor = true;
            this.btn_pen.Click += new System.EventHandler(this.btn_pen_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(118, 62);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(650, 450);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // Task1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(885, 614);
            this.Controls.Add(this.filling_pix);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.with_bar);
            this.Controls.Add(this.btn_filling_border);
            this.Controls.Add(this.btn_filling_image);
            this.Controls.Add(this.btn_load_image);
            this.Controls.Add(this.btn_color_2);
            this.Controls.Add(this.btn_color);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_eraser);
            this.Controls.Add(this.btn_filling);
            this.Controls.Add(this.btn_pen);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Task1";
            this.Text = "Задание №1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Task1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.with_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filling_pix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btn_pen;
        private System.Windows.Forms.Button btn_filling;
        private System.Windows.Forms.Button btn_eraser;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.TrackBar with_bar;
        private System.Windows.Forms.Button btn_color;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_color_2;
        private System.Windows.Forms.Button btn_load_image;
        private System.Windows.Forms.Button btn_filling_image;
        private System.Windows.Forms.Button btn_filling_border;
        private System.Windows.Forms.PictureBox filling_pix;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

