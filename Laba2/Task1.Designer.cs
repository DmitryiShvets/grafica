
namespace Laba2
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.open_file = new System.Windows.Forms.Button();
            this.source_pix = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gray_pix1 = new System.Windows.Forms.PictureBox();
            this.gray_pix2 = new System.Windows.Forms.PictureBox();
            this.compare_pix = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.clear_file = new System.Windows.Forms.Button();
            this.convert_to_gray = new System.Windows.Forms.Button();
            this.compare = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.source_pix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gray_pix1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gray_pix2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.compare_pix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // open_file
            // 
            this.open_file.Location = new System.Drawing.Point(537, 59);
            this.open_file.Name = "open_file";
            this.open_file.Size = new System.Drawing.Size(108, 23);
            this.open_file.TabIndex = 0;
            this.open_file.Text = "Выбрать файл";
            this.open_file.UseVisualStyleBackColor = true;
            this.open_file.Click += new System.EventHandler(this.open_file_Click);
            // 
            // source_pix
            // 
            this.source_pix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.source_pix.Location = new System.Drawing.Point(12, 34);
            this.source_pix.Name = "source_pix";
            this.source_pix.Size = new System.Drawing.Size(400, 300);
            this.source_pix.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.source_pix.TabIndex = 1;
            this.source_pix.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Исходное изображение";
            // 
            // gray_pix1
            // 
            this.gray_pix1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gray_pix1.Location = new System.Drawing.Point(772, 34);
            this.gray_pix1.Name = "gray_pix1";
            this.gray_pix1.Size = new System.Drawing.Size(400, 300);
            this.gray_pix1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gray_pix1.TabIndex = 1;
            this.gray_pix1.TabStop = false;
            this.gray_pix1.Click += new System.EventHandler(this.gray_pix1_Click);
            // 
            // gray_pix2
            // 
            this.gray_pix2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gray_pix2.Location = new System.Drawing.Point(772, 355);
            this.gray_pix2.Name = "gray_pix2";
            this.gray_pix2.Size = new System.Drawing.Size(400, 300);
            this.gray_pix2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gray_pix2.TabIndex = 1;
            this.gray_pix2.TabStop = false;
            this.gray_pix2.Click += new System.EventHandler(this.gray_pix2_Click);
            // 
            // compare_pix
            // 
            this.compare_pix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.compare_pix.Location = new System.Drawing.Point(12, 355);
            this.compare_pix.Name = "compare_pix";
            this.compare_pix.Size = new System.Drawing.Size(400, 300);
            this.compare_pix.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.compare_pix.TabIndex = 1;
            this.compare_pix.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(791, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "NTSC RGB";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(791, 337);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "sRGB";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 339);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Разность";
            // 
            // clear_file
            // 
            this.clear_file.Location = new System.Drawing.Point(537, 97);
            this.clear_file.Name = "clear_file";
            this.clear_file.Size = new System.Drawing.Size(108, 23);
            this.clear_file.TabIndex = 0;
            this.clear_file.Text = "Очистить";
            this.clear_file.UseVisualStyleBackColor = true;
            this.clear_file.Click += new System.EventHandler(this.clear_file_Click);
            // 
            // convert_to_gray
            // 
            this.convert_to_gray.Location = new System.Drawing.Point(537, 135);
            this.convert_to_gray.Name = "convert_to_gray";
            this.convert_to_gray.Size = new System.Drawing.Size(108, 23);
            this.convert_to_gray.TabIndex = 0;
            this.convert_to_gray.Text = "Конвертировать";
            this.convert_to_gray.UseVisualStyleBackColor = true;
            this.convert_to_gray.Click += new System.EventHandler(this.convert_to_gray_Click);
            // 
            // compare
            // 
            this.compare.Location = new System.Drawing.Point(537, 174);
            this.compare.Name = "compare";
            this.compare.Size = new System.Drawing.Size(108, 23);
            this.compare.TabIndex = 0;
            this.compare.Text = "Сравнить";
            this.compare.UseVisualStyleBackColor = true;
            this.compare.Click += new System.EventHandler(this.compare_Click);
            // 
            // chart1
            // 
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart1.Legends.Add(legend4);
            this.chart1.Location = new System.Drawing.Point(427, 355);
            this.chart1.Name = "chart1";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(329, 300);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            // 
            // Task1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gray_pix2);
            this.Controls.Add(this.gray_pix1);
            this.Controls.Add(this.compare_pix);
            this.Controls.Add(this.source_pix);
            this.Controls.Add(this.compare);
            this.Controls.Add(this.convert_to_gray);
            this.Controls.Add(this.clear_file);
            this.Controls.Add(this.open_file);
            this.Name = "Task1";
            this.Text = "Task1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Task1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.source_pix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gray_pix1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gray_pix2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.compare_pix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button open_file;
        private System.Windows.Forms.PictureBox source_pix;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox gray_pix1;
        private System.Windows.Forms.PictureBox gray_pix2;
        private System.Windows.Forms.PictureBox compare_pix;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button clear_file;
        private System.Windows.Forms.Button convert_to_gray;
        private System.Windows.Forms.Button compare;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}