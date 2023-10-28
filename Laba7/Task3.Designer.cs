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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.graphD1 = new blank.GraphD();
            this.SuspendLayout();
            // 
            // graphD1
            // 
            this.graphD1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.graphD1.Location = new System.Drawing.Point(-6, -10);
            this.graphD1.Name = "graphD1";
            this.graphD1.Size = new System.Drawing.Size(1256, 711);
            this.graphD1.TabIndex = 0;
            // 
            // Task3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 689);
            this.Controls.Add(this.graphD1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Task3";
            this.Text = "Task3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Task3_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private GraphD graphD1;
    }
}