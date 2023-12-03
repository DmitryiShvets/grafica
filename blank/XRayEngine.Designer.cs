namespace blank
{
    partial class XRayEngine
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.canvas = new System.Windows.Forms.PictureBox();
            this.btm_apply = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.chb_visible = new System.Windows.Forms.CheckBox();
            this.num_x = new System.Windows.Forms.NumericUpDown();
            this.num_y = new System.Windows.Forms.NumericUpDown();
            this.num_z = new System.Windows.Forms.NumericUpDown();
            this.n_specular = new System.Windows.Forms.NumericUpDown();
            this.n_reflective = new System.Windows.Forms.NumericUpDown();
            this.n_transparency = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.n_intensity = new System.Windows.Forms.NumericUpDown();
            this.cb_light_type = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.color_r = new System.Windows.Forms.NumericUpDown();
            this.color_g = new System.Windows.Forms.NumericUpDown();
            this.pos_x = new System.Windows.Forms.NumericUpDown();
            this.pos_y = new System.Windows.Forms.NumericUpDown();
            this.color_b = new System.Windows.Forms.NumericUpDown();
            this.pos_z = new System.Windows.Forms.NumericUpDown();
            this.btn_delete_obj = new System.Windows.Forms.Button();
            this.btn_flip = new System.Windows.Forms.Button();
            this.btn_add_light = new System.Windows.Forms.Button();
            this.btn_add_box = new System.Windows.Forms.Button();
            this.btn_add_sphere = new System.Windows.Forms.Button();
            this.btn_change = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_x)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_z)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_specular)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_reflective)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_transparency)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.n_intensity)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.color_r)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.color_g)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pos_x)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pos_y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.color_b)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pos_z)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas.Location = new System.Drawing.Point(321, 3);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(500, 400);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            // 
            // btm_apply
            // 
            this.btm_apply.Location = new System.Drawing.Point(3, 3);
            this.btm_apply.Name = "btm_apply";
            this.btm_apply.Size = new System.Drawing.Size(83, 23);
            this.btm_apply.TabIndex = 1;
            this.btm_apply.Text = "Рисовать";
            this.btm_apply.UseVisualStyleBackColor = true;
            this.btm_apply.Click += new System.EventHandler(this.button1_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(6, 107);
            this.trackBar1.Maximum = 4;
            this.trackBar1.Minimum = -5;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(69, 45);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(167, 230);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(148, 173);
            this.listBox1.TabIndex = 3;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(6, 230);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(155, 173);
            this.listBox2.TabIndex = 3;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // chb_visible
            // 
            this.chb_visible.AutoSize = true;
            this.chb_visible.Location = new System.Drawing.Point(9, 191);
            this.chb_visible.Name = "chb_visible";
            this.chb_visible.Size = new System.Drawing.Size(73, 17);
            this.chb_visible.TabIndex = 4;
            this.chb_visible.Text = "Видимый";
            this.chb_visible.UseVisualStyleBackColor = true;
            this.chb_visible.CheckedChanged += new System.EventHandler(this.chb_visible_CheckedChanged);
            // 
            // num_x
            // 
            this.num_x.Location = new System.Drawing.Point(6, 19);
            this.num_x.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_x.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.num_x.Name = "num_x";
            this.num_x.Size = new System.Drawing.Size(48, 20);
            this.num_x.TabIndex = 5;
            // 
            // num_y
            // 
            this.num_y.Location = new System.Drawing.Point(60, 19);
            this.num_y.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_y.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.num_y.Name = "num_y";
            this.num_y.Size = new System.Drawing.Size(42, 20);
            this.num_y.TabIndex = 6;
            // 
            // num_z
            // 
            this.num_z.Location = new System.Drawing.Point(108, 19);
            this.num_z.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_z.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.num_z.Name = "num_z";
            this.num_z.Size = new System.Drawing.Size(40, 20);
            this.num_z.TabIndex = 7;
            // 
            // n_specular
            // 
            this.n_specular.DecimalPlaces = 2;
            this.n_specular.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.n_specular.Location = new System.Drawing.Point(88, 62);
            this.n_specular.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.n_specular.Name = "n_specular";
            this.n_specular.Size = new System.Drawing.Size(53, 20);
            this.n_specular.TabIndex = 8;
            // 
            // n_reflective
            // 
            this.n_reflective.DecimalPlaces = 2;
            this.n_reflective.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.n_reflective.Location = new System.Drawing.Point(88, 87);
            this.n_reflective.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.n_reflective.Name = "n_reflective";
            this.n_reflective.Size = new System.Drawing.Size(53, 20);
            this.n_reflective.TabIndex = 9;
            // 
            // n_transparency
            // 
            this.n_transparency.DecimalPlaces = 2;
            this.n_transparency.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.n_transparency.Location = new System.Drawing.Point(88, 111);
            this.n_transparency.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.n_transparency.Name = "n_transparency";
            this.n_transparency.Size = new System.Drawing.Size(53, 20);
            this.n_transparency.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.n_intensity);
            this.groupBox1.Controls.Add(this.cb_light_type);
            this.groupBox1.Controls.Add(this.num_x);
            this.groupBox1.Controls.Add(this.num_y);
            this.groupBox1.Controls.Add(this.num_z);
            this.groupBox1.Location = new System.Drawing.Point(6, 152);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(155, 72);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Light Source";
            // 
            // n_intensity
            // 
            this.n_intensity.DecimalPlaces = 1;
            this.n_intensity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.n_intensity.Location = new System.Drawing.Point(108, 47);
            this.n_intensity.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.n_intensity.Name = "n_intensity";
            this.n_intensity.Size = new System.Drawing.Size(36, 20);
            this.n_intensity.TabIndex = 12;
            // 
            // cb_light_type
            // 
            this.cb_light_type.FormattingEnabled = true;
            this.cb_light_type.Location = new System.Drawing.Point(7, 46);
            this.cb_light_type.Name = "cb_light_type";
            this.cb_light_type.Size = new System.Drawing.Size(95, 21);
            this.cb_light_type.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.color_r);
            this.groupBox2.Controls.Add(this.color_g);
            this.groupBox2.Controls.Add(this.pos_x);
            this.groupBox2.Controls.Add(this.pos_y);
            this.groupBox2.Controls.Add(this.color_b);
            this.groupBox2.Controls.Add(this.n_specular);
            this.groupBox2.Controls.Add(this.pos_z);
            this.groupBox2.Controls.Add(this.n_reflective);
            this.groupBox2.Controls.Add(this.chb_visible);
            this.groupBox2.Controls.Add(this.n_transparency);
            this.groupBox2.Location = new System.Drawing.Point(167, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(148, 221);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Object";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Прозрачность";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Зеркальность";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Шершавость";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Цвет";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Позиция";
            // 
            // color_r
            // 
            this.color_r.Location = new System.Drawing.Point(9, 165);
            this.color_r.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.color_r.Name = "color_r";
            this.color_r.Size = new System.Drawing.Size(40, 20);
            this.color_r.TabIndex = 8;
            // 
            // color_g
            // 
            this.color_g.Location = new System.Drawing.Point(55, 165);
            this.color_g.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.color_g.Name = "color_g";
            this.color_g.Size = new System.Drawing.Size(40, 20);
            this.color_g.TabIndex = 9;
            // 
            // pos_x
            // 
            this.pos_x.DecimalPlaces = 1;
            this.pos_x.Location = new System.Drawing.Point(9, 32);
            this.pos_x.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.pos_x.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.pos_x.Name = "pos_x";
            this.pos_x.Size = new System.Drawing.Size(40, 20);
            this.pos_x.TabIndex = 8;
            // 
            // pos_y
            // 
            this.pos_y.DecimalPlaces = 1;
            this.pos_y.Location = new System.Drawing.Point(55, 32);
            this.pos_y.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.pos_y.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.pos_y.Name = "pos_y";
            this.pos_y.Size = new System.Drawing.Size(40, 20);
            this.pos_y.TabIndex = 9;
            // 
            // color_b
            // 
            this.color_b.Location = new System.Drawing.Point(101, 165);
            this.color_b.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.color_b.Name = "color_b";
            this.color_b.Size = new System.Drawing.Size(40, 20);
            this.color_b.TabIndex = 10;
            // 
            // pos_z
            // 
            this.pos_z.DecimalPlaces = 1;
            this.pos_z.Location = new System.Drawing.Point(101, 32);
            this.pos_z.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.pos_z.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.pos_z.Name = "pos_z";
            this.pos_z.Size = new System.Drawing.Size(40, 20);
            this.pos_z.TabIndex = 10;
            // 
            // btn_delete_obj
            // 
            this.btn_delete_obj.Location = new System.Drawing.Point(3, 78);
            this.btn_delete_obj.Name = "btn_delete_obj";
            this.btn_delete_obj.Size = new System.Drawing.Size(83, 23);
            this.btn_delete_obj.TabIndex = 1;
            this.btn_delete_obj.Text = "Удалить";
            this.btn_delete_obj.UseVisualStyleBackColor = true;
            this.btn_delete_obj.Click += new System.EventHandler(this.btn_delete_obj_Click);
            // 
            // btn_flip
            // 
            this.btn_flip.Location = new System.Drawing.Point(3, 30);
            this.btn_flip.Name = "btn_flip";
            this.btn_flip.Size = new System.Drawing.Size(83, 23);
            this.btn_flip.TabIndex = 1;
            this.btn_flip.Text = "Перевернуть";
            this.btn_flip.UseVisualStyleBackColor = true;
            this.btn_flip.Click += new System.EventHandler(this.btn_flip_Click);
            // 
            // btn_add_light
            // 
            this.btn_add_light.Location = new System.Drawing.Point(92, 5);
            this.btn_add_light.Name = "btn_add_light";
            this.btn_add_light.Size = new System.Drawing.Size(68, 40);
            this.btn_add_light.TabIndex = 1;
            this.btn_add_light.Text = "Добавить Свет";
            this.btn_add_light.UseVisualStyleBackColor = true;
            this.btn_add_light.Click += new System.EventHandler(this.btn_add_light_Click);
            // 
            // btn_add_box
            // 
            this.btn_add_box.Location = new System.Drawing.Point(92, 47);
            this.btn_add_box.Name = "btn_add_box";
            this.btn_add_box.Size = new System.Drawing.Size(68, 40);
            this.btn_add_box.TabIndex = 1;
            this.btn_add_box.Text = "Добавить куб";
            this.btn_add_box.UseVisualStyleBackColor = true;
            this.btn_add_box.Click += new System.EventHandler(this.btn_add_box_Click);
            // 
            // btn_add_sphere
            // 
            this.btn_add_sphere.Location = new System.Drawing.Point(92, 89);
            this.btn_add_sphere.Name = "btn_add_sphere";
            this.btn_add_sphere.Size = new System.Drawing.Size(68, 40);
            this.btn_add_sphere.TabIndex = 1;
            this.btn_add_sphere.Text = "Добавить сферу";
            this.btn_add_sphere.UseVisualStyleBackColor = true;
            this.btn_add_sphere.Click += new System.EventHandler(this.btn_add_sphere_Click);
            // 
            // btn_change
            // 
            this.btn_change.Location = new System.Drawing.Point(3, 53);
            this.btn_change.Name = "btn_change";
            this.btn_change.Size = new System.Drawing.Size(83, 23);
            this.btn_change.TabIndex = 1;
            this.btn_change.Text = "Изменить";
            this.btn_change.UseVisualStyleBackColor = true;
            this.btn_change.Click += new System.EventHandler(this.btn_change_Click);
            // 
            // XRayEngine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.btn_delete_obj);
            this.Controls.Add(this.btn_flip);
            this.Controls.Add(this.btn_add_sphere);
            this.Controls.Add(this.btn_add_box);
            this.Controls.Add(this.btn_add_light);
            this.Controls.Add(this.btn_change);
            this.Controls.Add(this.btm_apply);
            this.Controls.Add(this.canvas);
            this.Name = "XRayEngine";
            this.Size = new System.Drawing.Size(824, 406);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_x)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_z)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_specular)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_reflective)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_transparency)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.n_intensity)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.color_r)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.color_g)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pos_x)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pos_y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.color_b)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pos_z)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Button btm_apply;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.CheckBox chb_visible;
        private System.Windows.Forms.NumericUpDown num_x;
        private System.Windows.Forms.NumericUpDown num_y;
        private System.Windows.Forms.NumericUpDown num_z;
        private System.Windows.Forms.NumericUpDown n_specular;
        private System.Windows.Forms.NumericUpDown n_reflective;
        private System.Windows.Forms.NumericUpDown n_transparency;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown pos_x;
        private System.Windows.Forms.NumericUpDown pos_y;
        private System.Windows.Forms.NumericUpDown pos_z;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown color_r;
        private System.Windows.Forms.NumericUpDown color_g;
        private System.Windows.Forms.NumericUpDown color_b;
        private System.Windows.Forms.Button btn_flip;
        private System.Windows.Forms.Button btn_add_light;
        private System.Windows.Forms.Button btn_add_box;
        private System.Windows.Forms.Button btn_add_sphere;
        private System.Windows.Forms.ComboBox cb_light_type;
        private System.Windows.Forms.NumericUpDown n_intensity;
        private System.Windows.Forms.Button btn_delete_obj;
        private System.Windows.Forms.Button btn_change;
    }
}
