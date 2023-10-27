namespace blank
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
            this.vecPaintD1 = new blank.VecPaintD();
            this.SuspendLayout();
            // 
            // vecPaintD1
            // 
            this.vecPaintD1.BackColor = System.Drawing.SystemColors.Control;
            this.vecPaintD1.Location = new System.Drawing.Point(1, 24);
            this.vecPaintD1.Name = "vecPaintD1";
            this.vecPaintD1.Size = new System.Drawing.Size(1076, 530);
            this.vecPaintD1.TabIndex = 0;
            // 
            // Task3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 581);
            this.Controls.Add(this.vecPaintD1);
            this.Name = "Task3";
            this.Text = "Task3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Task3_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private VecPaintD vecPaintD1;
    }
}