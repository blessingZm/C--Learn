namespace AwsTools.StCompare
{
    partial class WStatic
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.EndDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.StartDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.StId_text = new System.Windows.Forms.TextBox();
            this.CheckFile_button = new System.Windows.Forms.Button();
            this.StaticStart_button = new System.Windows.Forms.Button();
            this.Log_text = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Wind10_radiobutton = new System.Windows.Forms.RadioButton();
            this.Wind2_radiobutton = new System.Windows.Forms.RadioButton();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.EndDate);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.StartDate);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(40, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(401, 58);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "统计时间";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(192, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "截止：";
            // 
            // EndDate
            // 
            this.EndDate.CustomFormat = "yyyy-MM";
            this.EndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EndDate.Location = new System.Drawing.Point(254, 15);
            this.EndDate.Name = "EndDate";
            this.EndDate.Size = new System.Drawing.Size(140, 26);
            this.EndDate.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(172, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "开始：";
            // 
            // StartDate
            // 
            this.StartDate.CustomFormat = "yyyy-MM";
            this.StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StartDate.Location = new System.Drawing.Point(68, 19);
            this.StartDate.Name = "StartDate";
            this.StartDate.Size = new System.Drawing.Size(79, 26);
            this.StartDate.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(16, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.StId_text);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(482, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 57);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "区站号";
            // 
            // StId_text
            // 
            this.StId_text.Location = new System.Drawing.Point(6, 19);
            this.StId_text.Name = "StId_text";
            this.StId_text.Size = new System.Drawing.Size(126, 26);
            this.StId_text.TabIndex = 0;
            this.StId_text.Text = "57461";
            // 
            // CheckFile_button
            // 
            this.CheckFile_button.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CheckFile_button.Location = new System.Drawing.Point(40, 77);
            this.CheckFile_button.Name = "CheckFile_button";
            this.CheckFile_button.Size = new System.Drawing.Size(401, 38);
            this.CheckFile_button.TabIndex = 3;
            this.CheckFile_button.Text = "统计前 点我 检查文件是否齐全！";
            this.CheckFile_button.UseVisualStyleBackColor = true;
            this.CheckFile_button.Click += new System.EventHandler(this.CheckFile_button_Click);
            // 
            // StaticStart_button
            // 
            this.StaticStart_button.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StaticStart_button.Location = new System.Drawing.Point(482, 137);
            this.StaticStart_button.Name = "StaticStart_button";
            this.StaticStart_button.Size = new System.Drawing.Size(157, 38);
            this.StaticStart_button.TabIndex = 4;
            this.StaticStart_button.Text = "开始统计";
            this.StaticStart_button.UseVisualStyleBackColor = true;
            this.StaticStart_button.Click += new System.EventHandler(this.StaticStart_button_Click);
            // 
            // Log_text
            // 
            this.Log_text.Location = new System.Drawing.Point(40, 190);
            this.Log_text.Multiline = true;
            this.Log_text.Name = "Log_text";
            this.Log_text.Size = new System.Drawing.Size(599, 223);
            this.Log_text.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Wind10_radiobutton);
            this.groupBox3.Controls.Add(this.Wind2_radiobutton);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(40, 122);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(401, 62);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "选择统计的风类";
            // 
            // Wind10_radiobutton
            // 
            this.Wind10_radiobutton.AutoSize = true;
            this.Wind10_radiobutton.Location = new System.Drawing.Point(176, 29);
            this.Wind10_radiobutton.Name = "Wind10_radiobutton";
            this.Wind10_radiobutton.Size = new System.Drawing.Size(90, 20);
            this.Wind10_radiobutton.TabIndex = 1;
            this.Wind10_radiobutton.Text = "10分钟风";
            this.Wind10_radiobutton.UseVisualStyleBackColor = true;
            // 
            // Wind2_radiobutton
            // 
            this.Wind2_radiobutton.AutoSize = true;
            this.Wind2_radiobutton.Checked = true;
            this.Wind2_radiobutton.Location = new System.Drawing.Point(7, 26);
            this.Wind2_radiobutton.Name = "Wind2_radiobutton";
            this.Wind2_radiobutton.Size = new System.Drawing.Size(82, 20);
            this.Wind2_radiobutton.TabIndex = 0;
            this.Wind2_radiobutton.TabStop = true;
            this.Wind2_radiobutton.Text = "2分钟风";
            this.Wind2_radiobutton.UseVisualStyleBackColor = true;
            // 
            // WStatic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.Log_text);
            this.Controls.Add(this.StaticStart_button);
            this.Controls.Add(this.CheckFile_button);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "WStatic";
            this.Text = "台站对比观测--用于统计风向相符率、风向频率";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker EndDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker StartDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox StId_text;
        private System.Windows.Forms.Button CheckFile_button;
        private System.Windows.Forms.Button StaticStart_button;
        private System.Windows.Forms.TextBox Log_text;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton Wind10_radiobutton;
        private System.Windows.Forms.RadioButton Wind2_radiobutton;
    }
}