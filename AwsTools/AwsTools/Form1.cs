using AwsTools.Archive;
using AwsTools.Backup;
using AwsTools.MonthClimateAssess;
using AwsTools.StCompare;
using System;
using System.Windows.Forms;

namespace AwsTools
{
    public partial class MonthClimateButton : Form
    {
        public String config_path = @".\config";
        public MonthClimateButton()
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

        private void MonthClimateButton_Click(object sender, EventArgs e)
        {
            MonthClimate mc_tool = new MonthClimate();
            mc_tool.Show();
        }

        private void WStatic_button_Click(object sender, EventArgs e)
        {
            WStatic w_tool = new WStatic();
            w_tool.Show();
        }
    }
}
