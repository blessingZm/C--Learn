namespace AwsTools
{
    partial class MonthClimateButton
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonthClimateButton));
            this.archive_button = new System.Windows.Forms.Button();
            this.backup_button = new System.Windows.Forms.Button();
            this.MonthCliate_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // archive_button
            // 
            this.archive_button.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.archive_button.Location = new System.Drawing.Point(32, 12);
            this.archive_button.Name = "archive_button";
            this.archive_button.Size = new System.Drawing.Size(118, 29);
            this.archive_button.TabIndex = 0;
            this.archive_button.Text = "数据归档";
            this.archive_button.UseVisualStyleBackColor = true;
            this.archive_button.Click += new System.EventHandler(this.Archive_button_Click);
            // 
            // backup_button
            // 
            this.backup_button.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.backup_button.Location = new System.Drawing.Point(177, 12);
            this.backup_button.Name = "backup_button";
            this.backup_button.Size = new System.Drawing.Size(118, 29);
            this.backup_button.TabIndex = 1;
            this.backup_button.Text = "数据备份";
            this.backup_button.UseVisualStyleBackColor = true;
            this.backup_button.Click += new System.EventHandler(this.Backup_button_Click);
            // 
            // MonthCliate_button
            // 
            this.MonthCliate_button.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MonthCliate_button.Location = new System.Drawing.Point(324, 12);
            this.MonthCliate_button.Name = "MonthCliate_button";
            this.MonthCliate_button.Size = new System.Drawing.Size(128, 29);
            this.MonthCliate_button.TabIndex = 2;
            this.MonthCliate_button.Text = "月气候评价";
            this.MonthCliate_button.UseVisualStyleBackColor = true;
            this.MonthCliate_button.Click += new System.EventHandler(this.MonthClimateButton_Click);
            // 
            // MonthClimateButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 356);
            this.Controls.Add(this.MonthCliate_button);
            this.Controls.Add(this.backup_button);
            this.Controls.Add(this.archive_button);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MonthClimateButton";
            this.Text = "ZM 自动站辅助工具";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button archive_button;
        private System.Windows.Forms.Button backup_button;
        private System.Windows.Forms.Button MonthCliate_button;
    }
}

