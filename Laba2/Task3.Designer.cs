
namespace Laba2
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.button_LoadImage = new System.Windows.Forms.Button();
            this.SaveImageButton = new System.Windows.Forms.Button();
            this.HueLabel = new System.Windows.Forms.Label();
            this.SaturationLabel = new System.Windows.Forms.Label();
            this.ValueLabel = new System.Windows.Forms.Label();
            this.hueTrackBar = new System.Windows.Forms.TrackBar();
            this.saturationTrackBar = new System.Windows.Forms.TrackBar();
            this.valueTrackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hueTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saturationTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(612, 523);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // button_LoadImage
            // 
            this.button_LoadImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_LoadImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.button_LoadImage.Location = new System.Drawing.Point(676, 12);
            this.button_LoadImage.Name = "button_LoadImage";
            this.button_LoadImage.Size = new System.Drawing.Size(258, 87);
            this.button_LoadImage.TabIndex = 3;
            this.button_LoadImage.Text = "Загрузить изображение";
            this.button_LoadImage.UseVisualStyleBackColor = true;
            this.button_LoadImage.Click += new System.EventHandler(this.button_LoadImage_Click);
            // 
            // SaveImageButton
            // 
            this.SaveImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveImageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveImageButton.Location = new System.Drawing.Point(676, 105);
            this.SaveImageButton.Name = "SaveImageButton";
            this.SaveImageButton.Size = new System.Drawing.Size(258, 87);
            this.SaveImageButton.TabIndex = 4;
            this.SaveImageButton.Text = "Сохранить ";
            this.SaveImageButton.UseVisualStyleBackColor = true;
            this.SaveImageButton.Click += new System.EventHandler(this.SaveImageButton_Click);
            // 
            // HueLabel
            // 
            this.HueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.HueLabel.AutoSize = true;
            this.HueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HueLabel.Location = new System.Drawing.Point(671, 308);
            this.HueLabel.Name = "HueLabel";
            this.HueLabel.Size = new System.Drawing.Size(136, 29);
            this.HueLabel.TabIndex = 6;
            this.HueLabel.Text = "Оттенок: 0";
            // 
            // SaturationLabel
            // 
            this.SaturationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaturationLabel.AutoSize = true;
            this.SaturationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaturationLabel.Location = new System.Drawing.Point(671, 388);
            this.SaturationLabel.Name = "SaturationLabel";
            this.SaturationLabel.Size = new System.Drawing.Size(212, 29);
            this.SaturationLabel.TabIndex = 6;
            this.SaturationLabel.Text = "Насыщенность: 0";
            // 
            // ValueLabel
            // 
            this.ValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ValueLabel.AutoSize = true;
            this.ValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ValueLabel.Location = new System.Drawing.Point(671, 459);
            this.ValueLabel.Name = "ValueLabel";
            this.ValueLabel.Size = new System.Drawing.Size(218, 29);
            this.ValueLabel.TabIndex = 6;
            this.ValueLabel.Text = "Интенсивность: 0";
            // 
            // hueTrackBar
            // 
            this.hueTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.hueTrackBar.Location = new System.Drawing.Point(676, 340);
            this.hueTrackBar.Maximum = 360;
            this.hueTrackBar.Name = "hueTrackBar";
            this.hueTrackBar.Size = new System.Drawing.Size(261, 45);
            this.hueTrackBar.TabIndex = 7;
            this.hueTrackBar.TickFrequency = 20;
            this.hueTrackBar.Scroll += new System.EventHandler(this.hueTrackBar_Scroll);
            this.hueTrackBar.MouseCaptureChanged += new System.EventHandler(this.hueTrackBar_MouseCaptureChanged);
            // 
            // saturationTrackBar
            // 
            this.saturationTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saturationTrackBar.Location = new System.Drawing.Point(676, 420);
            this.saturationTrackBar.Maximum = 100;
            this.saturationTrackBar.Name = "saturationTrackBar";
            this.saturationTrackBar.Size = new System.Drawing.Size(261, 45);
            this.saturationTrackBar.TabIndex = 7;
            this.saturationTrackBar.TickFrequency = 5;
            this.saturationTrackBar.Value = 50;
            this.saturationTrackBar.Scroll += new System.EventHandler(this.saturationTrackBar_Scroll);
            this.saturationTrackBar.MouseCaptureChanged += new System.EventHandler(this.saturationTrackBar_MouseCaptureChanged);
            // 
            // valueTrackBar
            // 
            this.valueTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.valueTrackBar.Location = new System.Drawing.Point(676, 491);
            this.valueTrackBar.Maximum = 100;
            this.valueTrackBar.Name = "valueTrackBar";
            this.valueTrackBar.Size = new System.Drawing.Size(261, 45);
            this.valueTrackBar.TabIndex = 7;
            this.valueTrackBar.TickFrequency = 5;
            this.valueTrackBar.Value = 50;
            this.valueTrackBar.Scroll += new System.EventHandler(this.valueTrackBar_Scroll);
            this.valueTrackBar.MouseCaptureChanged += new System.EventHandler(this.valueTrackBar_MouseCaptureChanged);
            // 
            // Task3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 547);
            this.Controls.Add(this.valueTrackBar);
            this.Controls.Add(this.saturationTrackBar);
            this.Controls.Add(this.hueTrackBar);
            this.Controls.Add(this.ValueLabel);
            this.Controls.Add(this.SaturationLabel);
            this.Controls.Add(this.HueLabel);
            this.Controls.Add(this.SaveImageButton);
            this.Controls.Add(this.button_LoadImage);
            this.Controls.Add(this.pictureBox);
            this.Name = "Task3";
            this.Text = "Task3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Task3_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hueTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saturationTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button button_LoadImage;
        private System.Windows.Forms.Button SaveImageButton;
        private System.Windows.Forms.Label HueLabel;
        private System.Windows.Forms.Label SaturationLabel;
        private System.Windows.Forms.Label ValueLabel;
        private System.Windows.Forms.TrackBar hueTrackBar;
        private System.Windows.Forms.TrackBar saturationTrackBar;
        private System.Windows.Forms.TrackBar valueTrackBar;
    }
}