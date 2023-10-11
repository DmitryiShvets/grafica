namespace Laba5
{
    partial class Paint
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
            this.btn_color_2 = new System.Windows.Forms.Button();
            this.btn_color = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_eraser = new System.Windows.Forms.Button();
            this.btn_pen = new System.Windows.Forms.Button();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.with_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(422, 18);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(0, 13);
            this.status.TabIndex = 61;
            // 
            // with_bar
            // 
            this.with_bar.Location = new System.Drawing.Point(146, 4);
            this.with_bar.Minimum = 1;
            this.with_bar.Name = "with_bar";
            this.with_bar.Size = new System.Drawing.Size(77, 45);
            this.with_bar.TabIndex = 60;
            this.with_bar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.with_bar.Value = 3;
            this.with_bar.ValueChanged += new System.EventHandler(this.with_bar_ValueChanged);
            // 
            // btn_color_2
            // 
            this.btn_color_2.BackColor = System.Drawing.Color.Yellow;
            this.btn_color_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_color_2.Location = new System.Drawing.Point(275, 4);
            this.btn_color_2.Name = "btn_color_2";
            this.btn_color_2.Size = new System.Drawing.Size(40, 40);
            this.btn_color_2.TabIndex = 55;
            this.btn_color_2.UseVisualStyleBackColor = false;
            this.btn_color_2.Click += new System.EventHandler(this.btn_color_2_Click);
            // 
            // btn_color
            // 
            this.btn_color.BackColor = System.Drawing.Color.Black;
            this.btn_color.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_color.Location = new System.Drawing.Point(229, 4);
            this.btn_color.Name = "btn_color";
            this.btn_color.Size = new System.Drawing.Size(40, 40);
            this.btn_color.TabIndex = 56;
            this.btn_color.UseVisualStyleBackColor = false;
            this.btn_color.Click += new System.EventHandler(this.btn_color_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Image = global::Laba5.Properties.Resources.icons8_clear;
            this.btn_clear.Location = new System.Drawing.Point(100, 4);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(40, 40);
            this.btn_clear.TabIndex = 57;
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_eraser
            // 
            this.btn_eraser.Image = global::Laba5.Properties.Resources.icons8_eraser;
            this.btn_eraser.Location = new System.Drawing.Point(54, 4);
            this.btn_eraser.Name = "btn_eraser";
            this.btn_eraser.Size = new System.Drawing.Size(40, 40);
            this.btn_eraser.TabIndex = 58;
            this.btn_eraser.UseVisualStyleBackColor = true;
            this.btn_eraser.Click += new System.EventHandler(this.btn_eraser_Click);
            // 
            // btn_pen
            // 
            this.btn_pen.Image = global::Laba5.Properties.Resources.icons8_pen;
            this.btn_pen.Location = new System.Drawing.Point(8, 4);
            this.btn_pen.Name = "btn_pen";
            this.btn_pen.Size = new System.Drawing.Size(40, 40);
            this.btn_pen.TabIndex = 59;
            this.btn_pen.UseVisualStyleBackColor = true;
            this.btn_pen.Click += new System.EventHandler(this.btn_pen_Click);
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.White;
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas.Location = new System.Drawing.Point(3, 50);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(650, 450);
            this.canvas.TabIndex = 54;
            this.canvas.TabStop = false;
            this.canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseClick);
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            // 
            // Paint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.status);
            this.Controls.Add(this.with_bar);
            this.Controls.Add(this.btn_color_2);
            this.Controls.Add(this.btn_color);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_eraser);
            this.Controls.Add(this.btn_pen);
            this.Controls.Add(this.canvas);
            this.Name = "Paint";
            this.Size = new System.Drawing.Size(656, 504);
            ((System.ComponentModel.ISupportInitialize)(this.with_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label status;
        private System.Windows.Forms.TrackBar with_bar;
        private System.Windows.Forms.Button btn_color_2;
        private System.Windows.Forms.Button btn_color;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_eraser;
        private System.Windows.Forms.Button btn_pen;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
