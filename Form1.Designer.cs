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
            this.checkBoxStateErrDM1 = new System.Windows.Forms.CheckBox();
            this.checkBoxStateErr1 = new System.Windows.Forms.CheckBox();
            this.checkBoxStateOk1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxUp1 = new System.Windows.Forms.CheckBox();
            this.checkBoxDown1 = new System.Windows.Forms.CheckBox();
            this.checkBoxPwr1 = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoOn1 = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoUp1 = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoDown1 = new System.Windows.Forms.CheckBox();
            this.checkBoxRstAZ1 = new System.Windows.Forms.CheckBox();
            this.checkBoxDeblock1 = new System.Windows.Forms.CheckBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.checkBoxStateErrDM1);
            this.panel2.Controls.Add(this.checkBoxStateErr1);
            this.panel2.Controls.Add(this.checkBoxStateOk1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.trackBar1);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(11, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(126, 676);
            this.panel2.TabIndex = 1;
            // 
            // checkBoxStateErrDM1
            // 
            this.checkBoxStateErrDM1.AutoSize = true;
            this.checkBoxStateErrDM1.Location = new System.Drawing.Point(19, 413);
            this.checkBoxStateErrDM1.Name = "checkBoxStateErrDM1";
            this.checkBoxStateErrDM1.Size = new System.Drawing.Size(104, 17);
            this.checkBoxStateErrDM1.TabIndex = 9;
            this.checkBoxStateErrDM1.Text = "НеисправноУП";
            this.checkBoxStateErrDM1.UseVisualStyleBackColor = true;
            this.checkBoxStateErrDM1.Click += new System.EventHandler(this.CheckBoxStateManager);
            // 
            // checkBoxStateErr1
            // 
            this.checkBoxStateErr1.AutoSize = true;
            this.checkBoxStateErr1.Location = new System.Drawing.Point(19, 390);
            this.checkBoxStateErr1.Name = "checkBoxStateErr1";
            this.checkBoxStateErr1.Size = new System.Drawing.Size(88, 17);
            this.checkBoxStateErr1.TabIndex = 8;
            this.checkBoxStateErr1.Text = "Неисправно";
            this.checkBoxStateErr1.UseVisualStyleBackColor = true;
            this.checkBoxStateErr1.Click += new System.EventHandler(this.CheckBoxStateManager);
            // 
            // checkBoxStateOk1
            // 
            this.checkBoxStateOk1.AutoSize = true;
            this.checkBoxStateOk1.Checked = true;
            this.checkBoxStateOk1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxStateOk1.Enabled = false;
            this.checkBoxStateOk1.Location = new System.Drawing.Point(19, 367);
            this.checkBoxStateOk1.Name = "checkBoxStateOk1";
            this.checkBoxStateOk1.Size = new System.Drawing.Size(76, 17);
            this.checkBoxStateOk1.TabIndex = 7;
            this.checkBoxStateOk1.Text = "Исправно";
            this.checkBoxStateOk1.UseVisualStyleBackColor = true;
            this.checkBoxStateOk1.Click += new System.EventHandler(this.CheckBoxStateManager);
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
            this.textBox1.ReadOnly = true;
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
            this.trackBar1.Value = 600;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.checkBoxUp1);
            this.panel1.Controls.Add(this.checkBoxDown1);
            this.panel1.Controls.Add(this.checkBoxPwr1);
            this.panel1.Controls.Add(this.checkBoxAutoOn1);
            this.panel1.Controls.Add(this.checkBoxAutoUp1);
            this.panel1.Controls.Add(this.checkBoxAutoDown1);
            this.panel1.Controls.Add(this.checkBoxRstAZ1);
            this.panel1.Controls.Add(this.checkBoxDeblock1);
            this.panel1.Location = new System.Drawing.Point(3, 448);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 200);
            this.panel1.TabIndex = 11;
            // 
            // checkBoxUp1
            // 
            this.checkBoxUp1.AutoSize = true;
            this.checkBoxUp1.Location = new System.Drawing.Point(16, 10);
            this.checkBoxUp1.Name = "checkBoxUp1";
            this.checkBoxUp1.Size = new System.Drawing.Size(56, 17);
            this.checkBoxUp1.TabIndex = 11;
            this.checkBoxUp1.Text = "Вверх";
            this.checkBoxUp1.UseVisualStyleBackColor = true;
            this.checkBoxUp1.CheckedChanged += new System.EventHandler(this.KSKUSignalsCheck);
            // 
            // checkBoxDown1
            // 
            this.checkBoxDown1.AutoSize = true;
            this.checkBoxDown1.Location = new System.Drawing.Point(17, 33);
            this.checkBoxDown1.Name = "checkBoxDown1";
            this.checkBoxDown1.Size = new System.Drawing.Size(51, 17);
            this.checkBoxDown1.TabIndex = 12;
            this.checkBoxDown1.Text = "Вниз";
            this.checkBoxDown1.UseVisualStyleBackColor = true;
            this.checkBoxDown1.CheckedChanged += new System.EventHandler(this.KSKUSignalsCheck);
            // 
            // checkBoxPwr1
            // 
            this.checkBoxPwr1.AutoSize = true;
            this.checkBoxPwr1.Location = new System.Drawing.Point(16, 56);
            this.checkBoxPwr1.Name = "checkBoxPwr1";
            this.checkBoxPwr1.Size = new System.Drawing.Size(98, 17);
            this.checkBoxPwr1.TabIndex = 13;
            this.checkBoxPwr1.Text = "Откл. питания";
            this.checkBoxPwr1.UseVisualStyleBackColor = true;
            this.checkBoxPwr1.CheckedChanged += new System.EventHandler(this.KSKUSignalsCheck);
            // 
            // checkBoxAutoOn1
            // 
            this.checkBoxAutoOn1.AutoSize = true;
            this.checkBoxAutoOn1.Location = new System.Drawing.Point(17, 79);
            this.checkBoxAutoOn1.Name = "checkBoxAutoOn1";
            this.checkBoxAutoOn1.Size = new System.Drawing.Size(75, 17);
            this.checkBoxAutoOn1.TabIndex = 14;
            this.checkBoxAutoOn1.Text = "АВТ. ВКЛ";
            this.checkBoxAutoOn1.UseVisualStyleBackColor = true;
            this.checkBoxAutoOn1.CheckedChanged += new System.EventHandler(this.KSKUSignalsCheck);
            // 
            // checkBoxAutoUp1
            // 
            this.checkBoxAutoUp1.AutoSize = true;
            this.checkBoxAutoUp1.Location = new System.Drawing.Point(16, 102);
            this.checkBoxAutoUp1.Name = "checkBoxAutoUp1";
            this.checkBoxAutoUp1.Size = new System.Drawing.Size(88, 17);
            this.checkBoxAutoUp1.TabIndex = 15;
            this.checkBoxAutoUp1.Text = "АВТ. ВВЕРХ";
            this.checkBoxAutoUp1.UseVisualStyleBackColor = true;
            this.checkBoxAutoUp1.CheckedChanged += new System.EventHandler(this.KSKUSignalsCheck);
            // 
            // checkBoxAutoDown1
            // 
            this.checkBoxAutoDown1.AutoSize = true;
            this.checkBoxAutoDown1.Location = new System.Drawing.Point(16, 125);
            this.checkBoxAutoDown1.Name = "checkBoxAutoDown1";
            this.checkBoxAutoDown1.Size = new System.Drawing.Size(83, 17);
            this.checkBoxAutoDown1.TabIndex = 16;
            this.checkBoxAutoDown1.Text = "АВТ. ВНИЗ";
            this.checkBoxAutoDown1.UseVisualStyleBackColor = true;
            this.checkBoxAutoDown1.CheckedChanged += new System.EventHandler(this.KSKUSignalsCheck);
            // 
            // checkBoxRstAZ1
            // 
            this.checkBoxRstAZ1.AutoSize = true;
            this.checkBoxRstAZ1.Location = new System.Drawing.Point(16, 148);
            this.checkBoxRstAZ1.Name = "checkBoxRstAZ1";
            this.checkBoxRstAZ1.Size = new System.Drawing.Size(79, 17);
            this.checkBoxRstAZ1.TabIndex = 17;
            this.checkBoxRstAZ1.Text = "СБРОС АЗ";
            this.checkBoxRstAZ1.UseVisualStyleBackColor = true;
            this.checkBoxRstAZ1.CheckedChanged += new System.EventHandler(this.KSKUSignalsCheck);
            this.checkBoxRstAZ1.CheckStateChanged += new System.EventHandler(this.IOSignalsCheck);
            // 
            // checkBoxDeblock1
            // 
            this.checkBoxDeblock1.AutoSize = true;
            this.checkBoxDeblock1.Location = new System.Drawing.Point(3, 171);
            this.checkBoxDeblock1.Name = "checkBoxDeblock1";
            this.checkBoxDeblock1.Size = new System.Drawing.Size(116, 17);
            this.checkBoxDeblock1.TabIndex = 18;
            this.checkBoxDeblock1.Text = "ДЕБЛОКИРОВКА";
            this.checkBoxDeblock1.UseVisualStyleBackColor = true;
            this.checkBoxDeblock1.CheckedChanged += new System.EventHandler(this.KSKUSignalsCheck);
            this.checkBoxDeblock1.CheckStateChanged += new System.EventHandler(this.IOSignalsCheck);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.label3);
            this.panel8.Controls.Add(this.panel2);
            this.panel8.Location = new System.Drawing.Point(1, 1);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1204, 679);
            this.panel8.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(515, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "РО АР";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "ВКВ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(95, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "30%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "50%";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 218);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "70%";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 293);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "НКВ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(89, 293);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "600";
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBoxStateErrDM1;
        private System.Windows.Forms.CheckBox checkBoxStateErr1;
        private System.Windows.Forms.CheckBox checkBoxStateOk1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxPwr1;
        private System.Windows.Forms.CheckBox checkBoxDown1;
        private System.Windows.Forms.CheckBox checkBoxUp1;
        private System.Windows.Forms.CheckBox checkBoxDeblock1;
        private System.Windows.Forms.CheckBox checkBoxRstAZ1;
        private System.Windows.Forms.CheckBox checkBoxAutoDown1;
        private System.Windows.Forms.CheckBox checkBoxAutoUp1;
        private System.Windows.Forms.CheckBox checkBoxAutoOn1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}

