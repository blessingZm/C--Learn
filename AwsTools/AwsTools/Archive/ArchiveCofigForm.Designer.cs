namespace AwsTools.Archive
{
    partial class ArchiveCofigForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.STID = new System.Windows.Forms.TextBox();
            this.ARCHIVELISTS = new System.Windows.Forms.DataGridView();
            this.AWSPATH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AWSNETPATH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DIGITPATH = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.AWSPATHSELECT = new System.Windows.Forms.Button();
            this.AWSNETPATHSELECT = new System.Windows.Forms.Button();
            this.DIGITPATHSELECT = new System.Windows.Forms.Button();
            this.save_config = new System.Windows.Forms.Button();
            this.file_state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.file_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filename_match_mode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.file_dir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ARCHIVELISTS)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(37, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "台站号：";
            // 
            // STID
            // 
            this.STID.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.STID.Location = new System.Drawing.Point(185, 20);
            this.STID.Name = "STID";
            this.STID.Size = new System.Drawing.Size(135, 29);
            this.STID.TabIndex = 1;
            // 
            // ARCHIVELISTS
            // 
            this.ARCHIVELISTS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ARCHIVELISTS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.file_state,
            this.file_type,
            this.filename_match_mode,
            this.file_dir});
            this.ARCHIVELISTS.Location = new System.Drawing.Point(41, 253);
            this.ARCHIVELISTS.Name = "ARCHIVELISTS";
            this.ARCHIVELISTS.RowTemplate.Height = 23;
            this.ARCHIVELISTS.Size = new System.Drawing.Size(739, 258);
            this.ARCHIVELISTS.TabIndex = 9;
            // 
            // AWSPATH
            // 
            this.AWSPATH.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AWSPATH.Location = new System.Drawing.Point(185, 73);
            this.AWSPATH.Name = "AWSPATH";
            this.AWSPATH.Size = new System.Drawing.Size(428, 29);
            this.AWSPATH.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(37, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "AWS目录：";
            // 
            // AWSNETPATH
            // 
            this.AWSNETPATH.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AWSNETPATH.Location = new System.Drawing.Point(185, 130);
            this.AWSNETPATH.Name = "AWSNETPATH";
            this.AWSNETPATH.Size = new System.Drawing.Size(428, 29);
            this.AWSNETPATH.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(37, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 19);
            this.label3.TabIndex = 12;
            this.label3.Text = "Awsnet目录：";
            // 
            // DIGITPATH
            // 
            this.DIGITPATH.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DIGITPATH.Location = new System.Drawing.Point(185, 184);
            this.DIGITPATH.Name = "DIGITPATH";
            this.DIGITPATH.Size = new System.Drawing.Size(428, 29);
            this.DIGITPATH.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(37, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 19);
            this.label4.TabIndex = 14;
            this.label4.Text = "归档目标目录：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(37, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 19);
            this.label5.TabIndex = 16;
            this.label5.Text = "归档文件清单：";
            // 
            // AWSPATHSELECT
            // 
            this.AWSPATHSELECT.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AWSPATHSELECT.Location = new System.Drawing.Point(619, 79);
            this.AWSPATHSELECT.Name = "AWSPATHSELECT";
            this.AWSPATHSELECT.Size = new System.Drawing.Size(58, 23);
            this.AWSPATHSELECT.TabIndex = 17;
            this.AWSPATHSELECT.Text = "··";
            this.AWSPATHSELECT.UseVisualStyleBackColor = true;
            this.AWSPATHSELECT.Click += new System.EventHandler(this.AWSPATHSELECT_Click);
            // 
            // AWSNETPATHSELECT
            // 
            this.AWSNETPATHSELECT.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AWSNETPATHSELECT.Location = new System.Drawing.Point(619, 129);
            this.AWSNETPATHSELECT.Name = "AWSNETPATHSELECT";
            this.AWSNETPATHSELECT.Size = new System.Drawing.Size(58, 23);
            this.AWSNETPATHSELECT.TabIndex = 18;
            this.AWSNETPATHSELECT.Text = "··";
            this.AWSNETPATHSELECT.UseVisualStyleBackColor = true;
            this.AWSNETPATHSELECT.Click += new System.EventHandler(this.AWSNETPATHSELECT_Click);
            // 
            // DIGITPATHSELECT
            // 
            this.DIGITPATHSELECT.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DIGITPATHSELECT.Location = new System.Drawing.Point(619, 183);
            this.DIGITPATHSELECT.Name = "DIGITPATHSELECT";
            this.DIGITPATHSELECT.Size = new System.Drawing.Size(58, 23);
            this.DIGITPATHSELECT.TabIndex = 19;
            this.DIGITPATHSELECT.Text = "··";
            this.DIGITPATHSELECT.UseVisualStyleBackColor = true;
            this.DIGITPATHSELECT.Click += new System.EventHandler(this.DIGITPATHSELECT_Click);
            // 
            // save_config
            // 
            this.save_config.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.save_config.Location = new System.Drawing.Point(719, 20);
            this.save_config.Name = "save_config";
            this.save_config.Size = new System.Drawing.Size(108, 29);
            this.save_config.TabIndex = 20;
            this.save_config.Text = "参数保存";
            this.save_config.UseVisualStyleBackColor = true;
            this.save_config.Click += new System.EventHandler(this.Save_config_Click);
            // 
            // file_state
            // 
            this.file_state.HeaderText = "文件状态";
            this.file_state.MaxInputLength = 1;
            this.file_state.Name = "file_state";
            this.file_state.ToolTipText = "只能为0或1；1代表有，0代表无；";
            this.file_state.Width = 90;
            // 
            // file_type
            // 
            this.file_type.HeaderText = "文件类型";
            this.file_type.Name = "file_type";
            this.file_type.Width = 200;
            // 
            // filename_match_mode
            // 
            this.filename_match_mode.HeaderText = "文件匹配模式";
            this.filename_match_mode.Name = "filename_match_mode";
            this.filename_match_mode.Width = 200;
            // 
            // file_dir
            // 
            this.file_dir.HeaderText = "文件路径";
            this.file_dir.Name = "file_dir";
            this.file_dir.Width = 200;
            // 
            // ArchiveCofigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 544);
            this.Controls.Add(this.save_config);
            this.Controls.Add(this.DIGITPATHSELECT);
            this.Controls.Add(this.AWSNETPATHSELECT);
            this.Controls.Add(this.AWSPATHSELECT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DIGITPATH);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.AWSNETPATH);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AWSPATH);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ARCHIVELISTS);
            this.Controls.Add(this.STID);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ArchiveCofigForm";
            this.Text = "归档参数设置";
            this.Load += new System.EventHandler(this.ArchiveCofigForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ARCHIVELISTS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox STID;
        private System.Windows.Forms.DataGridView ARCHIVELISTS;
        private System.Windows.Forms.TextBox AWSPATH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox AWSNETPATH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DIGITPATH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button AWSPATHSELECT;
        private System.Windows.Forms.Button AWSNETPATHSELECT;
        private System.Windows.Forms.Button DIGITPATHSELECT;
        private System.Windows.Forms.Button save_config;
        private System.Windows.Forms.DataGridViewTextBoxColumn file_state;
        private System.Windows.Forms.DataGridViewTextBoxColumn file_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn filename_match_mode;
        private System.Windows.Forms.DataGridViewTextBoxColumn file_dir;
    }
}