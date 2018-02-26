using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace App2
{
    public partial class FRM_Plan : Form
    {
        Form1 f1 = new Form1();
        public FRM_Plan(int _Minimum, int _Maximum)
        {
            InitializeComponent();
            progressBar1.Maximum = _Maximum;
            progressBar1.Value = progressBar1.Minimum = _Minimum;
        }

        public void Set_pos(int value)
        {
            if (value < progressBar1.Maximum)
            {
                progressBar1.Value = value;//设置进度值      
                label1.Text = (value * 100 / progressBar1.Maximum).ToString() + "%";//显示百分比 
            }
            Application.DoEvents();//重点，必须加上，否则父子窗体都假死
        }

        private void FRM_Plan_Load(object sender, EventArgs e)
        {
            f1.Enabled = false;//设置父窗体不可用 
        }

        private void FRM_Plan_FormClosed(object sender, FormClosedEventArgs e)
        {
            f1.Enabled = true;//回复父窗体为可用  
        } 
    }
}
