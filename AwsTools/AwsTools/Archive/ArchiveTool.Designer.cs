﻿namespace AwsTools.Archive
{
    partial class ArchiveTool
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.EndDate = new System.Windows.Forms.DateTimePicker();
            this.StartDate = new System.Windows.Forms.DateTimePicker();
            this.StartArchive = new System.Windows.Forms.Button();
            this.SetConfig = new System.Windows.Forms.Button();
            this.Log_text = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.EndDate);
            this.groupBox1.Controls.Add(this.StartDate);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(38, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 68);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "起止时间设置";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "止：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "起：";
            // 
            // EndDate
            // 
            this.EndDate.CustomFormat = "yyyy-MM";
            this.EndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EndDate.Location = new System.Drawing.Point(272, 30);
            this.EndDate.Name = "EndDate";
            this.EndDate.Size = new System.Drawing.Size(108, 29);
            this.EndDate.TabIndex = 1;
            // 
            // StartDate
            // 
            this.StartDate.CustomFormat = "yyyy-MM";
            this.StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StartDate.Location = new System.Drawing.Point(59, 27);
            this.StartDate.Name = "StartDate";
            this.StartDate.Size = new System.Drawing.Size(108, 29);
            this.StartDate.TabIndex = 0;
            // 
            // StartArchive
            // 
            this.StartArchive.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StartArchive.Location = new System.Drawing.Point(476, 74);
            this.StartArchive.Name = "StartArchive";
            this.StartArchive.Size = new System.Drawing.Size(187, 57);
            this.StartArchive.TabIndex = 1;
            this.StartArchive.Text = "开始归档";
            this.StartArchive.UseVisualStyleBackColor = true;
            this.StartArchive.Click += new System.EventHandler(this.StartArchive_Click);
            // 
            // SetConfig
            // 
            this.SetConfig.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SetConfig.Location = new System.Drawing.Point(38, 0);
            this.SetConfig.Name = "SetConfig";
            this.SetConfig.Size = new System.Drawing.Size(107, 25);
            this.SetConfig.TabIndex = 2;
            this.SetConfig.Text = "参数设置";
            this.SetConfig.UseVisualStyleBackColor = true;
            this.SetConfig.Click += new System.EventHandler(this.SetConfig_Click);
            // 
            // Log_text
            // 
            this.Log_text.Location = new System.Drawing.Point(6, 20);
            this.Log_text.Multiline = true;
            this.Log_text.Name = "Log_text";
            this.Log_text.Size = new System.Drawing.Size(613, 221);
            this.Log_text.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Log_text);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(38, 147);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(625, 247);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "归档日志";
            // 
            // ArchiveTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 416);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.SetConfig);
            this.Controls.Add(this.StartArchive);
            this.Controls.Add(this.groupBox1);
            this.Name = "ArchiveTool";
            this.Text = "自动站采集文件归档";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker EndDate;
        private System.Windows.Forms.DateTimePicker StartDate;
        private System.Windows.Forms.Button StartArchive;
        private System.Windows.Forms.Button SetConfig;
        private System.Windows.Forms.TextBox Log_text;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}