namespace blank
{
    partial class Task2
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
            this.vecPaintV1 = new blank.VecPaintV();
            this.SuspendLayout();
            // 
            // vecPaintV1
            // 
            this.vecPaintV1.Location = new System.Drawing.Point(-3, 12);
            this.vecPaintV1.Name = "vecPaintV1";
            this.vecPaintV1.Size = new System.Drawing.Size(800, 530);
            this.vecPaintV1.TabIndex = 0;
            // 
            // Task2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 565);
            this.Controls.Add(this.vecPaintV1);
            this.Name = "Task2";
            this.Text = "Task2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Task2_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private VecPaintV vecPaintV1;
    }
}