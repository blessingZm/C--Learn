using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ForcasetTXTShow
{
    public partial class Form1 : Form
    {
        public string logotxt = "王清龙2018年05月02日开发";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            textBox1.Width = this.Width - (1024 - 984);
            textBox1.Height = this.Height - (600 - 508);
            button3.Left = this.Width - (1024 - 921);
        }
        public void updatetxt()
        {
            textBox1.Text = "更新中.....";

            string f1 = @"\\172.20.24.2\srdb\out\xj\YCWF00.TXT";
            string f2 = @"\\172.20.24.2\srdb\out\xj\YCWF06.TXT";

            DateTime d1 = File.GetLastWriteTime(f1);
            DateTime d2 = File.GetLastWriteTime(f2);
            string ybtxt = "", f = "";
            //if (d1 < d2 && DateTime.Now.Hour > 12)
            if (d1 < d2)
            {
                f = f2;
            }
            else
            {
                f = f1;
            }
            ybtxt = File.ReadAllText(f, Encoding.GetEncoding("GBK")).TrimEnd();
            this.Text = f + "                     " + logotxt;
            textBox1.Text = ybtxt;
            textBox1.Select(0, 0);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口
            p.Start();//启动程序

            //向cmd窗口发送输入信息
            p.StandardInput.WriteLine(@"net use \\172.20.24.2\  /user:yb qxt@220 &exit");

            p.StandardInput.AutoFlush = true;
            p.Close();

           */
            updatetxt();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            updatetxt();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Font = new Font(textBox1.Font.FontFamily, textBox1.Font.Size + 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            textBox1.Font = new Font(textBox1.Font.FontFamily, 11);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Font = new Font(textBox1.Font.FontFamily, textBox1.Font.Size - 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            updatetxt();
        }
    }
}
