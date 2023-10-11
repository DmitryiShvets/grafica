namespace blank
{
    partial class VectorPaint
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
            this.components = new System.ComponentModel.Container();
            this.status = new System.Windows.Forms.Label();
            this.with_bar = new System.Windows.Forms.TrackBar();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btn_color_2 = new System.Windows.Forms.Button();
            this.btn_color = new System.Windows.Forms.Button();
            this.cur_info = new System.Windows.Forms.Label();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_apply = new System.Windows.Forms.Button();
            this.btn_scale = new System.Windows.Forms.Button();
            this.btn_rotate_arround_dot = new System.Windows.Forms.Button();
            this.btn_rotate_edge = new System.Windows.Forms.Button();
            this.btn_cross = new System.Windows.Forms.Button();
            this.btn_rotate_center = new System.Windows.Forms.Button();
            this.btn_dot_classify = new System.Windows.Forms.Button();
            this.btn_move = new System.Windows.Forms.Button();
            this.btn_add_polygon = new System.Windows.Forms.Button();
            this.canvas = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.with_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(378, 9);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(40, 13);
            this.status.TabIndex = 69;
            this.status.Text = "статус";
            // 
            // with_bar
            // 
            this.with_bar.Location = new System.Drawing.Point(179, 9);
            this.with_bar.Minimum = 1;
            this.with_bar.Name = "with_bar";
            this.with_bar.Size = new System.Drawing.Size(77, 45);
            this.with_bar.TabIndex = 68;
            this.with_bar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip1.SetToolTip(this.with_bar, "Толщина");
            this.with_bar.Value = 3;
            this.with_bar.ValueChanged += new System.EventHandler(this.with_bar_ValueChanged);
            // 
            // btn_color_2
            // 
            this.btn_color_2.BackColor = System.Drawing.Color.DarkMagenta;
            this.btn_color_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_color_2.Location = new System.Drawing.Point(318, 9);
            this.btn_color_2.Name = "btn_color_2";
            this.btn_color_2.Size = new System.Drawing.Size(40, 40);
            this.btn_color_2.TabIndex = 63;
            this.toolTip1.SetToolTip(this.btn_color_2, "Цвет вершин");
            this.btn_color_2.UseVisualStyleBackColor = false;
            this.btn_color_2.Click += new System.EventHandler(this.btn_color_2_Click);
            // 
            // btn_color
            // 
            this.btn_color.BackColor = System.Drawing.Color.LawnGreen;
            this.btn_color.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_color.Location = new System.Drawing.Point(272, 9);
            this.btn_color.Name = "btn_color";
            this.btn_color.Size = new System.Drawing.Size(40, 40);
            this.btn_color.TabIndex = 64;
            this.toolTip1.SetToolTip(this.btn_color, "Цвет ребер");
            this.btn_color.UseVisualStyleBackColor = false;
            this.btn_color.Click += new System.EventHandler(this.btn_color_Click);
            // 
            // cur_info
            // 
            this.cur_info.AutoSize = true;
            this.cur_info.Location = new System.Drawing.Point(378, 36);
            this.cur_info.Name = "cur_info";
            this.cur_info.Size = new System.Drawing.Size(33, 13);
            this.cur_info.TabIndex = 69;
            this.cur_info.Text = "инфо";
            // 
            // btn_clear
            // 
            this.btn_clear.Image = global::blank.Properties.Resources.icons8_clear1;
            this.btn_clear.Location = new System.Drawing.Point(123, 4);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(50, 50);
            this.btn_clear.TabIndex = 65;
            this.toolTip1.SetToolTip(this.btn_clear, "Удалить полигоны");
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_apply
            // 
            this.btn_apply.Image = global::blank.Properties.Resources.icons8_apply;
            this.btn_apply.Location = new System.Drawing.Point(67, 4);
            this.btn_apply.Name = "btn_apply";
            this.btn_apply.Size = new System.Drawing.Size(50, 50);
            this.btn_apply.TabIndex = 66;
            this.toolTip1.SetToolTip(this.btn_apply, "Сохранить полигон");
            this.btn_apply.UseVisualStyleBackColor = true;
            this.btn_apply.Click += new System.EventHandler(this.btn_apply_Click);
            // 
            // btn_scale
            // 
            this.btn_scale.Image = global::blank.Properties.Resources.icons8_scale;
            this.btn_scale.Location = new System.Drawing.Point(667, 172);
            this.btn_scale.Name = "btn_scale";
            this.btn_scale.Size = new System.Drawing.Size(50, 50);
            this.btn_scale.TabIndex = 67;
            this.toolTip1.SetToolTip(this.btn_scale, "Масштабирование относительно произвольной точки");
            this.btn_scale.UseVisualStyleBackColor = true;
            // 
            // btn_rotate_arround_dot
            // 
            this.btn_rotate_arround_dot.Image = global::blank.Properties.Resources.icons8_rotate;
            this.btn_rotate_arround_dot.Location = new System.Drawing.Point(667, 116);
            this.btn_rotate_arround_dot.Name = "btn_rotate_arround_dot";
            this.btn_rotate_arround_dot.Size = new System.Drawing.Size(50, 50);
            this.btn_rotate_arround_dot.TabIndex = 67;
            this.toolTip1.SetToolTip(this.btn_rotate_arround_dot, "Поворот вокруг произвольной точки");
            this.btn_rotate_arround_dot.UseVisualStyleBackColor = true;
            // 
            // btn_rotate_edge
            // 
            this.btn_rotate_edge.Image = global::blank.Properties.Resources.icons8_line_rotate;
            this.btn_rotate_edge.Location = new System.Drawing.Point(667, 452);
            this.btn_rotate_edge.Name = "btn_rotate_edge";
            this.btn_rotate_edge.Size = new System.Drawing.Size(50, 50);
            this.btn_rotate_edge.TabIndex = 67;
            this.btn_rotate_edge.UseVisualStyleBackColor = true;
            // 
            // btn_cross
            // 
            this.btn_cross.Image = global::blank.Properties.Resources.icons8_сross;
            this.btn_cross.Location = new System.Drawing.Point(667, 340);
            this.btn_cross.Name = "btn_cross";
            this.btn_cross.Size = new System.Drawing.Size(50, 50);
            this.btn_cross.TabIndex = 67;
            this.toolTip1.SetToolTip(this.btn_cross, "Поиск точки пересечения двух ребер (добавление второго ребра мышкой, динамически)" +
        ".");
            this.btn_cross.UseVisualStyleBackColor = true;
            // 
            // btn_rotate_center
            // 
            this.btn_rotate_center.Image = global::blank.Properties.Resources.icons8_rotate_edge;
            this.btn_rotate_center.Location = new System.Drawing.Point(667, 228);
            this.btn_rotate_center.Name = "btn_rotate_center";
            this.btn_rotate_center.Size = new System.Drawing.Size(50, 50);
            this.btn_rotate_center.TabIndex = 67;
            this.toolTip1.SetToolTip(this.btn_rotate_center, "Поворот вокруг своего центра");
            this.btn_rotate_center.UseVisualStyleBackColor = true;
            // 
            // btn_dot_classify
            // 
            this.btn_dot_classify.Image = global::blank.Properties.Resources.icons8_classify;
            this.btn_dot_classify.Location = new System.Drawing.Point(667, 396);
            this.btn_dot_classify.Name = "btn_dot_classify";
            this.btn_dot_classify.Size = new System.Drawing.Size(50, 50);
            this.btn_dot_classify.TabIndex = 67;
            this.toolTip1.SetToolTip(this.btn_dot_classify, "Принадлежит ли точка выпуклому");
            this.btn_dot_classify.UseVisualStyleBackColor = true;
            // 
            // btn_move
            // 
            this.btn_move.Image = global::blank.Properties.Resources.icons8_move;
            this.btn_move.Location = new System.Drawing.Point(667, 60);
            this.btn_move.Name = "btn_move";
            this.btn_move.Size = new System.Drawing.Size(50, 50);
            this.btn_move.TabIndex = 67;
            this.toolTip1.SetToolTip(this.btn_move, "Смещение на dx, dy;");
            this.btn_move.UseVisualStyleBackColor = true;
            // 
            // btn_add_polygon
            // 
            this.btn_add_polygon.Image = global::blank.Properties.Resources.icons8_add_point;
            this.btn_add_polygon.Location = new System.Drawing.Point(11, 4);
            this.btn_add_polygon.Name = "btn_add_polygon";
            this.btn_add_polygon.Size = new System.Drawing.Size(50, 50);
            this.btn_add_polygon.TabIndex = 67;
            this.toolTip1.SetToolTip(this.btn_add_polygon, "Добавить полигон");
            this.btn_add_polygon.UseVisualStyleBackColor = true;
            this.btn_add_polygon.Click += new System.EventHandler(this.btn_add_polygon_Click);
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.White;
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas.Location = new System.Drawing.Point(11, 60);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(650, 450);
            this.canvas.TabIndex = 62;
            this.canvas.TabStop = false;
            this.canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseClick);
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            // 
            // VectorPaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cur_info);
            this.Controls.Add(this.status);
            this.Controls.Add(this.with_bar);
            this.Controls.Add(this.btn_color_2);
            this.Controls.Add(this.btn_color);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_apply);
            this.Controls.Add(this.btn_scale);
            this.Controls.Add(this.btn_rotate_arround_dot);
            this.Controls.Add(this.btn_rotate_edge);
            this.Controls.Add(this.btn_cross);
            this.Controls.Add(this.btn_rotate_center);
            this.Controls.Add(this.btn_dot_classify);
            this.Controls.Add(this.btn_move);
            this.Controls.Add(this.btn_add_polygon);
            this.Controls.Add(this.canvas);
            this.Name = "VectorPaint";
            this.Size = new System.Drawing.Size(800, 530);
            ((System.ComponentModel.ISupportInitialize)(this.with_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label status;
        private System.Windows.Forms.TrackBar with_bar;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Button btn_color_2;
        private System.Windows.Forms.Button btn_color;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_apply;
        private System.Windows.Forms.Button btn_add_polygon;
        private System.Windows.Forms.Label cur_info;
        private System.Windows.Forms.Button btn_move;
        private System.Windows.Forms.Button btn_rotate_arround_dot;
        private System.Windows.Forms.Button btn_scale;
        private System.Windows.Forms.Button btn_dot_classify;
        private System.Windows.Forms.Button btn_rotate_center;
        private System.Windows.Forms.Button btn_cross;
        private System.Windows.Forms.Button btn_rotate_edge;
    }
}
