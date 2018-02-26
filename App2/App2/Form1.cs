using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace App2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
            label1.Left -= 5;
            if (label1.Right < 0)
            {
                label1.Left = this.Width;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void stopBotton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mybotton_Click(object sender, EventArgs e)
        {
            FRM_Plan F_Plan = new FRM_Plan(0, 99);
            F_Plan.Show(this);
            for (int i = 0; i < 100; i++)
            {
                F_Plan.Set_pos(i);//设置进度条位置      
                Thread.Sleep(100);//睡眠时间为100    
            }
            F_Plan.Close();//关闭窗体 
            MessageBox.Show("Done", "Finish");
        }
    }
}
