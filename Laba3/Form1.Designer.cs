namespace Laba3
{
    partial class Form1
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_Task3 = new System.Windows.Forms.Button();
            this.button_Task2 = new System.Windows.Forms.Button();
            this.button_Task1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Task3
            // 
            this.button_Task3.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.button_Task3.Location = new System.Drawing.Point(489, 36);
            this.button_Task3.Name = "button_Task3";
            this.button_Task3.Size = new System.Drawing.Size(231, 89);
            this.button_Task3.TabIndex = 5;
            this.button_Task3.Text = "Задание 3";
            this.button_Task3.UseVisualStyleBackColor = true;
            this.button_Task3.Click += new System.EventHandler(this.button_Task3_Click);
            // 
            // button_Task2
            // 
            this.button_Task2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.button_Task2.Location = new System.Drawing.Point(252, 36);
            this.button_Task2.Name = "button_Task2";
            this.button_Task2.Size = new System.Drawing.Size(231, 89);
            this.button_Task2.TabIndex = 4;
            this.button_Task2.Text = "Задание 2";
            this.button_Task2.UseVisualStyleBackColor = true;
            this.button_Task2.Click += new System.EventHandler(this.button_Task2_Click);
            // 
            // button_Task1
            // 
            this.button_Task1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.button_Task1.Location = new System.Drawing.Point(15, 36);
            this.button_Task1.Name = "button_Task1";
            this.button_Task1.Size = new System.Drawing.Size(231, 89);
            this.button_Task1.TabIndex = 3;
            this.button_Task1.Text = "Задание 1";
            this.button_Task1.UseVisualStyleBackColor = true;
            this.button_Task1.Click += new System.EventHandler(this.button_Task1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 161);
            this.Controls.Add(this.button_Task3);
            this.Controls.Add(this.button_Task2);
            this.Controls.Add(this.button_Task1);
            this.Name = "Form1";
            this.Text = "Загатовка";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Task3;
        private System.Windows.Forms.Button button_Task2;
        private System.Windows.Forms.Button button_Task1;
    }
}

