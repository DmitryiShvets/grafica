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
            this.vectorPaintD1 = new blank.VectorPaintD();
            this.SuspendLayout();
            // 
            // vectorPaintD1
            // 
            this.vectorPaintD1.Location = new System.Drawing.Point(12, 12);
            this.vectorPaintD1.Name = "vectorPaintD1";
            this.vectorPaintD1.Size = new System.Drawing.Size(725, 530);
            this.vectorPaintD1.TabIndex = 0;
            // 
            // Task3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 539);
            this.Controls.Add(this.vectorPaintD1);
            this.Name = "Task3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Task3_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private VectorPaintD vectorPaintD1;
    }
}