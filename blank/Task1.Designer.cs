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
            this.xRayEngine1 = new blank.XRayEngine();
            this.SuspendLayout();
            // 
            // xRayEngine1
            // 
            this.xRayEngine1.Location = new System.Drawing.Point(12, 12);
            this.xRayEngine1.Name = "xRayEngine1";
            this.xRayEngine1.Size = new System.Drawing.Size(824, 406);
            this.xRayEngine1.TabIndex = 0;
            // 
            // Task1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 522);
            this.Controls.Add(this.xRayEngine1);
            this.Name = "Task1";
            this.Text = "Task1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Task1_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private XRayEngine xRayEngine1;
    }
}