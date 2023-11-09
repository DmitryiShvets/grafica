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
            this.ortho_x_plus = new System.Windows.Forms.RadioButton();
            this.ortho_x_minus = new System.Windows.Forms.RadioButton();
            this.ortho_y_plus = new System.Windows.Forms.RadioButton();
            this.ortho_y_minus = new System.Windows.Forms.RadioButton();
            this.ortho_z_plus = new System.Windows.Forms.RadioButton();
            this.ortho_z_minus = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.perstective = new System.Windows.Forms.RadioButton();
            this.track_zoom = new System.Windows.Forms.TrackBar();
            this.label10 = new System.Windows.Forms.Label();
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.t_reflection_yz = new System.Windows.Forms.RadioButton();
            this.t_reflection_xz = new System.Windows.Forms.RadioButton();
            this.t_reflection_xy = new System.Windows.Forms.RadioButton();
            this.btn_reflection_apply = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.vertex_a = new System.Windows.Forms.Label();
            this.vertex_b = new System.Windows.Forms.Label();
            this.vertex_c = new System.Windows.Forms.Label();
            this.cur_info = new System.Windows.Forms.Label();
            this.groupBox_line_rotation = new System.Windows.Forms.GroupBox();
            this.btn_line_rotation_apply = new System.Windows.Forms.Button();
            this.label_line_z2 = new System.Windows.Forms.Label();
            this.label_line_z1 = new System.Windows.Forms.Label();
            this.label_line_y2 = new System.Windows.Forms.Label();
            this.label_line_y1 = new System.Windows.Forms.Label();
            this.label_line_x2 = new System.Windows.Forms.Label();
            this.tb_line_z2 = new System.Windows.Forms.TextBox();
            this.label_line_rotation_angle = new System.Windows.Forms.Label();
            this.label_line_x1 = new System.Windows.Forms.Label();
            this.tb_line_y2 = new System.Windows.Forms.TextBox();
            this.tb_line_z1 = new System.Windows.Forms.TextBox();
            this.tb_line_x2 = new System.Windows.Forms.TextBox();
            this.tb_line_rotation_angle = new System.Windows.Forms.TextBox();
            this.tb_line_y1 = new System.Windows.Forms.TextBox();
            this.tb_line_x1 = new System.Windows.Forms.TextBox();
            this.btn_save_model = new System.Windows.Forms.Button();
            this.btn_load_model = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.track_zoom)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox_line_rotation.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Location = new System.Drawing.Point(145, 167);
            this.canvas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(685, 492);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            // 
            // btn_draw
            // 
            this.btn_draw.Location = new System.Drawing.Point(147, 46);
            this.btn_draw.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_draw.Name = "btn_draw";
            this.btn_draw.Size = new System.Drawing.Size(85, 28);
            this.btn_draw.TabIndex = 1;
            this.btn_draw.Text = "Рисовать";
            this.btn_draw.UseVisualStyleBackColor = true;
            this.btn_draw.Click += new System.EventHandler(this.btn_draw_Click);
            // 
            // ortho_x_plus
            // 
            this.ortho_x_plus.AutoSize = true;
            this.ortho_x_plus.Location = new System.Drawing.Point(23, 46);
            this.ortho_x_plus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ortho_x_plus.Name = "ortho_x_plus";
            this.ortho_x_plus.Size = new System.Drawing.Size(43, 20);
            this.ortho_x_plus.TabIndex = 3;
            this.ortho_x_plus.TabStop = true;
            this.ortho_x_plus.Text = "+X";
            this.ortho_x_plus.UseVisualStyleBackColor = true;
            this.ortho_x_plus.CheckedChanged += new System.EventHandler(this.ortho_x_plus_CheckedChanged);
            // 
            // ortho_x_minus
            // 
            this.ortho_x_minus.AutoSize = true;
            this.ortho_x_minus.Location = new System.Drawing.Point(23, 68);
            this.ortho_x_minus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ortho_x_minus.Name = "ortho_x_minus";
            this.ortho_x_minus.Size = new System.Drawing.Size(40, 20);
            this.ortho_x_minus.TabIndex = 3;
            this.ortho_x_minus.TabStop = true;
            this.ortho_x_minus.Text = "-X";
            this.ortho_x_minus.UseVisualStyleBackColor = true;
            this.ortho_x_minus.CheckedChanged += new System.EventHandler(this.ortho_x_minus_CheckedChanged);
            // 
            // ortho_y_plus
            // 
            this.ortho_y_plus.AutoSize = true;
            this.ortho_y_plus.Location = new System.Drawing.Point(77, 46);
            this.ortho_y_plus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ortho_y_plus.Name = "ortho_y_plus";
            this.ortho_y_plus.Size = new System.Drawing.Size(44, 20);
            this.ortho_y_plus.TabIndex = 3;
            this.ortho_y_plus.TabStop = true;
            this.ortho_y_plus.Text = "+Y";
            this.ortho_y_plus.UseVisualStyleBackColor = true;
            this.ortho_y_plus.CheckedChanged += new System.EventHandler(this.ortho_y_plus_CheckedChanged);
            // 
            // ortho_y_minus
            // 
            this.ortho_y_minus.AutoSize = true;
            this.ortho_y_minus.Location = new System.Drawing.Point(77, 68);
            this.ortho_y_minus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ortho_y_minus.Name = "ortho_y_minus";
            this.ortho_y_minus.Size = new System.Drawing.Size(41, 20);
            this.ortho_y_minus.TabIndex = 3;
            this.ortho_y_minus.TabStop = true;
            this.ortho_y_minus.Text = "-Y";
            this.ortho_y_minus.UseVisualStyleBackColor = true;
            this.ortho_y_minus.CheckedChanged += new System.EventHandler(this.ortho_y_minus_CheckedChanged);
            // 
            // ortho_z_plus
            // 
            this.ortho_z_plus.AutoSize = true;
            this.ortho_z_plus.Checked = true;
            this.ortho_z_plus.Location = new System.Drawing.Point(132, 46);
            this.ortho_z_plus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ortho_z_plus.Name = "ortho_z_plus";
            this.ortho_z_plus.Size = new System.Drawing.Size(43, 20);
            this.ortho_z_plus.TabIndex = 3;
            this.ortho_z_plus.TabStop = true;
            this.ortho_z_plus.Text = "+Z";
            this.ortho_z_plus.UseVisualStyleBackColor = true;
            this.ortho_z_plus.CheckedChanged += new System.EventHandler(this.ortho_z_plus_CheckedChanged);
            // 
            // ortho_z_minus
            // 
            this.ortho_z_minus.AutoSize = true;
            this.ortho_z_minus.Location = new System.Drawing.Point(132, 68);
            this.ortho_z_minus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ortho_z_minus.Name = "ortho_z_minus";
            this.ortho_z_minus.Size = new System.Drawing.Size(40, 20);
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
            this.groupBox1.Controls.Add(this.track_zoom);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(353, 26);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(477, 123);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Проекция:";
            // 
            // perstective
            // 
            this.perstective.AutoSize = true;
            this.perstective.Location = new System.Drawing.Point(192, 46);
            this.perstective.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.perstective.Name = "perstective";
            this.perstective.Size = new System.Drawing.Size(122, 20);
            this.perstective.TabIndex = 4;
            this.perstective.TabStop = true;
            this.perstective.Text = "PERSPECTIVE";
            this.perstective.UseVisualStyleBackColor = true;
            this.perstective.CheckedChanged += new System.EventHandler(this.perstective_CheckedChanged);
            // 
            // track_zoom
            // 
            this.track_zoom.Location = new System.Drawing.Point(332, 60);
            this.track_zoom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.track_zoom.Maximum = 100;
            this.track_zoom.Minimum = 1;
            this.track_zoom.Name = "track_zoom";
            this.track_zoom.Size = new System.Drawing.Size(139, 56);
            this.track_zoom.TabIndex = 5;
            this.track_zoom.TickStyle = System.Windows.Forms.TickStyle.None;
            this.track_zoom.Value = 1;
            this.track_zoom.ValueChanged += new System.EventHandler(this.track_zoom_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(332, 30);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 28);
            this.label10.TabIndex = 2;
            this.label10.Text = "zoom";
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
            this.groupBox2.Location = new System.Drawing.Point(3, 167);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(135, 139);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Перемещение";
            // 
            // btn_transform_apply
            // 
            this.btn_transform_apply.Location = new System.Drawing.Point(9, 87);
            this.btn_transform_apply.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_transform_apply.Name = "btn_transform_apply";
            this.btn_transform_apply.Size = new System.Drawing.Size(100, 28);
            this.btn_transform_apply.TabIndex = 2;
            this.btn_transform_apply.Text = "Применить";
            this.btn_transform_apply.UseVisualStyleBackColor = true;
            this.btn_transform_apply.Click += new System.EventHandler(this.btn_transform_apply_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(103, 36);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "dz";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "dy";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "dx";
            // 
            // t_transform_dz
            // 
            this.t_transform_dz.Location = new System.Drawing.Point(96, 55);
            this.t_transform_dz.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.t_transform_dz.Name = "t_transform_dz";
            this.t_transform_dz.Size = new System.Drawing.Size(29, 22);
            this.t_transform_dz.TabIndex = 0;
            this.t_transform_dz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.t_transform_dx_KeyPress);
            // 
            // t_transform_dy
            // 
            this.t_transform_dy.Location = new System.Drawing.Point(52, 55);
            this.t_transform_dy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.t_transform_dy.Name = "t_transform_dy";
            this.t_transform_dy.Size = new System.Drawing.Size(29, 22);
            this.t_transform_dy.TabIndex = 0;
            this.t_transform_dy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.t_transform_dx_KeyPress);
            // 
            // t_transform_dx
            // 
            this.t_transform_dx.Location = new System.Drawing.Point(9, 55);
            this.t_transform_dx.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.t_transform_dx.Name = "t_transform_dx";
            this.t_transform_dx.Size = new System.Drawing.Size(29, 22);
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
            this.groupBox3.Location = new System.Drawing.Point(3, 314);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(135, 139);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Вращение";
            // 
            // btn_rotation_apply
            // 
            this.btn_rotation_apply.Location = new System.Drawing.Point(9, 87);
            this.btn_rotation_apply.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_rotation_apply.Name = "btn_rotation_apply";
            this.btn_rotation_apply.Size = new System.Drawing.Size(100, 28);
            this.btn_rotation_apply.TabIndex = 2;
            this.btn_rotation_apply.Text = "Применить";
            this.btn_rotation_apply.UseVisualStyleBackColor = true;
            this.btn_rotation_apply.Click += new System.EventHandler(this.btn_rotation_apply_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(103, 36);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "dz";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 36);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "dy";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 36);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "dx";
            // 
            // t_rotation_dz
            // 
            this.t_rotation_dz.Location = new System.Drawing.Point(96, 55);
            this.t_rotation_dz.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.t_rotation_dz.Name = "t_rotation_dz";
            this.t_rotation_dz.Size = new System.Drawing.Size(29, 22);
            this.t_rotation_dz.TabIndex = 0;
            this.t_rotation_dz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.t_transform_dx_KeyPress);
            // 
            // t_rotation_dy
            // 
            this.t_rotation_dy.Location = new System.Drawing.Point(52, 55);
            this.t_rotation_dy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.t_rotation_dy.Name = "t_rotation_dy";
            this.t_rotation_dy.Size = new System.Drawing.Size(29, 22);
            this.t_rotation_dy.TabIndex = 0;
            this.t_rotation_dy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.t_transform_dx_KeyPress);
            // 
            // t_rotation_dx
            // 
            this.t_rotation_dx.Location = new System.Drawing.Point(9, 55);
            this.t_rotation_dx.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.t_rotation_dx.Name = "t_rotation_dx";
            this.t_rotation_dx.Size = new System.Drawing.Size(29, 22);
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
            this.groupBox4.Location = new System.Drawing.Point(3, 461);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Size = new System.Drawing.Size(135, 139);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Масштабирование";
            // 
            // btn_scale_apply
            // 
            this.btn_scale_apply.Location = new System.Drawing.Point(7, 86);
            this.btn_scale_apply.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_scale_apply.Name = "btn_scale_apply";
            this.btn_scale_apply.Size = new System.Drawing.Size(103, 23);
            this.btn_scale_apply.TabIndex = 2;
            this.btn_scale_apply.Text = "Применить";
            this.btn_scale_apply.UseVisualStyleBackColor = true;
            this.btn_scale_apply.Click += new System.EventHandler(this.btn_scale_apply_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(80, 36);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "dz";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(48, 36);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 16);
            this.label8.TabIndex = 1;
            this.label8.Text = "dy";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 36);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 16);
            this.label9.TabIndex = 1;
            this.label9.Text = "dx";
            // 
            // t_scale_dz
            // 
            this.t_scale_dz.Location = new System.Drawing.Point(89, 55);
            this.t_scale_dz.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.t_scale_dz.Name = "t_scale_dz";
            this.t_scale_dz.Size = new System.Drawing.Size(29, 22);
            this.t_scale_dz.TabIndex = 0;
            this.t_scale_dz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.t_transform_dx_KeyPress);
            // 
            // t_scale_dy
            // 
            this.t_scale_dy.Location = new System.Drawing.Point(48, 55);
            this.t_scale_dy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.t_scale_dy.Name = "t_scale_dy";
            this.t_scale_dy.Size = new System.Drawing.Size(29, 22);
            this.t_scale_dy.TabIndex = 0;
            this.t_scale_dy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.t_transform_dx_KeyPress);
            // 
            // t_scale_dx
            // 
            this.t_scale_dx.Location = new System.Drawing.Point(9, 55);
            this.t_scale_dx.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.t_scale_dx.Name = "t_scale_dx";
            this.t_scale_dx.Size = new System.Drawing.Size(29, 22);
            this.t_scale_dx.TabIndex = 0;
            this.t_scale_dx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.t_transform_dx_KeyPress);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(147, 75);
            this.btn_clear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(85, 28);
            this.btn_clear.TabIndex = 1;
            this.btn_clear.Text = "Сбросить";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioButton1);
            this.groupBox5.Controls.Add(this.t_reflection_yz);
            this.groupBox5.Controls.Add(this.t_reflection_xz);
            this.groupBox5.Controls.Add(this.t_reflection_xy);
            this.groupBox5.Controls.Add(this.btn_reflection_apply);
            this.groupBox5.Location = new System.Drawing.Point(145, 667);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Size = new System.Drawing.Size(132, 130);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Отражение";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(68, 20);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(53, 20);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Нет";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // t_reflection_yz
            // 
            this.t_reflection_yz.AutoSize = true;
            this.t_reflection_yz.Location = new System.Drawing.Point(7, 66);
            this.t_reflection_yz.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.t_reflection_yz.Name = "t_reflection_yz";
            this.t_reflection_yz.Size = new System.Drawing.Size(45, 20);
            this.t_reflection_yz.TabIndex = 3;
            this.t_reflection_yz.TabStop = true;
            this.t_reflection_yz.Text = "YZ";
            this.t_reflection_yz.UseVisualStyleBackColor = true;
            // 
            // t_reflection_xz
            // 
            this.t_reflection_xz.AutoSize = true;
            this.t_reflection_xz.Location = new System.Drawing.Point(7, 43);
            this.t_reflection_xz.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.t_reflection_xz.Name = "t_reflection_xz";
            this.t_reflection_xz.Size = new System.Drawing.Size(44, 20);
            this.t_reflection_xz.TabIndex = 3;
            this.t_reflection_xz.TabStop = true;
            this.t_reflection_xz.Text = "XZ";
            this.t_reflection_xz.UseVisualStyleBackColor = true;
            // 
            // t_reflection_xy
            // 
            this.t_reflection_xy.AutoSize = true;
            this.t_reflection_xy.Location = new System.Drawing.Point(7, 20);
            this.t_reflection_xy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.t_reflection_xy.Name = "t_reflection_xy";
            this.t_reflection_xy.Size = new System.Drawing.Size(45, 20);
            this.t_reflection_xy.TabIndex = 3;
            this.t_reflection_xy.Text = "XY";
            this.t_reflection_xy.UseVisualStyleBackColor = true;
            // 
            // btn_reflection_apply
            // 
            this.btn_reflection_apply.Location = new System.Drawing.Point(7, 89);
            this.btn_reflection_apply.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_reflection_apply.Name = "btn_reflection_apply";
            this.btn_reflection_apply.Size = new System.Drawing.Size(100, 23);
            this.btn_reflection_apply.TabIndex = 2;
            this.btn_reflection_apply.Text = "Применить";
            this.btn_reflection_apply.UseVisualStyleBackColor = true;
            this.btn_reflection_apply.Click += new System.EventHandler(this.btn_reflection_apply_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(11, 46);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 16);
            this.label11.TabIndex = 8;
            this.label11.Text = "Выбрать фигуру";
            // 
            // vertex_a
            // 
            this.vertex_a.AutoSize = true;
            this.vertex_a.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vertex_a.Location = new System.Drawing.Point(833, 550);
            this.vertex_a.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.vertex_a.Name = "vertex_a";
            this.vertex_a.Size = new System.Drawing.Size(25, 28);
            this.vertex_a.TabIndex = 2;
            this.vertex_a.Text = "a";
            // 
            // vertex_b
            // 
            this.vertex_b.AutoSize = true;
            this.vertex_b.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vertex_b.Location = new System.Drawing.Point(833, 594);
            this.vertex_b.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.vertex_b.Name = "vertex_b";
            this.vertex_b.Size = new System.Drawing.Size(25, 28);
            this.vertex_b.TabIndex = 2;
            this.vertex_b.Text = "a";
            // 
            // vertex_c
            // 
            this.vertex_c.AutoSize = true;
            this.vertex_c.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vertex_c.Location = new System.Drawing.Point(833, 633);
            this.vertex_c.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.vertex_c.Name = "vertex_c";
            this.vertex_c.Size = new System.Drawing.Size(25, 28);
            this.vertex_c.TabIndex = 2;
            this.vertex_c.Text = "a";
            // 
            // cur_info
            // 
            this.cur_info.AutoSize = true;
            this.cur_info.Enabled = false;
            this.cur_info.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cur_info.Location = new System.Drawing.Point(617, 760);
            this.cur_info.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cur_info.Name = "cur_info";
            this.cur_info.Size = new System.Drawing.Size(90, 28);
            this.cur_info.TabIndex = 2;
            this.cur_info.Text = "label1";
            // 
            // groupBox_line_rotation
            // 
            this.groupBox_line_rotation.Controls.Add(this.btn_line_rotation_apply);
            this.groupBox_line_rotation.Controls.Add(this.label_line_z2);
            this.groupBox_line_rotation.Controls.Add(this.label_line_z1);
            this.groupBox_line_rotation.Controls.Add(this.label_line_y2);
            this.groupBox_line_rotation.Controls.Add(this.label_line_y1);
            this.groupBox_line_rotation.Controls.Add(this.label_line_x2);
            this.groupBox_line_rotation.Controls.Add(this.tb_line_z2);
            this.groupBox_line_rotation.Controls.Add(this.label_line_rotation_angle);
            this.groupBox_line_rotation.Controls.Add(this.label_line_x1);
            this.groupBox_line_rotation.Controls.Add(this.tb_line_y2);
            this.groupBox_line_rotation.Controls.Add(this.tb_line_z1);
            this.groupBox_line_rotation.Controls.Add(this.tb_line_x2);
            this.groupBox_line_rotation.Controls.Add(this.tb_line_rotation_angle);
            this.groupBox_line_rotation.Controls.Add(this.tb_line_y1);
            this.groupBox_line_rotation.Controls.Add(this.tb_line_x1);
            this.groupBox_line_rotation.Location = new System.Drawing.Point(284, 670);
            this.groupBox_line_rotation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox_line_rotation.Name = "groupBox_line_rotation";
            this.groupBox_line_rotation.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox_line_rotation.Size = new System.Drawing.Size(271, 128);
            this.groupBox_line_rotation.TabIndex = 6;
            this.groupBox_line_rotation.TabStop = false;
            this.groupBox_line_rotation.Text = "Поворот относительно прямой";
            // 
            // btn_line_rotation_apply
            // 
            this.btn_line_rotation_apply.Location = new System.Drawing.Point(157, 96);
            this.btn_line_rotation_apply.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_line_rotation_apply.Name = "btn_line_rotation_apply";
            this.btn_line_rotation_apply.Size = new System.Drawing.Size(103, 23);
            this.btn_line_rotation_apply.TabIndex = 2;
            this.btn_line_rotation_apply.Text = "Применить";
            this.btn_line_rotation_apply.UseVisualStyleBackColor = true;
            this.btn_line_rotation_apply.Click += new System.EventHandler(this.btn_line_rotation_apply_Click);
            // 
            // label_line_z2
            // 
            this.label_line_z2.AutoSize = true;
            this.label_line_z2.Location = new System.Drawing.Point(236, 36);
            this.label_line_z2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_line_z2.Name = "label_line_z2";
            this.label_line_z2.Size = new System.Drawing.Size(20, 16);
            this.label_line_z2.TabIndex = 1;
            this.label_line_z2.Text = "z2";
            // 
            // label_line_z1
            // 
            this.label_line_z1.AutoSize = true;
            this.label_line_z1.Location = new System.Drawing.Point(96, 36);
            this.label_line_z1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_line_z1.Name = "label_line_z1";
            this.label_line_z1.Size = new System.Drawing.Size(20, 16);
            this.label_line_z1.TabIndex = 1;
            this.label_line_z1.Text = "z1";
            // 
            // label_line_y2
            // 
            this.label_line_y2.AutoSize = true;
            this.label_line_y2.Location = new System.Drawing.Point(195, 36);
            this.label_line_y2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_line_y2.Name = "label_line_y2";
            this.label_line_y2.Size = new System.Drawing.Size(21, 16);
            this.label_line_y2.TabIndex = 1;
            this.label_line_y2.Text = "y2";
            // 
            // label_line_y1
            // 
            this.label_line_y1.AutoSize = true;
            this.label_line_y1.Location = new System.Drawing.Point(55, 36);
            this.label_line_y1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_line_y1.Name = "label_line_y1";
            this.label_line_y1.Size = new System.Drawing.Size(21, 16);
            this.label_line_y1.TabIndex = 1;
            this.label_line_y1.Text = "y1";
            // 
            // label_line_x2
            // 
            this.label_line_x2.AutoSize = true;
            this.label_line_x2.Location = new System.Drawing.Point(159, 36);
            this.label_line_x2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_line_x2.Name = "label_line_x2";
            this.label_line_x2.Size = new System.Drawing.Size(20, 16);
            this.label_line_x2.TabIndex = 1;
            this.label_line_x2.Text = "x2";
            // 
            // tb_line_z2
            // 
            this.tb_line_z2.Location = new System.Drawing.Point(229, 55);
            this.tb_line_z2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_line_z2.Name = "tb_line_z2";
            this.tb_line_z2.Size = new System.Drawing.Size(29, 22);
            this.tb_line_z2.TabIndex = 0;
            this.tb_line_z2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.t_transform_dx_KeyPress);
            // 
            // label_line_rotation_angle
            // 
            this.label_line_rotation_angle.AutoSize = true;
            this.label_line_rotation_angle.Location = new System.Drawing.Point(8, 100);
            this.label_line_rotation_angle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_line_rotation_angle.Name = "label_line_rotation_angle";
            this.label_line_rotation_angle.Size = new System.Drawing.Size(41, 16);
            this.label_line_rotation_angle.TabIndex = 1;
            this.label_line_rotation_angle.Text = "Угол:";
            // 
            // label_line_x1
            // 
            this.label_line_x1.AutoSize = true;
            this.label_line_x1.Location = new System.Drawing.Point(19, 36);
            this.label_line_x1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_line_x1.Name = "label_line_x1";
            this.label_line_x1.Size = new System.Drawing.Size(20, 16);
            this.label_line_x1.TabIndex = 1;
            this.label_line_x1.Text = "x1";
            // 
            // tb_line_y2
            // 
            this.tb_line_y2.Location = new System.Drawing.Point(188, 55);
            this.tb_line_y2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_line_y2.Name = "tb_line_y2";
            this.tb_line_y2.Size = new System.Drawing.Size(29, 22);
            this.tb_line_y2.TabIndex = 0;
            this.tb_line_y2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.t_transform_dx_KeyPress);
            // 
            // tb_line_z1
            // 
            this.tb_line_z1.Location = new System.Drawing.Point(89, 55);
            this.tb_line_z1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_line_z1.Name = "tb_line_z1";
            this.tb_line_z1.Size = new System.Drawing.Size(29, 22);
            this.tb_line_z1.TabIndex = 0;
            this.tb_line_z1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.t_transform_dx_KeyPress);
            // 
            // tb_line_x2
            // 
            this.tb_line_x2.Location = new System.Drawing.Point(149, 55);
            this.tb_line_x2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_line_x2.Name = "tb_line_x2";
            this.tb_line_x2.Size = new System.Drawing.Size(29, 22);
            this.tb_line_x2.TabIndex = 0;
            this.tb_line_x2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.t_transform_dx_KeyPress);
            // 
            // tb_line_rotation_angle
            // 
            this.tb_line_rotation_angle.Location = new System.Drawing.Point(59, 96);
            this.tb_line_rotation_angle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_line_rotation_angle.Name = "tb_line_rotation_angle";
            this.tb_line_rotation_angle.Size = new System.Drawing.Size(60, 22);
            this.tb_line_rotation_angle.TabIndex = 0;
            this.tb_line_rotation_angle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.t_transform_dx_KeyPress);
            // 
            // tb_line_y1
            // 
            this.tb_line_y1.Location = new System.Drawing.Point(48, 55);
            this.tb_line_y1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_line_y1.Name = "tb_line_y1";
            this.tb_line_y1.Size = new System.Drawing.Size(29, 22);
            this.tb_line_y1.TabIndex = 0;
            this.tb_line_y1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.t_transform_dx_KeyPress);
            // 
            // tb_line_x1
            // 
            this.tb_line_x1.Location = new System.Drawing.Point(9, 55);
            this.tb_line_x1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_line_x1.Name = "tb_line_x1";
            this.tb_line_x1.Size = new System.Drawing.Size(29, 22);
            this.tb_line_x1.TabIndex = 0;
            this.tb_line_x1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.t_transform_dx_KeyPress);
            // 
            // btn_save_model
            // 
            this.btn_save_model.Location = new System.Drawing.Point(233, 46);
            this.btn_save_model.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_save_model.Name = "btn_save_model";
            this.btn_save_model.Size = new System.Drawing.Size(92, 28);
            this.btn_save_model.TabIndex = 1;
            this.btn_save_model.Text = "Сохранить";
            this.btn_save_model.UseVisualStyleBackColor = true;
            this.btn_save_model.Click += new System.EventHandler(this.btn_save_model_Click);
            // 
            // btn_load_model
            // 
            this.btn_load_model.Location = new System.Drawing.Point(233, 75);
            this.btn_load_model.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_load_model.Name = "btn_load_model";
            this.btn_load_model.Size = new System.Drawing.Size(92, 28);
            this.btn_load_model.TabIndex = 1;
            this.btn_load_model.Text = "Загрузить";
            this.btn_load_model.UseVisualStyleBackColor = true;
            this.btn_load_model.Click += new System.EventHandler(this.btn_load_model_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btn_draw);
            this.groupBox7.Controls.Add(this.btn_clear);
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.Controls.Add(this.comboBox1);
            this.groupBox7.Controls.Add(this.btn_save_model);
            this.groupBox7.Controls.Add(this.btn_load_model);
            this.groupBox7.Location = new System.Drawing.Point(12, 26);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox7.Size = new System.Drawing.Size(333, 123);
            this.groupBox7.TabIndex = 79;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Модель";
            // 
            // Task1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 794);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox_line_rotation);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.vertex_c);
            this.Controls.Add(this.vertex_b);
            this.Controls.Add(this.vertex_a);
            this.Controls.Add(this.cur_info);
            this.Controls.Add(this.canvas);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox_line_rotation.ResumeLayout(false);
            this.groupBox_line_rotation.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Button btn_draw;
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
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton t_reflection_yz;
        private System.Windows.Forms.RadioButton t_reflection_xz;
        private System.Windows.Forms.RadioButton t_reflection_xy;
        private System.Windows.Forms.Button btn_reflection_apply;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label vertex_a;
        private System.Windows.Forms.Label vertex_b;
        private System.Windows.Forms.Label vertex_c;
        private System.Windows.Forms.Label cur_info;
        private System.Windows.Forms.GroupBox groupBox_line_rotation;
        private System.Windows.Forms.Button btn_line_rotation_apply;
        private System.Windows.Forms.Label label_line_z2;
        private System.Windows.Forms.Label label_line_z1;
        private System.Windows.Forms.Label label_line_y2;
        private System.Windows.Forms.Label label_line_y1;
        private System.Windows.Forms.Label label_line_x2;
        private System.Windows.Forms.TextBox tb_line_z2;
        private System.Windows.Forms.Label label_line_x1;
        private System.Windows.Forms.TextBox tb_line_y2;
        private System.Windows.Forms.TextBox tb_line_z1;
        private System.Windows.Forms.TextBox tb_line_x2;
        private System.Windows.Forms.TextBox tb_line_y1;
        private System.Windows.Forms.TextBox tb_line_x1;
        private System.Windows.Forms.Label label_line_rotation_angle;
        private System.Windows.Forms.TextBox tb_line_rotation_angle;
        private System.Windows.Forms.Button btn_save_model;
        private System.Windows.Forms.Button btn_load_model;
        private System.Windows.Forms.GroupBox groupBox7;
    }
}