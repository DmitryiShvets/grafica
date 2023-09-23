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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button_pen_color = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.button_choose_pen = new System.Windows.Forms.Button();
            this.button_choose_cleaner = new System.Windows.Forms.Button();
            this.button_clean = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(214, 141);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(662, 464);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // button_pen_color
            // 
            this.button_pen_color.Location = new System.Drawing.Point(94, 236);
            this.button_pen_color.Margin = new System.Windows.Forms.Padding(2);
            this.button_pen_color.Name = "button_pen_color";
            this.button_pen_color.Size = new System.Drawing.Size(22, 24);
            this.button_pen_color.TabIndex = 36;
            this.button_pen_color.UseVisualStyleBackColor = true;
            this.button_pen_color.Click += new System.EventHandler(this.button_pen_color_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.Color.White;
            this.trackBar1.Location = new System.Drawing.Point(12, 322);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar1.Maximum = 30;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(179, 45);
            this.trackBar1.TabIndex = 38;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // button_choose_pen
            // 
            this.button_choose_pen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.button_choose_pen.Location = new System.Drawing.Point(21, 234);
            this.button_choose_pen.Margin = new System.Windows.Forms.Padding(2);
            this.button_choose_pen.Name = "button_choose_pen";
            this.button_choose_pen.Size = new System.Drawing.Size(69, 24);
            this.button_choose_pen.TabIndex = 39;
            this.button_choose_pen.Text = "карандаш";
            this.button_choose_pen.UseVisualStyleBackColor = true;
            this.button_choose_pen.Click += new System.EventHandler(this.button_choose_pen_Click);
            // 
            // button_choose_cleaner
            // 
            this.button_choose_cleaner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button_choose_cleaner.Location = new System.Drawing.Point(21, 263);
            this.button_choose_cleaner.Margin = new System.Windows.Forms.Padding(2);
            this.button_choose_cleaner.Name = "button_choose_cleaner";
            this.button_choose_cleaner.Size = new System.Drawing.Size(69, 24);
            this.button_choose_cleaner.TabIndex = 40;
            this.button_choose_cleaner.Text = "ластик";
            this.button_choose_cleaner.UseVisualStyleBackColor = true;
            this.button_choose_cleaner.Click += new System.EventHandler(this.button_choose_cleaner_Click);
            // 
            // button_clean
            // 
            this.button_clean.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.button_clean.Location = new System.Drawing.Point(94, 265);
            this.button_clean.Margin = new System.Windows.Forms.Padding(2);
            this.button_clean.Name = "button_clean";
            this.button_clean.Size = new System.Drawing.Size(97, 23);
            this.button_clean.TabIndex = 41;
            this.button_clean.Text = "Очистить все";
            this.button_clean.UseVisualStyleBackColor = true;
            this.button_clean.Click += new System.EventHandler(this.button_clean_Click);
            // 
            // Task1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(885, 614);
            this.Controls.Add(this.button_clean);
            this.Controls.Add(this.button_choose_cleaner);
            this.Controls.Add(this.button_choose_pen);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button_pen_color);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Task1";
            this.Text = "Задание №1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Task3_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button_pen_color;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button button_choose_pen;
        private System.Windows.Forms.Button button_choose_cleaner;
        private System.Windows.Forms.Button button_clean;
    }
}

