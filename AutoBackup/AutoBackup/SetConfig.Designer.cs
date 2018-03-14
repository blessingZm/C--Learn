namespace AutoBackup
{
    partial class SetConfig
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
            this.SelectHour = new System.Windows.Forms.RadioButton();
            this.SelectDay = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.OrigiFileSelect = new System.Windows.Forms.Button();
            this.OrigiDirSelect = new System.Windows.Forms.Button();
            this.OrigiFileList = new System.Windows.Forms.DataGridView();
            this.origi_file = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TargitDirSelect = new System.Windows.Forms.Button();
            this.TargitDirList = new System.Windows.Forms.DataGridView();
            this.targit_dir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaveConfig = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrigiFileList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargitDirList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SelectDay);
            this.groupBox1.Controls.Add(this.SelectHour);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(33, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 67);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "备份频率选择";
            // 
            // SelectHour
            // 
            this.SelectHour.AutoSize = true;
            this.SelectHour.Checked = true;
            this.SelectHour.Location = new System.Drawing.Point(15, 28);
            this.SelectHour.Name = "SelectHour";
            this.SelectHour.Size = new System.Drawing.Size(111, 20);
            this.SelectHour.TabIndex = 0;
            this.SelectHour.TabStop = true;
            this.SelectHour.Text = "每小时备份";
            this.SelectHour.UseVisualStyleBackColor = true;
            // 
            // SelectDay
            // 
            this.SelectDay.AutoSize = true;
            this.SelectDay.Location = new System.Drawing.Point(171, 28);
            this.SelectDay.Name = "SelectDay";
            this.SelectDay.Size = new System.Drawing.Size(94, 20);
            this.SelectDay.TabIndex = 1;
            this.SelectDay.TabStop = true;
            this.SelectDay.Text = "每天备份";
            this.SelectDay.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.OrigiFileList);
            this.groupBox2.Controls.Add(this.OrigiDirSelect);
            this.groupBox2.Controls.Add(this.OrigiFileSelect);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(33, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(437, 206);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "源文件或文件夹选择";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TargitDirList);
            this.groupBox3.Controls.Add(this.TargitDirSelect);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(33, 327);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(437, 196);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "目标文件夹选择";
            // 
            // OrigiFileSelect
            // 
            this.OrigiFileSelect.Location = new System.Drawing.Point(7, 21);
            this.OrigiFileSelect.Name = "OrigiFileSelect";
            this.OrigiFileSelect.Size = new System.Drawing.Size(135, 29);
            this.OrigiFileSelect.TabIndex = 0;
            this.OrigiFileSelect.Text = "选择源文件";
            this.OrigiFileSelect.UseVisualStyleBackColor = true;
            this.OrigiFileSelect.Click += new System.EventHandler(this.OrigiFileSelect_Click);
            // 
            // OrigiDirSelect
            // 
            this.OrigiDirSelect.Location = new System.Drawing.Point(171, 20);
            this.OrigiDirSelect.Name = "OrigiDirSelect";
            this.OrigiDirSelect.Size = new System.Drawing.Size(145, 30);
            this.OrigiDirSelect.TabIndex = 1;
            this.OrigiDirSelect.Text = "选择源文件夹";
            this.OrigiDirSelect.UseVisualStyleBackColor = true;
            this.OrigiDirSelect.Click += new System.EventHandler(this.OrigiDirSelect_Click);
            // 
            // OrigiFileList
            // 
            this.OrigiFileList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrigiFileList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.origi_file});
            this.OrigiFileList.Location = new System.Drawing.Point(7, 56);
            this.OrigiFileList.Name = "OrigiFileList";
            this.OrigiFileList.RowTemplate.Height = 23;
            this.OrigiFileList.Size = new System.Drawing.Size(424, 144);
            this.OrigiFileList.TabIndex = 2;
            // 
            // origi_file
            // 
            this.origi_file.HeaderText = "需要备份的文件或文件夹";
            this.origi_file.Name = "origi_file";
            this.origi_file.Width = 350;
            // 
            // TargitDirSelect
            // 
            this.TargitDirSelect.Location = new System.Drawing.Point(7, 29);
            this.TargitDirSelect.Name = "TargitDirSelect";
            this.TargitDirSelect.Size = new System.Drawing.Size(145, 30);
            this.TargitDirSelect.TabIndex = 2;
            this.TargitDirSelect.Text = "目标文件夹选择";
            this.TargitDirSelect.UseVisualStyleBackColor = true;
            this.TargitDirSelect.Click += new System.EventHandler(this.TargitDirSelect_Click);
            // 
            // TargitDirList
            // 
            this.TargitDirList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TargitDirList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.targit_dir});
            this.TargitDirList.Location = new System.Drawing.Point(7, 65);
            this.TargitDirList.Name = "TargitDirList";
            this.TargitDirList.RowTemplate.Height = 23;
            this.TargitDirList.Size = new System.Drawing.Size(430, 125);
            this.TargitDirList.TabIndex = 3;
            // 
            // targit_dir
            // 
            this.targit_dir.HeaderText = "目标文件夹";
            this.targit_dir.Name = "targit_dir";
            this.targit_dir.Width = 350;
            // 
            // SaveConfig
            // 
            this.SaveConfig.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SaveConfig.Location = new System.Drawing.Point(403, 23);
            this.SaveConfig.Name = "SaveConfig";
            this.SaveConfig.Size = new System.Drawing.Size(129, 51);
            this.SaveConfig.TabIndex = 3;
            this.SaveConfig.Text = "参数保存";
            this.SaveConfig.UseVisualStyleBackColor = true;
            this.SaveConfig.Click += new System.EventHandler(this.SaveConfig_Click);
            // 
            // SetConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 565);
            this.Controls.Add(this.SaveConfig);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SetConfig";
            this.Text = "参数设置";
            this.Load += new System.EventHandler(this.SetConfig_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OrigiFileList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargitDirList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton SelectDay;
        private System.Windows.Forms.RadioButton SelectHour;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView OrigiFileList;
        private System.Windows.Forms.DataGridViewTextBoxColumn origi_file;
        private System.Windows.Forms.Button OrigiDirSelect;
        private System.Windows.Forms.Button OrigiFileSelect;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView TargitDirList;
        private System.Windows.Forms.DataGridViewTextBoxColumn targit_dir;
        private System.Windows.Forms.Button TargitDirSelect;
        private System.Windows.Forms.Button SaveConfig;
    }
}