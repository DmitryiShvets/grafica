namespace Laba5
{
    partial class Task1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_draw = new System.Windows.Forms.Button();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.list_fractals = new System.Windows.Forms.ComboBox();
            this.track_gen = new System.Windows.Forms.TrackBar();
            this.min_rand = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.max_rand = new System.Windows.Forms.TextBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_gen)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_draw
            // 
            this.btn_draw.Location = new System.Drawing.Point(829, 89);
            this.btn_draw.Name = "btn_draw";
            this.btn_draw.Size = new System.Drawing.Size(89, 23);
            this.btn_draw.TabIndex = 0;
            this.btn_draw.Text = "Нарисовать";
            this.btn_draw.UseVisualStyleBackColor = true;
            this.btn_draw.Click += new System.EventHandler(this.btn_draw_Click);
            // 
            // canvas
            // 
            this.canvas.Location = new System.Drawing.Point(12, 12);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(800, 600);
            this.canvas.TabIndex = 1;
            this.canvas.TabStop = false;
            // 
            // list_fractals
            // 
            this.list_fractals.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list_fractals.FormattingEnabled = true;
            this.list_fractals.Items.AddRange(new object[] {
            "Кривая Коха",
            "Снежинка Коха",
            "Квадратный остров Коха",
            "Треугольник Серпинского",
            "НаконечникСерпинского",
            "Кривая Гильберта",
            "Кривая дракона Хартера-Хейтуэя ",
            "Шестиугольная кривая Госпера",
            "Куст 1",
            "Куст 2",
            "Куст 3",
            "Шестиугольная мозаика",
            "Высокое Дерево",
            "Широкое Дерево",
            "Случайное Дерево"});
            this.list_fractals.Location = new System.Drawing.Point(831, 52);
            this.list_fractals.Name = "list_fractals";
            this.list_fractals.Size = new System.Drawing.Size(225, 28);
            this.list_fractals.TabIndex = 2;
            this.list_fractals.Text = "Кривая Коха";
            this.list_fractals.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // track_gen
            // 
            this.track_gen.Location = new System.Drawing.Point(839, 209);
            this.track_gen.Minimum = 1;
            this.track_gen.Name = "track_gen";
            this.track_gen.Size = new System.Drawing.Size(104, 45);
            this.track_gen.TabIndex = 4;
            this.track_gen.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.track_gen.Value = 1;
            this.track_gen.ValueChanged += new System.EventHandler(this.track_gen_ValueChanged);
            // 
            // min_rand
            // 
            this.min_rand.Location = new System.Drawing.Point(861, 156);
            this.min_rand.Name = "min_rand";
            this.min_rand.Size = new System.Drawing.Size(45, 20);
            this.min_rand.TabIndex = 5;
            this.min_rand.Text = "0";
            this.min_rand.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.min_rand_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(838, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Рандом";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(835, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "От";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(912, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "До";
            // 
            // max_rand
            // 
            this.max_rand.Location = new System.Drawing.Point(940, 156);
            this.max_rand.Name = "max_rand";
            this.max_rand.Size = new System.Drawing.Size(45, 20);
            this.max_rand.TabIndex = 5;
            this.max_rand.Text = "45";
            this.max_rand.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.min_rand_KeyPress);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(924, 89);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(89, 23);
            this.btn_clear.TabIndex = 0;
            this.btn_clear.Text = "Очистить";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(838, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Поколение:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(831, 276);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 20);
            this.label5.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(937, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(901, 308);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 20);
            this.label7.TabIndex = 7;
            // 
            // Task1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 627);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.max_rand);
            this.Controls.Add(this.min_rand);
            this.Controls.Add(this.track_gen);
            this.Controls.Add(this.list_fractals);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_draw);
            this.Name = "Task1";
            this.Text = "Task1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Task1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_gen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_draw;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.ComboBox list_fractals;
        private System.Windows.Forms.TrackBar track_gen;
        private System.Windows.Forms.TextBox min_rand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox max_rand;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}