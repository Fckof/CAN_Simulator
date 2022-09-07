namespace CAN_Simulator
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBoxStateErr2 = new System.Windows.Forms.CheckBox();
            this.checkBoxStateErr = new System.Windows.Forms.CheckBox();
            this.checkBoxStateOk = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.panel8 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.checkBoxStateErr2);
            this.panel2.Controls.Add(this.checkBoxStateErr);
            this.panel2.Controls.Add(this.checkBoxStateOk);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.trackBar1);
            this.panel2.Location = new System.Drawing.Point(11, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(126, 676);
            this.panel2.TabIndex = 1;
            // 
            // checkBoxStateErr2
            // 
            this.checkBoxStateErr2.AutoSize = true;
            this.checkBoxStateErr2.Location = new System.Drawing.Point(19, 413);
            this.checkBoxStateErr2.Name = "checkBoxStateErr2";
            this.checkBoxStateErr2.Size = new System.Drawing.Size(104, 17);
            this.checkBoxStateErr2.TabIndex = 9;
            this.checkBoxStateErr2.Text = "НеисправноУП";
            this.checkBoxStateErr2.UseVisualStyleBackColor = true;
            this.checkBoxStateErr2.Click += new System.EventHandler(this.CheckBoxStateManager);
            // 
            // checkBoxStateErr
            // 
            this.checkBoxStateErr.AutoSize = true;
            this.checkBoxStateErr.Location = new System.Drawing.Point(19, 390);
            this.checkBoxStateErr.Name = "checkBoxStateErr";
            this.checkBoxStateErr.Size = new System.Drawing.Size(88, 17);
            this.checkBoxStateErr.TabIndex = 8;
            this.checkBoxStateErr.Text = "Неисправно";
            this.checkBoxStateErr.UseVisualStyleBackColor = true;
            this.checkBoxStateErr.Click += new System.EventHandler(this.CheckBoxStateManager);
            // 
            // checkBoxStateOk
            // 
            this.checkBoxStateOk.AutoSize = true;
            this.checkBoxStateOk.Checked = true;
            this.checkBoxStateOk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxStateOk.Enabled = false;
            this.checkBoxStateOk.Location = new System.Drawing.Point(19, 367);
            this.checkBoxStateOk.Name = "checkBoxStateOk";
            this.checkBoxStateOk.Size = new System.Drawing.Size(76, 17);
            this.checkBoxStateOk.TabIndex = 7;
            this.checkBoxStateOk.Text = "Исправно";
            this.checkBoxStateOk.UseVisualStyleBackColor = true;
            this.checkBoxStateOk.Click += new System.EventHandler(this.CheckBoxStateManager);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(98, 331);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "мм";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(32, 321);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(63, 26);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(30, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "РО АР";
            // 
            // trackBar1
            // 
            this.trackBar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackBar1.LargeChange = 10;
            this.trackBar1.Location = new System.Drawing.Point(41, 35);
            this.trackBar1.Maximum = 600;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.trackBar1.Size = new System.Drawing.Size(45, 280);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel2);
            this.panel8.Location = new System.Drawing.Point(1, 1);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1204, 679);
            this.panel8.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(3, 484);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 36);
            this.button2.TabIndex = 10;
            this.button2.Text = "ShowMessage";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 681);
            this.Controls.Add(this.panel8);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CAN Simulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBoxStateErr2;
        private System.Windows.Forms.CheckBox checkBoxStateErr;
        private System.Windows.Forms.CheckBox checkBoxStateOk;
        private System.Windows.Forms.Button button2;
    }
}

