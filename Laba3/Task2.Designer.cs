namespace Laba3
{
    partial class Task2
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
            this.button_drawTriangle = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.button_point1 = new System.Windows.Forms.Button();
            this.button_point2 = new System.Windows.Forms.Button();
            this.button_point3 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button_gradient = new System.Windows.Forms.Button();
            this.button_pen_color = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.button_choose_pen = new System.Windows.Forms.Button();
            this.button_choose_cleaner = new System.Windows.Forms.Button();
            this.button_clean = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_drawTriangle
            // 
            this.button_drawTriangle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.button_drawTriangle.Location = new System.Drawing.Point(28, 572);
            this.button_drawTriangle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_drawTriangle.Name = "button_drawTriangle";
            this.button_drawTriangle.Size = new System.Drawing.Size(205, 82);
            this.button_drawTriangle.TabIndex = 0;
            this.button_drawTriangle.Text = "Нарисовать треугольник";
            this.button_drawTriangle.UseVisualStyleBackColor = true;
            this.button_drawTriangle.Click += new System.EventHandler(this.button_drawTriangle_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(285, 174);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(883, 571);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(216, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Задание 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.Location = new System.Drawing.Point(837, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Задание 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label3.Location = new System.Drawing.Point(64, 455);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 31);
            this.label3.TabIndex = 4;
            this.label3.Text = "Задание 3";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label13.Location = new System.Drawing.Point(12, 500);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 20);
            this.label13.TabIndex = 29;
            this.label13.Text = "Точка 1:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label14.Location = new System.Drawing.Point(95, 500);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 20);
            this.label14.TabIndex = 30;
            this.label14.Text = "Точка 2:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label15.Location = new System.Drawing.Point(179, 500);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 20);
            this.label15.TabIndex = 31;
            this.label15.Text = "Точка 3:";
            // 
            // button_point1
            // 
            this.button_point1.BackColor = System.Drawing.SystemColors.ControlText;
            this.button_point1.Location = new System.Drawing.Point(28, 523);
            this.button_point1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_point1.Name = "button_point1";
            this.button_point1.Size = new System.Drawing.Size(43, 43);
            this.button_point1.TabIndex = 32;
            this.button_point1.UseVisualStyleBackColor = false;
            this.button_point1.Click += new System.EventHandler(this.button_point_Click);
            // 
            // button_point2
            // 
            this.button_point2.BackColor = System.Drawing.SystemColors.ControlText;
            this.button_point2.Location = new System.Drawing.Point(109, 523);
            this.button_point2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_point2.Name = "button_point2";
            this.button_point2.Size = new System.Drawing.Size(43, 43);
            this.button_point2.TabIndex = 33;
            this.button_point2.UseVisualStyleBackColor = false;
            this.button_point2.Click += new System.EventHandler(this.button_point_Click);
            // 
            // button_point3
            // 
            this.button_point3.BackColor = System.Drawing.SystemColors.ControlText;
            this.button_point3.Location = new System.Drawing.Point(192, 523);
            this.button_point3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_point3.Name = "button_point3";
            this.button_point3.Size = new System.Drawing.Size(43, 43);
            this.button_point3.TabIndex = 34;
            this.button_point3.UseVisualStyleBackColor = false;
            this.button_point3.Click += new System.EventHandler(this.button_point_Click);
            // 
            // button_gradient
            // 
            this.button_gradient.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.button_gradient.Location = new System.Drawing.Point(28, 661);
            this.button_gradient.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_gradient.Name = "button_gradient";
            this.button_gradient.Size = new System.Drawing.Size(205, 82);
            this.button_gradient.TabIndex = 35;
            this.button_gradient.Text = "Градиент";
            this.button_gradient.UseVisualStyleBackColor = true;
            this.button_gradient.Click += new System.EventHandler(this.button_gradient_Click);
            // 
            // button_pen_color
            // 
            this.button_pen_color.Location = new System.Drawing.Point(125, 290);
            this.button_pen_color.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_pen_color.Name = "button_pen_color";
            this.button_pen_color.Size = new System.Drawing.Size(29, 30);
            this.button_pen_color.TabIndex = 36;
            this.button_pen_color.UseVisualStyleBackColor = true;
            this.button_pen_color.Click += new System.EventHandler(this.button_pen_color_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.Color.White;
            this.trackBar1.Location = new System.Drawing.Point(16, 396);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBar1.Maximum = 30;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(239, 56);
            this.trackBar1.TabIndex = 38;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // button_choose_pen
            // 
            this.button_choose_pen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.button_choose_pen.Location = new System.Drawing.Point(28, 288);
            this.button_choose_pen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_choose_pen.Name = "button_choose_pen";
            this.button_choose_pen.Size = new System.Drawing.Size(92, 30);
            this.button_choose_pen.TabIndex = 39;
            this.button_choose_pen.Text = "карандаш";
            this.button_choose_pen.UseVisualStyleBackColor = true;
            this.button_choose_pen.Click += new System.EventHandler(this.button_choose_pen_Click);
            // 
            // button_choose_cleaner
            // 
            this.button_choose_cleaner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button_choose_cleaner.Location = new System.Drawing.Point(28, 324);
            this.button_choose_cleaner.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_choose_cleaner.Name = "button_choose_cleaner";
            this.button_choose_cleaner.Size = new System.Drawing.Size(92, 30);
            this.button_choose_cleaner.TabIndex = 40;
            this.button_choose_cleaner.Text = "ластик";
            this.button_choose_cleaner.UseVisualStyleBackColor = true;
            this.button_choose_cleaner.Click += new System.EventHandler(this.button_choose_cleaner_Click);
            // 
            // button_clean
            // 
            this.button_clean.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.button_clean.Location = new System.Drawing.Point(125, 326);
            this.button_clean.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_clean.Name = "button_clean";
            this.button_clean.Size = new System.Drawing.Size(129, 28);
            this.button_clean.TabIndex = 41;
            this.button_clean.Text = "Очистить все";
            this.button_clean.UseVisualStyleBackColor = true;
            this.button_clean.Click += new System.EventHandler(this.button_clean_Click);
            // 
            // Task2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1180, 756);
            this.Controls.Add(this.button_clean);
            this.Controls.Add(this.button_choose_cleaner);
            this.Controls.Add(this.button_choose_pen);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button_pen_color);
            this.Controls.Add(this.button_gradient);
            this.Controls.Add(this.button_point3);
            this.Controls.Add(this.button_point2);
            this.Controls.Add(this.button_point1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_drawTriangle);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Task2";
            this.Text = "Задание №2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Task2_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_drawTriangle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button_point1;
        private System.Windows.Forms.Button button_point2;
        private System.Windows.Forms.Button button_point3;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button_gradient;
        private System.Windows.Forms.Button button_pen_color;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button button_choose_pen;
        private System.Windows.Forms.Button button_choose_cleaner;
        private System.Windows.Forms.Button button_clean;
    }
}

