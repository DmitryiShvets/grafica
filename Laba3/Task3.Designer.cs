namespace Laba3
{
    partial class Task3
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
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.with_bar = new System.Windows.Forms.TrackBar();
            this.btn_clear = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_alg1 = new System.Windows.Forms.Button();
            this.button_alg2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.with_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // with_bar
            // 
            this.with_bar.LargeChange = 1;
            this.with_bar.Location = new System.Drawing.Point(327, 12);
            this.with_bar.Maximum = 20;
            this.with_bar.Minimum = 1;
            this.with_bar.Name = "with_bar";
            this.with_bar.Size = new System.Drawing.Size(147, 45);
            this.with_bar.TabIndex = 57;
            this.with_bar.Value = 10;
            this.with_bar.Scroll += new System.EventHandler(this.with_bar_Scroll);
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.Color.LightCyan;
            this.btn_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_clear.Location = new System.Drawing.Point(606, 515);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(160, 46);
            this.btn_clear.TabIndex = 53;
            this.btn_clear.Text = "Очистить все";
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(116, 60);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(650, 450);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 47;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // button_alg1
            // 
            this.button_alg1.BackColor = System.Drawing.Color.LightCyan;
            this.button_alg1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_alg1.Location = new System.Drawing.Point(116, 515);
            this.button_alg1.Name = "button_alg1";
            this.button_alg1.Size = new System.Drawing.Size(239, 46);
            this.button_alg1.TabIndex = 58;
            this.button_alg1.Text = "Алгоритм Брезенхема";
            this.button_alg1.UseVisualStyleBackColor = false;
            this.button_alg1.Click += new System.EventHandler(this.button_alg1_Click);
            // 
            // button_alg2
            // 
            this.button_alg2.BackColor = System.Drawing.Color.LightCyan;
            this.button_alg2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_alg2.Location = new System.Drawing.Point(361, 515);
            this.button_alg2.Name = "button_alg2";
            this.button_alg2.Size = new System.Drawing.Size(239, 46);
            this.button_alg2.TabIndex = 58;
            this.button_alg2.Text = "Алгоритм ВУ";
            this.button_alg2.UseVisualStyleBackColor = false;
            this.button_alg2.Click += new System.EventHandler(this.button_alg2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(504, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 20);
            this.label1.TabIndex = 59;
            this.label1.Text = "Выберите алгоритм";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(112, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 20);
            this.label2.TabIndex = 59;
            this.label2.Text = "Увеличение изображения:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Task3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(885, 614);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_alg2);
            this.Controls.Add(this.button_alg1);
            this.Controls.Add(this.with_bar);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Task3";
            this.Text = "Задание №3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Task3_FormClosing);
            this.Load += new System.EventHandler(this.Task3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.with_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TrackBar with_bar;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_alg1;
        private System.Windows.Forms.Button button_alg2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

