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
            this.btn_draw = new System.Windows.Forms.Button();
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
            this.perstective = new System.Windows.Forms.RadioButton();
            this.track_zoom = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_transform_apply = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.t_transform_dz = new System.Windows.Forms.TextBox();
            this.t_transform_dy = new System.Windows.Forms.TextBox();
            this.t_transform_dx = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_rotation_apply = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.t_rotation_dz = new System.Windows.Forms.TextBox();
            this.t_rotation_dy = new System.Windows.Forms.TextBox();
            this.t_rotation_dx = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_scale_apply = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.t_scale_dz = new System.Windows.Forms.TextBox();
            this.t_scale_dy = new System.Windows.Forms.TextBox();
            this.t_scale_dx = new System.Windows.Forms.TextBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.track_zoom)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Location = new System.Drawing.Point(109, 136);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(500, 400);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            // 
            // btn_draw
            // 
            this.btn_draw.Location = new System.Drawing.Point(12, 29);
            this.btn_draw.Name = "btn_draw";
            this.btn_draw.Size = new System.Drawing.Size(75, 23);
            this.btn_draw.TabIndex = 1;
            this.btn_draw.Text = "Рисовать";
            this.btn_draw.UseVisualStyleBackColor = true;
            this.btn_draw.Click += new System.EventHandler(this.btn_draw_Click);
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
            this.vertex_a.Location = new System.Drawing.Point(625, 447);
            this.vertex_a.Name = "vertex_a";
            this.vertex_a.Size = new System.Drawing.Size(20, 22);
            this.vertex_a.TabIndex = 2;
            this.vertex_a.Text = "a";
            // 
            // vertex_b
            // 
            this.vertex_b.AutoSize = true;
            this.vertex_b.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vertex_b.Location = new System.Drawing.Point(625, 483);
            this.vertex_b.Name = "vertex_b";
            this.vertex_b.Size = new System.Drawing.Size(20, 22);
            this.vertex_b.TabIndex = 2;
            this.vertex_b.Text = "a";
            // 
            // vertex_c
            // 
            this.vertex_c.AutoSize = true;
            this.vertex_c.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vertex_c.Location = new System.Drawing.Point(625, 514);
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
            this.groupBox1.Controls.Add(this.perstective);
            this.groupBox1.Controls.Add(this.ortho_y_minus);
            this.groupBox1.Controls.Add(this.ortho_z_minus);
            this.groupBox1.Controls.Add(this.ortho_x_plus);
            this.groupBox1.Controls.Add(this.ortho_z_plus);
            this.groupBox1.Controls.Add(this.ortho_x_minus);
            this.groupBox1.Controls.Add(this.ortho_y_plus);
            this.groupBox1.Location = new System.Drawing.Point(109, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Проекция:";
            // 
            // perstective
            // 
            this.perstective.AutoSize = true;
            this.perstective.Location = new System.Drawing.Point(144, 37);
            this.perstective.Name = "perstective";
            this.perstective.Size = new System.Drawing.Size(99, 17);
            this.perstective.TabIndex = 4;
            this.perstective.TabStop = true;
            this.perstective.Text = "PERSPECTIVE";
            this.perstective.UseVisualStyleBackColor = true;
            this.perstective.CheckedChanged += new System.EventHandler(this.perstective_CheckedChanged);
            // 
            // track_zoom
            // 
            this.track_zoom.Location = new System.Drawing.Point(389, 71);
            this.track_zoom.Maximum = 100;
            this.track_zoom.Minimum = 1;
            this.track_zoom.Name = "track_zoom";
            this.track_zoom.Size = new System.Drawing.Size(104, 45);
            this.track_zoom.TabIndex = 5;
            this.track_zoom.TickStyle = System.Windows.Forms.TickStyle.None;
            this.track_zoom.Value = 1;
            this.track_zoom.ValueChanged += new System.EventHandler(this.track_zoom_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_transform_apply);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.t_transform_dz);
            this.groupBox2.Controls.Add(this.t_transform_dy);
            this.groupBox2.Controls.Add(this.t_transform_dx);
            this.groupBox2.Location = new System.Drawing.Point(2, 96);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(101, 113);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Перемещение";
            // 
            // btn_transform_apply
            // 
            this.btn_transform_apply.Location = new System.Drawing.Point(7, 71);
            this.btn_transform_apply.Name = "btn_transform_apply";
            this.btn_transform_apply.Size = new System.Drawing.Size(75, 23);
            this.btn_transform_apply.TabIndex = 2;
            this.btn_transform_apply.Text = "Применить";
            this.btn_transform_apply.UseVisualStyleBackColor = true;
            this.btn_transform_apply.Click += new System.EventHandler(this.btn_transform_apply_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "dz";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "dy";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "dx";
            // 
            // t_transform_dz
            // 
            this.t_transform_dz.Location = new System.Drawing.Point(72, 45);
            this.t_transform_dz.Name = "t_transform_dz";
            this.t_transform_dz.Size = new System.Drawing.Size(23, 20);
            this.t_transform_dz.TabIndex = 0;
            this.t_transform_dz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.t_transform_dx_KeyPress);
            // 
            // t_transform_dy
            // 
            this.t_transform_dy.Location = new System.Drawing.Point(39, 45);
            this.t_transform_dy.Name = "t_transform_dy";
            this.t_transform_dy.Size = new System.Drawing.Size(23, 20);
            this.t_transform_dy.TabIndex = 0;
            this.t_transform_dy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.t_transform_dx_KeyPress);
            // 
            // t_transform_dx
            // 
            this.t_transform_dx.Location = new System.Drawing.Point(7, 45);
            this.t_transform_dx.Name = "t_transform_dx";
            this.t_transform_dx.Size = new System.Drawing.Size(23, 20);
            this.t_transform_dx.TabIndex = 0;
            this.t_transform_dx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.t_transform_dx_KeyPress);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_rotation_apply);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.t_rotation_dz);
            this.groupBox3.Controls.Add(this.t_rotation_dy);
            this.groupBox3.Controls.Add(this.t_rotation_dx);
            this.groupBox3.Location = new System.Drawing.Point(2, 215);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(101, 113);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Вращение";
            // 
            // btn_rotation_apply
            // 
            this.btn_rotation_apply.Location = new System.Drawing.Point(7, 71);
            this.btn_rotation_apply.Name = "btn_rotation_apply";
            this.btn_rotation_apply.Size = new System.Drawing.Size(75, 23);
            this.btn_rotation_apply.TabIndex = 2;
            this.btn_rotation_apply.Text = "Применить";
            this.btn_rotation_apply.UseVisualStyleBackColor = true;
            this.btn_rotation_apply.Click += new System.EventHandler(this.btn_rotation_apply_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "dz";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "dy";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "dx";
            // 
            // t_rotation_dz
            // 
            this.t_rotation_dz.Location = new System.Drawing.Point(72, 45);
            this.t_rotation_dz.Name = "t_rotation_dz";
            this.t_rotation_dz.Size = new System.Drawing.Size(23, 20);
            this.t_rotation_dz.TabIndex = 0;
            this.t_rotation_dz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.t_transform_dx_KeyPress);
            // 
            // t_rotation_dy
            // 
            this.t_rotation_dy.Location = new System.Drawing.Point(39, 45);
            this.t_rotation_dy.Name = "t_rotation_dy";
            this.t_rotation_dy.Size = new System.Drawing.Size(23, 20);
            this.t_rotation_dy.TabIndex = 0;
            this.t_rotation_dy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.t_transform_dx_KeyPress);
            // 
            // t_rotation_dx
            // 
            this.t_rotation_dx.Location = new System.Drawing.Point(7, 45);
            this.t_rotation_dx.Name = "t_rotation_dx";
            this.t_rotation_dx.Size = new System.Drawing.Size(23, 20);
            this.t_rotation_dx.TabIndex = 0;
            this.t_rotation_dx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.t_transform_dx_KeyPress);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_scale_apply);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.t_scale_dz);
            this.groupBox4.Controls.Add(this.t_scale_dy);
            this.groupBox4.Controls.Add(this.t_scale_dx);
            this.groupBox4.Location = new System.Drawing.Point(2, 334);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(101, 113);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Масштабирование";
            // 
            // btn_scale_apply
            // 
            this.btn_scale_apply.Location = new System.Drawing.Point(7, 71);
            this.btn_scale_apply.Name = "btn_scale_apply";
            this.btn_scale_apply.Size = new System.Drawing.Size(75, 23);
            this.btn_scale_apply.TabIndex = 2;
            this.btn_scale_apply.Text = "Применить";
            this.btn_scale_apply.UseVisualStyleBackColor = true;
            this.btn_scale_apply.Click += new System.EventHandler(this.btn_scale_apply_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(60, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "dz";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "dy";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "dx";
            // 
            // t_scale_dz
            // 
            this.t_scale_dz.Location = new System.Drawing.Point(67, 45);
            this.t_scale_dz.Name = "t_scale_dz";
            this.t_scale_dz.Size = new System.Drawing.Size(23, 20);
            this.t_scale_dz.TabIndex = 0;
            this.t_scale_dz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.t_transform_dx_KeyPress);
            // 
            // t_scale_dy
            // 
            this.t_scale_dy.Location = new System.Drawing.Point(36, 45);
            this.t_scale_dy.Name = "t_scale_dy";
            this.t_scale_dy.Size = new System.Drawing.Size(23, 20);
            this.t_scale_dy.TabIndex = 0;
            this.t_scale_dy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.t_transform_dx_KeyPress);
            // 
            // t_scale_dx
            // 
            this.t_scale_dx.Location = new System.Drawing.Point(7, 45);
            this.t_scale_dx.Name = "t_scale_dx";
            this.t_scale_dx.Size = new System.Drawing.Size(23, 20);
            this.t_scale_dx.TabIndex = 0;
            this.t_scale_dx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.t_transform_dx_KeyPress);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(12, 58);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 1;
            this.btn_clear.Text = "Сбросить";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(389, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 22);
            this.label10.TabIndex = 2;
            this.label10.Text = "zoom";
            // 
            // Task1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 574);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.track_zoom);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.vertex_c);
            this.Controls.Add(this.vertex_b);
            this.Controls.Add(this.vertex_a);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cur_info);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_draw);
            this.Controls.Add(this.canvas);
            this.Name = "Task1";
            this.Text = "Task1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Task1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.track_zoom)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Button btn_draw;
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
        private System.Windows.Forms.RadioButton perstective;
        private System.Windows.Forms.TrackBar track_zoom;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox t_transform_dz;
        private System.Windows.Forms.TextBox t_transform_dy;
        private System.Windows.Forms.TextBox t_transform_dx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_transform_apply;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_rotation_apply;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox t_rotation_dz;
        private System.Windows.Forms.TextBox t_rotation_dy;
        private System.Windows.Forms.TextBox t_rotation_dx;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_scale_apply;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox t_scale_dz;
        private System.Windows.Forms.TextBox t_scale_dy;
        private System.Windows.Forms.TextBox t_scale_dx;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Label label10;
    }
}