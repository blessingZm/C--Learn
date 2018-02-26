namespace AwsTools.Backup
{
    partial class BackupTool
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
            this.OrigiFileList = new System.Windows.Forms.DataGridView();
            this.origi_file = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.OrigiFileSelect = new System.Windows.Forms.Button();
            this.TargitDirSelect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TargitDirList = new System.Windows.Forms.DataGridView();
            this.targit_dir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartBackup = new System.Windows.Forms.Button();
            this.BackupConfigSave = new System.Windows.Forms.Button();
            this.OrigiDirSelect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.OrigiFileList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargitDirList)).BeginInit();
            this.SuspendLayout();
            // 
            // OrigiFileList
            // 
            this.OrigiFileList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrigiFileList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.origi_file});
            this.OrigiFileList.Location = new System.Drawing.Point(16, 65);
            this.OrigiFileList.Name = "OrigiFileList";
            this.OrigiFileList.RowTemplate.Height = 23;
            this.OrigiFileList.Size = new System.Drawing.Size(393, 145);
            this.OrigiFileList.TabIndex = 0;
            // 
            // origi_file
            // 
            this.origi_file.HeaderText = "需要备份的文件或文件夹";
            this.origi_file.Name = "origi_file";
            this.origi_file.Width = 350;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "源文件或文件夹设置";
            // 
            // OrigiFileSelect
            // 
            this.OrigiFileSelect.Location = new System.Drawing.Point(16, 36);
            this.OrigiFileSelect.Name = "OrigiFileSelect";
            this.OrigiFileSelect.Size = new System.Drawing.Size(105, 23);
            this.OrigiFileSelect.TabIndex = 2;
            this.OrigiFileSelect.Text = "选择源文件";
            this.OrigiFileSelect.UseVisualStyleBackColor = true;
            this.OrigiFileSelect.Click += new System.EventHandler(this.OrigiFileSelect_Click);
            // 
            // TargitDirSelect
            // 
            this.TargitDirSelect.Location = new System.Drawing.Point(16, 251);
            this.TargitDirSelect.Name = "TargitDirSelect";
            this.TargitDirSelect.Size = new System.Drawing.Size(145, 23);
            this.TargitDirSelect.TabIndex = 4;
            this.TargitDirSelect.Text = "目标文件夹选择";
            this.TargitDirSelect.UseVisualStyleBackColor = true;
            this.TargitDirSelect.Click += new System.EventHandler(this.TargitDirSelect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "目标文件夹设置";
            // 
            // TargitDirList
            // 
            this.TargitDirList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TargitDirList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.targit_dir});
            this.TargitDirList.Location = new System.Drawing.Point(16, 280);
            this.TargitDirList.Name = "TargitDirList";
            this.TargitDirList.RowTemplate.Height = 23;
            this.TargitDirList.Size = new System.Drawing.Size(393, 113);
            this.TargitDirList.TabIndex = 5;
            // 
            // targit_dir
            // 
            this.targit_dir.HeaderText = "目标文件夹";
            this.targit_dir.Name = "targit_dir";
            this.targit_dir.Width = 350;
            // 
            // StartBackup
            // 
            this.StartBackup.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StartBackup.Location = new System.Drawing.Point(310, 419);
            this.StartBackup.Name = "StartBackup";
            this.StartBackup.Size = new System.Drawing.Size(99, 44);
            this.StartBackup.TabIndex = 6;
            this.StartBackup.Text = "备份";
            this.StartBackup.UseVisualStyleBackColor = true;
            this.StartBackup.Click += new System.EventHandler(this.StartBackup_Click);
            // 
            // BackupConfigSave
            // 
            this.BackupConfigSave.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BackupConfigSave.Location = new System.Drawing.Point(16, 419);
            this.BackupConfigSave.Name = "BackupConfigSave";
            this.BackupConfigSave.Size = new System.Drawing.Size(116, 44);
            this.BackupConfigSave.TabIndex = 7;
            this.BackupConfigSave.Text = "参数保存";
            this.BackupConfigSave.UseVisualStyleBackColor = true;
            this.BackupConfigSave.Click += new System.EventHandler(this.BackupConfigSave_Click);
            // 
            // OrigiDirSelect
            // 
            this.OrigiDirSelect.Location = new System.Drawing.Point(169, 36);
            this.OrigiDirSelect.Name = "OrigiDirSelect";
            this.OrigiDirSelect.Size = new System.Drawing.Size(137, 23);
            this.OrigiDirSelect.TabIndex = 8;
            this.OrigiDirSelect.Text = "选择源文件夹";
            this.OrigiDirSelect.UseVisualStyleBackColor = true;
            this.OrigiDirSelect.Click += new System.EventHandler(this.OrigiDirSelect_Click);
            // 
            // BackupTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 486);
            this.Controls.Add(this.OrigiDirSelect);
            this.Controls.Add(this.BackupConfigSave);
            this.Controls.Add(this.StartBackup);
            this.Controls.Add(this.TargitDirList);
            this.Controls.Add(this.TargitDirSelect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OrigiFileSelect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OrigiFileList);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BackupTool";
            this.Text = "数据备份";
            this.Load += new System.EventHandler(this.BackupTool_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OrigiFileList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargitDirList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView OrigiFileList;
        private System.Windows.Forms.DataGridViewTextBoxColumn origi_file;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OrigiFileSelect;
        private System.Windows.Forms.Button TargitDirSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView TargitDirList;
        private System.Windows.Forms.Button StartBackup;
        private System.Windows.Forms.Button BackupConfigSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn targit_dir;
        private System.Windows.Forms.Button OrigiDirSelect;
    }
}