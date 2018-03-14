namespace AwsTools.MonthClimateAssess
{
    partial class MonthClimate
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
            this.HistoryDatas = new System.Windows.Forms.DataGridView();
            this.Month = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AveTemp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rsum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ssum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DateSelect = new System.Windows.Forms.DateTimePicker();
            this.CreateResultButtom = new System.Windows.Forms.Button();
            this.ClimateResult = new System.Windows.Forms.TextBox();
            this.SaveHistoryButton = new System.Windows.Forms.Button();
            this.DBfileSelect = new System.Windows.Forms.Button();
            this.DBfile_text = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HistoryDatas)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.HistoryDatas);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(554, 414);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "30年历史数据及文件参数";
            // 
            // HistoryDatas
            // 
            this.HistoryDatas.AllowUserToAddRows = false;
            this.HistoryDatas.AllowUserToDeleteRows = false;
            this.HistoryDatas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HistoryDatas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Month,
            this.AveTemp,
            this.Rsum,
            this.Ssum});
            this.HistoryDatas.Location = new System.Drawing.Point(7, 29);
            this.HistoryDatas.Name = "HistoryDatas";
            this.HistoryDatas.RowTemplate.Height = 23;
            this.HistoryDatas.Size = new System.Drawing.Size(543, 318);
            this.HistoryDatas.TabIndex = 0;
            this.HistoryDatas.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.HistoryDatas_CellEndEdit);
            // 
            // Month
            // 
            this.Month.HeaderText = "月份";
            this.Month.Name = "Month";
            // 
            // AveTemp
            // 
            this.AveTemp.HeaderText = "平均气温℃";
            this.AveTemp.Name = "AveTemp";
            this.AveTemp.Width = 140;
            // 
            // Rsum
            // 
            this.Rsum.HeaderText = "降水量mm";
            this.Rsum.Name = "Rsum";
            this.Rsum.Width = 120;
            // 
            // Ssum
            // 
            this.Ssum.HeaderText = "日照时数h";
            this.Ssum.Name = "Ssum";
            this.Ssum.Width = 140;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DateSelect);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(572, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(139, 67);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "时间选择";
            // 
            // DateSelect
            // 
            this.DateSelect.CustomFormat = "yyyy-MM";
            this.DateSelect.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateSelect.Location = new System.Drawing.Point(6, 28);
            this.DateSelect.Name = "DateSelect";
            this.DateSelect.Size = new System.Drawing.Size(107, 29);
            this.DateSelect.TabIndex = 0;
            // 
            // CreateResultButtom
            // 
            this.CreateResultButtom.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CreateResultButtom.Location = new System.Drawing.Point(737, 53);
            this.CreateResultButtom.Name = "CreateResultButtom";
            this.CreateResultButtom.Size = new System.Drawing.Size(143, 29);
            this.CreateResultButtom.TabIndex = 2;
            this.CreateResultButtom.Text = "气候评价生成";
            this.CreateResultButtom.UseVisualStyleBackColor = true;
            this.CreateResultButtom.Click += new System.EventHandler(this.CreateResultButtom_Click);
            // 
            // ClimateResult
            // 
            this.ClimateResult.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClimateResult.Location = new System.Drawing.Point(572, 98);
            this.ClimateResult.Multiline = true;
            this.ClimateResult.Name = "ClimateResult";
            this.ClimateResult.Size = new System.Drawing.Size(334, 379);
            this.ClimateResult.TabIndex = 3;
            // 
            // SaveHistoryButton
            // 
            this.SaveHistoryButton.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SaveHistoryButton.Location = new System.Drawing.Point(124, 432);
            this.SaveHistoryButton.Name = "SaveHistoryButton";
            this.SaveHistoryButton.Size = new System.Drawing.Size(235, 45);
            this.SaveHistoryButton.TabIndex = 4;
            this.SaveHistoryButton.Text = "参数保存";
            this.SaveHistoryButton.UseVisualStyleBackColor = true;
            this.SaveHistoryButton.Click += new System.EventHandler(this.SaveHistoryButton_Click);
            // 
            // DBfileSelect
            // 
            this.DBfileSelect.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DBfileSelect.Location = new System.Drawing.Point(19, 379);
            this.DBfileSelect.Name = "DBfileSelect";
            this.DBfileSelect.Size = new System.Drawing.Size(169, 28);
            this.DBfileSelect.TabIndex = 5;
            this.DBfileSelect.Text = "数据库文件选择";
            this.DBfileSelect.UseVisualStyleBackColor = true;
            this.DBfileSelect.Click += new System.EventHandler(this.DBfileSelect_Click);
            // 
            // DBfile_text
            // 
            this.DBfile_text.Enabled = false;
            this.DBfile_text.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DBfile_text.Location = new System.Drawing.Point(194, 378);
            this.DBfile_text.Name = "DBfile_text";
            this.DBfile_text.Size = new System.Drawing.Size(368, 29);
            this.DBfile_text.TabIndex = 6;
            // 
            // MonthClimate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 528);
            this.Controls.Add(this.DBfile_text);
            this.Controls.Add(this.DBfileSelect);
            this.Controls.Add(this.SaveHistoryButton);
            this.Controls.Add(this.ClimateResult);
            this.Controls.Add(this.CreateResultButtom);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MonthClimate";
            this.Text = "气候评价自动生成";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MonthClimate_FormClosing);
            this.Load += new System.EventHandler(this.MonthClimate_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HistoryDatas)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView HistoryDatas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Month;
        private System.Windows.Forms.DataGridViewTextBoxColumn AveTemp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rsum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ssum;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker DateSelect;
        private System.Windows.Forms.Button CreateResultButtom;
        private System.Windows.Forms.TextBox ClimateResult;
        private System.Windows.Forms.Button SaveHistoryButton;
        private System.Windows.Forms.Button DBfileSelect;
        private System.Windows.Forms.TextBox DBfile_text;
    }
}