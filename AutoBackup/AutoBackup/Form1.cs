using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace AutoBackup
{
    public partial class Form1 : Form
    {
        String xmlFile = @".\Config\BackupConfig.xml";

        public Form1()
        {
            InitializeComponent();
        }

        private void SetConfig_Click(object sender, EventArgs e)
        {
            SetConfig sf = new SetConfig();
            sf.Show();
        }

        //手动备份
        private void Button1_Click(object sender, EventArgs e)
        {
            MoveFile mf = new MoveFile();
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(xmlFile);

            XmlNodeList origiConfig = xmldoc.GetElementsByTagName("Origi");
            XmlNodeList targitConfig = xmldoc.GetElementsByTagName("Targit");

            PBar pb = new PBar(0, origiConfig.Count * targitConfig.Count);
            pb.Show(this);
            int pbnum = 0;
            for (int i = 0; i < targitConfig.Count; i++)
            {
                for (int j = 0; j < origiConfig.Count; j++)
                {
                    String oriFile = origiConfig[j].Attributes[0].Value;
                    String tarDir = targitConfig[i].Attributes[0].Value;
                    pb.Set_pos(pbnum, String.Format("备份:{0} ----至:{1}...", oriFile, tarDir));
                    mf.Move_File(oriFile, tarDir);
                    pbnum++;
                }
            }
            pb.Close();
            MessageBox.Show("备份完成！", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //自动备份
        private void Button2_Click(object sender, EventArgs e)
        {
            Thread taskBackup = new Thread(new ThreadStart(TaskBackup));
            taskBackup.Start();
            button2.Text = "自动备份已启动";
            //button2.Text = DateTime.Now.ToLongTimeString().ToString();
            button2.Enabled = false;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认退出程序？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                // 关闭所有的线程
                this.Dispose();
                Environment.Exit(0);
            }
        }

        private void 参数设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetConfig sf = new SetConfig();
            sf.Show();
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.notifyIcon1.Visible = false;
            this.WindowState = FormWindowState.Normal;
            this.Visible = true;
            this.ShowInTaskbar = true;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;//不显示在任务栏
                this.notifyIcon1.Visible = true;//显示托盘图标
            }
        }

        private void TaskBackup()
        {
            MoveFile mf = new MoveFile();
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(xmlFile);

            XmlNodeList rateConfig = xmldoc.GetElementsByTagName("Rate");
            XmlNodeList origiConfig = xmldoc.GetElementsByTagName("Origi");
            XmlNodeList targitConfig = xmldoc.GetElementsByTagName("Targit");

            String rateStr = rateConfig[0].Attributes[0].Value;           
            String reStr, nowtime;
            if (rateStr == "Hour")
            {
                reStr = @"\d\d:05:30";
            }
            else
            {
                reStr = "20:10:30";
            }
            while (true)
            {
                nowtime = DateTime.Now.ToLongTimeString().ToString();
                if (Regex.IsMatch(nowtime, reStr))
                {
                    for (int i = 0; i < targitConfig.Count; i++)
                    {
                        for (int j = 0; j < origiConfig.Count; j++)
                        {
                            String oriFile = origiConfig[j].Attributes[0].Value;
                            String tarDir = targitConfig[i].Attributes[0].Value;
                            mf.Move_File(oriFile, tarDir);
                        }
                    }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否退出程序？", "退出程序",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                // 关闭所有的线程
                this.Dispose();
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
