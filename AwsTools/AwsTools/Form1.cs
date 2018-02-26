using AwsTools.Archive;
using AwsTools.Backup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AwsTools
{
    public partial class Form1 : Form
    {
        public String config_path = @".\config";
        public Form1()
        {
            InitializeComponent();
        }

        private void Archive_button_Click(object sender, EventArgs e)
        {
            ArchiveTool archive_tool = new ArchiveTool();
            archive_tool.Show();
        }

        private void Backup_button_Click(object sender, EventArgs e)
        {
            BackupTool backup_tool = new BackupTool();
            backup_tool.Show();
        }
    }
}
