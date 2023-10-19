namespace blank
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
            this.canvas = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cur_info = new System.Windows.Forms.Label();
            this.vertex_a = new System.Windows.Forms.Label();
            this.vertex_b = new System.Windows.Forms.Label();
            this.vertex_c = new System.Windows.Forms.Label();
            this.ortho_x_plus = new System.Windows.Forms.RadioButton();
            this.ortho_x_minus = new System.Windows.Forms.RadioButton();
            this.ortho_y_plus = new System.Windows.Forms.RadioButton();
            this.ortho_y_minus = new System.Windows.Forms.RadioButton();
            this.ortho_z_plus = new System.Windows.Forms.RadioButton();
            this.ortho_z_minus = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Location = new System.Drawing.Point(90, 160);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(500, 400);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cur_info
            // 
            this.cur_info.AutoSize = true;
            this.cur_info.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cur_info.Location = new System.Drawing.Point(625, 71);
            this.cur_info.Name = "cur_info";
            this.cur_info.Size = new System.Drawing.Size(70, 22);
            this.cur_info.TabIndex = 2;
            this.cur_info.Text = "label1";
            // 
            // vertex_a
            // 
            this.vertex_a.AutoSize = true;
            this.vertex_a.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vertex_a.Location = new System.Drawing.Point(12, 180);
            this.vertex_a.Name = "vertex_a";
            this.vertex_a.Size = new System.Drawing.Size(20, 22);
            this.vertex_a.TabIndex = 2;
            this.vertex_a.Text = "a";
            // 
            // vertex_b
            // 
            this.vertex_b.AutoSize = true;
            this.vertex_b.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vertex_b.Location = new System.Drawing.Point(12, 281);
            this.vertex_b.Name = "vertex_b";
            this.vertex_b.Size = new System.Drawing.Size(20, 22);
            this.vertex_b.TabIndex = 2;
            this.vertex_b.Text = "a";
            // 
            // vertex_c
            // 
            this.vertex_c.AutoSize = true;
            this.vertex_c.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vertex_c.Location = new System.Drawing.Point(12, 376);
            this.vertex_c.Name = "vertex_c";
            this.vertex_c.Size = new System.Drawing.Size(20, 22);
            this.vertex_c.TabIndex = 2;
            this.vertex_c.Text = "a";
            // 
            // ortho_x_plus
            // 
            this.ortho_x_plus.AutoSize = true;
            this.ortho_x_plus.Location = new System.Drawing.Point(17, 37);
            this.ortho_x_plus.Name = "ortho_x_plus";
            this.ortho_x_plus.Size = new System.Drawing.Size(38, 17);
            this.ortho_x_plus.TabIndex = 3;
            this.ortho_x_plus.TabStop = true;
            this.ortho_x_plus.Text = "+X";
            this.ortho_x_plus.UseVisualStyleBackColor = true;
            this.ortho_x_plus.CheckedChanged += new System.EventHandler(this.ortho_x_plus_CheckedChanged);
            // 
            // ortho_x_minus
            // 
            this.ortho_x_minus.AutoSize = true;
            this.ortho_x_minus.Location = new System.Drawing.Point(17, 55);
            this.ortho_x_minus.Name = "ortho_x_minus";
            this.ortho_x_minus.Size = new System.Drawing.Size(35, 17);
            this.ortho_x_minus.TabIndex = 3;
            this.ortho_x_minus.TabStop = true;
            this.ortho_x_minus.Text = "-X";
            this.ortho_x_minus.UseVisualStyleBackColor = true;
            this.ortho_x_minus.CheckedChanged += new System.EventHandler(this.ortho_x_minus_CheckedChanged);
            // 
            // ortho_y_plus
            // 
            this.ortho_y_plus.AutoSize = true;
            this.ortho_y_plus.Location = new System.Drawing.Point(58, 37);
            this.ortho_y_plus.Name = "ortho_y_plus";
            this.ortho_y_plus.Size = new System.Drawing.Size(38, 17);
            this.ortho_y_plus.TabIndex = 3;
            this.ortho_y_plus.TabStop = true;
            this.ortho_y_plus.Text = "+Y";
            this.ortho_y_plus.UseVisualStyleBackColor = true;
            this.ortho_y_plus.CheckedChanged += new System.EventHandler(this.ortho_y_plus_CheckedChanged);
            // 
            // ortho_y_minus
            // 
            this.ortho_y_minus.AutoSize = true;
            this.ortho_y_minus.Location = new System.Drawing.Point(58, 55);
            this.ortho_y_minus.Name = "ortho_y_minus";
            this.ortho_y_minus.Size = new System.Drawing.Size(35, 17);
            this.ortho_y_minus.TabIndex = 3;
            this.ortho_y_minus.TabStop = true;
            this.ortho_y_minus.Text = "-Y";
            this.ortho_y_minus.UseVisualStyleBackColor = true;
            this.ortho_y_minus.CheckedChanged += new System.EventHandler(this.ortho_y_minus_CheckedChanged);
            // 
            // ortho_z_plus
            // 
            this.ortho_z_plus.AutoSize = true;
            this.ortho_z_plus.Location = new System.Drawing.Point(99, 37);
            this.ortho_z_plus.Name = "ortho_z_plus";
            this.ortho_z_plus.Size = new System.Drawing.Size(38, 17);
            this.ortho_z_plus.TabIndex = 3;
            this.ortho_z_plus.TabStop = true;
            this.ortho_z_plus.Text = "+Z";
            this.ortho_z_plus.UseVisualStyleBackColor = true;
            this.ortho_z_plus.CheckedChanged += new System.EventHandler(this.ortho_z_plus_CheckedChanged);
            // 
            // ortho_z_minus
            // 
            this.ortho_z_minus.AutoSize = true;
            this.ortho_z_minus.Location = new System.Drawing.Point(99, 55);
            this.ortho_z_minus.Name = "ortho_z_minus";
            this.ortho_z_minus.Size = new System.Drawing.Size(35, 17);
            this.ortho_z_minus.TabIndex = 3;
            this.ortho_z_minus.TabStop = true;
            this.ortho_z_minus.Text = "-Z";
            this.ortho_z_minus.UseVisualStyleBackColor = true;
            this.ortho_z_minus.CheckedChanged += new System.EventHandler(this.ortho_z_minus_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ortho_y_minus);
            this.groupBox1.Controls.Add(this.ortho_z_minus);
            this.groupBox1.Controls.Add(this.ortho_x_plus);
            this.groupBox1.Controls.Add(this.ortho_z_plus);
            this.groupBox1.Controls.Add(this.ortho_x_minus);
            this.groupBox1.Controls.Add(this.ortho_y_plus);
            this.groupBox1.Location = new System.Drawing.Point(111, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Проекция:";
            // 
            // Task1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 588);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.vertex_c);
            this.Controls.Add(this.vertex_b);
            this.Controls.Add(this.vertex_a);
            this.Controls.Add(this.cur_info);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.canvas);
            this.Name = "Task1";
            this.Text = "Task1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Task1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label cur_info;
        private System.Windows.Forms.Label vertex_a;
        private System.Windows.Forms.Label vertex_b;
        private System.Windows.Forms.Label vertex_c;
        private System.Windows.Forms.RadioButton ortho_x_plus;
        private System.Windows.Forms.RadioButton ortho_x_minus;
        private System.Windows.Forms.RadioButton ortho_y_plus;
        private System.Windows.Forms.RadioButton ortho_y_minus;
        private System.Windows.Forms.RadioButton ortho_z_plus;
        private System.Windows.Forms.RadioButton ortho_z_minus;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}