namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.StidSelect = new System.Windows.Forms.CheckedListBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.DatasSelect = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ElementsSelect = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.EnddateTime = new System.Windows.Forms.DateTimePicker();
            this.StartdateTime = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.ResultsPath = new System.Windows.Forms.TextBox();
            this.ResultpathSelect = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StidSelect
            // 
            this.StidSelect.CheckOnClick = true;
            this.StidSelect.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StidSelect.Items.AddRange(new object[] {
            "区站号选择"});
            this.StidSelect.Location = new System.Drawing.Point(143, 88);
            this.StidSelect.Name = "StidSelect";
            this.StidSelect.Size = new System.Drawing.Size(197, 148);
            this.StidSelect.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2.Location = new System.Drawing.Point(37, 155);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 19);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "区站选择：";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox3.Location = new System.Drawing.Point(37, 24);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 23);
            this.textBox3.TabIndex = 4;
            this.textBox3.Text = "资料选择：";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DatasSelect
            // 
            this.DatasSelect.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DatasSelect.FormattingEnabled = true;
            this.DatasSelect.Items.AddRange(new object[] {
            "地面逐小时资料",
            "地面日值资料",
            "地面月值资料",
            "地面年值资料"});
            this.DatasSelect.Location = new System.Drawing.Point(143, 24);
            this.DatasSelect.Name = "DatasSelect";
            this.DatasSelect.Size = new System.Drawing.Size(197, 24);
            this.DatasSelect.TabIndex = 5;
            this.DatasSelect.SelectedIndexChanged += new System.EventHandler(this.DatasSelect_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(385, 23);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(101, 24);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "要素选择：";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ElementsSelect
            // 
            this.ElementsSelect.CheckOnClick = true;
            this.ElementsSelect.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ElementsSelect.Items.AddRange(new object[] {
            "要素选择"});
            this.ElementsSelect.Location = new System.Drawing.Point(385, 64);
            this.ElementsSelect.Name = "ElementsSelect";
            this.ElementsSelect.Size = new System.Drawing.Size(408, 172);
            this.ElementsSelect.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.EnddateTime);
            this.groupBox1.Controls.Add(this.StartdateTime);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(37, 264);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(303, 140);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据起止时间";
            // 
            // textBox5
            // 
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox5.Location = new System.Drawing.Point(6, 93);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(60, 19);
            this.textBox5.TabIndex = 6;
            this.textBox5.Text = "止：";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox4.Location = new System.Drawing.Point(6, 39);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(60, 19);
            this.textBox4.TabIndex = 5;
            this.textBox4.Text = "起：";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EnddateTime
            // 
            this.EnddateTime.CustomFormat = "yyyy-MM-dd HH";
            this.EnddateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EnddateTime.Location = new System.Drawing.Point(72, 89);
            this.EnddateTime.Name = "EnddateTime";
            this.EnddateTime.Size = new System.Drawing.Size(200, 26);
            this.EnddateTime.TabIndex = 1;
            // 
            // StartdateTime
            // 
            this.StartdateTime.CustomFormat = "yyyy-MM-dd HH";
            this.StartdateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StartdateTime.Location = new System.Drawing.Point(72, 35);
            this.StartdateTime.Name = "StartdateTime";
            this.StartdateTime.Size = new System.Drawing.Size(200, 26);
            this.StartdateTime.TabIndex = 0;
            this.StartdateTime.Value = new System.DateTime(2018, 2, 11, 0, 0, 0, 0);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)), true);
            this.button1.Location = new System.Drawing.Point(637, 353);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 35);
            this.button1.TabIndex = 9;
            this.button1.Text = "下 载";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // ResultsPath
            // 
            this.ResultsPath.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ResultsPath.Location = new System.Drawing.Point(385, 289);
            this.ResultsPath.Multiline = true;
            this.ResultsPath.Name = "ResultsPath";
            this.ResultsPath.Size = new System.Drawing.Size(352, 30);
            this.ResultsPath.TabIndex = 11;
            this.ResultsPath.Text = ".\\results";
            // 
            // ResultpathSelect
            // 
            this.ResultpathSelect.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ResultpathSelect.Location = new System.Drawing.Point(743, 289);
            this.ResultpathSelect.Name = "ResultpathSelect";
            this.ResultpathSelect.Size = new System.Drawing.Size(50, 30);
            this.ResultpathSelect.TabIndex = 12;
            this.ResultpathSelect.Text = "··";
            this.ResultpathSelect.UseVisualStyleBackColor = true;
            this.ResultpathSelect.Click += new System.EventHandler(this.Button2_Click);
            // 
            // textBox6
            // 
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox6.Location = new System.Drawing.Point(385, 264);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 19);
            this.textBox6.TabIndex = 13;
            this.textBox6.Text = "下载目录选择：";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox7
            // 
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox7.ForeColor = System.Drawing.Color.Blue;
            this.textBox7.Location = new System.Drawing.Point(69, 487);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(711, 21);
            this.textBox7.TabIndex = 14;
            this.textBox7.Text = "点击下载后请耐心等待至弹出下载完成提示！下载时间会因cimiss服务器状态和数据时间长短差距较大！";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 520);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.ResultpathSelect);
            this.Controls.Add(this.ResultsPath);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ElementsSelect);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.DatasSelect);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.StidSelect);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "Form1";
            this.Text = "ZM  数据含义及下载错误码详情请查看CIMISS网站说明！";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckedListBox StidSelect;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox DatasSelect;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckedListBox ElementsSelect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.DateTimePicker EnddateTime;
        private System.Windows.Forms.DateTimePicker StartdateTime;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox ResultsPath;
        private System.Windows.Forms.Button ResultpathSelect;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
    }
}

