namespace Laba5
{
    partial class Task3
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label_state = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_count = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button_move_point = new System.Windows.Forms.Button();
            this.button_delete_point = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.button_add_point = new System.Windows.Forms.Button();
            this.canvas = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(632, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Состояние:";
            // 
            // label_state
            // 
            this.label_state.AutoSize = true;
            this.label_state.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_state.Location = new System.Drawing.Point(632, 36);
            this.label_state.Name = "label_state";
            this.label_state.Size = new System.Drawing.Size(0, 20);
            this.label_state.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.Location = new System.Drawing.Point(631, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "Кол-во точек:";
            // 
            // label_count
            // 
            this.label_count.AutoSize = true;
            this.label_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label_count.Location = new System.Drawing.Point(795, 122);
            this.label_count.Name = "label_count";
            this.label_count.Size = new System.Drawing.Size(24, 26);
            this.label_count.TabIndex = 5;
            this.label_count.Text = "0";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox1.Location = new System.Drawing.Point(647, 162);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(197, 208);
            this.textBox1.TabIndex = 8;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.checkBox1.Location = new System.Drawing.Point(636, 402);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(207, 28);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Нарисовать кривую";
            this.toolTip1.SetToolTip(this.checkBox1, "Удаление точки");
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button_move_point
            // 
            this.button_move_point.Image = global::Laba5.Properties.Resources.icons8_move;
            this.button_move_point.Location = new System.Drawing.Point(800, 58);
            this.button_move_point.Name = "button_move_point";
            this.button_move_point.Size = new System.Drawing.Size(52, 52);
            this.button_move_point.TabIndex = 11;
            this.toolTip1.SetToolTip(this.button_move_point, "Переместить точку");
            this.button_move_point.UseVisualStyleBackColor = true;
            this.button_move_point.Click += new System.EventHandler(this.button_move_point_Click);
            // 
            // button_delete_point
            // 
            this.button_delete_point.Image = global::Laba5.Properties.Resources.icons8_eraser;
            this.button_delete_point.Location = new System.Drawing.Point(744, 58);
            this.button_delete_point.Name = "button_delete_point";
            this.button_delete_point.Size = new System.Drawing.Size(52, 52);
            this.button_delete_point.TabIndex = 9;
            this.toolTip1.SetToolTip(this.button_delete_point, "Удалить точку");
            this.button_delete_point.UseVisualStyleBackColor = true;
            this.button_delete_point.Click += new System.EventHandler(this.button_delete_point_Click);
            // 
            // button_clear
            // 
            this.button_clear.Image = global::Laba5.Properties.Resources.icons8_clear;
            this.button_clear.Location = new System.Drawing.Point(688, 58);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(52, 52);
            this.button_clear.TabIndex = 7;
            this.toolTip1.SetToolTip(this.button_clear, "Очистить");
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // button_add_point
            // 
            this.button_add_point.Image = global::Laba5.Properties.Resources.icons8_add_point;
            this.button_add_point.Location = new System.Drawing.Point(632, 58);
            this.button_add_point.Name = "button_add_point";
            this.button_add_point.Size = new System.Drawing.Size(52, 52);
            this.button_add_point.TabIndex = 1;
            this.toolTip1.SetToolTip(this.button_add_point, "Добавить точку");
            this.button_add_point.UseVisualStyleBackColor = true;
            this.button_add_point.Click += new System.EventHandler(this.button_add_point_Click);
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.SystemColors.Control;
            this.canvas.Location = new System.Drawing.Point(12, 12);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(614, 426);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            // 
            // Task3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(856, 450);
            this.Controls.Add(this.button_move_point);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button_delete_point);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.label_count);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_state);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_add_point);
            this.Controls.Add(this.canvas);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Task3";
            this.Text = "Task3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Task3_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Button button_add_point;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_state;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_count;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_delete_point;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button_move_point;
    }
}