
namespace Laba2
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button_LoadImage = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.button_red = new System.Windows.Forms.Button();
            this.button_green = new System.Windows.Forms.Button();
            this.button_blue = new System.Windows.Forms.Button();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // button_LoadImage
            // 
            this.button_LoadImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_LoadImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.button_LoadImage.Location = new System.Drawing.Point(938, 12);
            this.button_LoadImage.Name = "button_LoadImage";
            this.button_LoadImage.Size = new System.Drawing.Size(224, 87);
            this.button_LoadImage.TabIndex = 0;
            this.button_LoadImage.Text = "Загрузить изображение";
            this.button_LoadImage.UseVisualStyleBackColor = true;
            this.button_LoadImage.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(801, 581);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // button_red
            // 
            this.button_red.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_red.Enabled = false;
            this.button_red.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.button_red.Location = new System.Drawing.Point(938, 105);
            this.button_red.Name = "button_red";
            this.button_red.Size = new System.Drawing.Size(224, 62);
            this.button_red.TabIndex = 2;
            this.button_red.Text = "Выделить красный канал";
            this.button_red.UseVisualStyleBackColor = true;
            this.button_red.Click += new System.EventHandler(this.button_red_Click);
            // 
            // button_green
            // 
            this.button_green.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_green.Enabled = false;
            this.button_green.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.button_green.Location = new System.Drawing.Point(938, 173);
            this.button_green.Name = "button_green";
            this.button_green.Size = new System.Drawing.Size(224, 62);
            this.button_green.TabIndex = 3;
            this.button_green.Text = "Выделить зеленый канал";
            this.button_green.UseVisualStyleBackColor = true;
            this.button_green.Click += new System.EventHandler(this.button_green_Click);
            // 
            // button_blue
            // 
            this.button_blue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_blue.Enabled = false;
            this.button_blue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.button_blue.Location = new System.Drawing.Point(938, 241);
            this.button_blue.Name = "button_blue";
            this.button_blue.Size = new System.Drawing.Size(224, 62);
            this.button_blue.TabIndex = 4;
            this.button_blue.Text = "Выделить синий канал";
            this.button_blue.UseVisualStyleBackColor = true;
            this.button_blue.Click += new System.EventHandler(this.button_blue_Click);
            // 
            // chart
            // 
            this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(834, 309);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(328, 284);
            this.chart.TabIndex = 5;
            this.chart.Text = "chart";
            // 
            // Task2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 605);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.button_blue);
            this.Controls.Add(this.button_green);
            this.Controls.Add(this.button_red);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.button_LoadImage);
            this.MinimumSize = new System.Drawing.Size(1076, 643);
            this.Name = "Task2";
            this.Text = "Task2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Task2_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_LoadImage;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button button_red;
        private System.Windows.Forms.Button button_green;
        private System.Windows.Forms.Button button_blue;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
    }
}