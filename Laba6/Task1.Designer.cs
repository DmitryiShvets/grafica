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
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Location = new System.Drawing.Point(93, 71);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(525, 373);
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
            // Task1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 588);
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
    }
}