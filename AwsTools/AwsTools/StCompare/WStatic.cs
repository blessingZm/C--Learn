using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aspose.Cells;
using StationCompara;

namespace AwsTools.StCompare
{
    public partial class WStatic : Form
    {
        static BaseDatas bd = new BaseDatas();
        public WStatic()
        {
            InitializeComponent();
            StaticStart_button.Enabled = false;
            StartDate.Value = bd.DateRange[0];
            EndDate.Value = bd.DateRange[1];
            StId_text.Text = bd.StId;
        }

        private void CheckFile_button_Click(object sender, EventArgs e)
        {
            DateList dlist = new DateList(StartDate.Value, EndDate.Value);
            List<string> drange = dlist.GetYM("");

            List<string> new_nofiles = new List<string>();
            List<string> old_nofiles = new List<string>();
            DirectoryInfo new_folder = new DirectoryInfo(bd.NewPath);
            DirectoryInfo old_folder = new DirectoryInfo(bd.OldPath);

            bool is_all = true;
            bool have_file = false;

            foreach (string d in drange)
            {
                have_file = false;
                foreach (FileInfo file in new_folder.GetFiles())
                {
                    if (file.Name.Contains(d) && file.Name.Contains(bd.StId))
                    {
                        have_file = true;
                        break;
                    }
                }
                if (!have_file)
                    new_nofiles.Add(d);
            }

            foreach (string d in drange)
            {
                have_file = false;
                foreach (FileInfo file in old_folder.GetFiles())
                {
                    if (file.Name.Contains(d) && file.Name.Contains(bd.StId))
                    {
                        have_file = true;
                        break;
                    }
                }
                if (!have_file)
                    old_nofiles.Add(d);
            }

            if (new_nofiles.Count > 0)
            {
                is_all = false;
                MessageBox.Show($"请检查文件\n新址缺少{string.Join("、 ", new_nofiles.ToArray())}等的文件",
                    "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StaticStart_button.Enabled = false;
            }

            if (old_nofiles.Count > 0)
            {
                is_all = false;
                MessageBox.Show($"请检查文件\n旧址缺少{string.Join("、 ", new_nofiles.ToArray())}等的文件",
                    "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StaticStart_button.Enabled = false;
            }

            if (is_all)
            {
                MessageBox.Show($"文件齐全，可以开始统计！", "提示", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                StaticStart_button.Enabled = true;

            }
                
        }

        private void StaticStart_button_Click(object sender, EventArgs e)
        {
            Log_text.Text = "";
            int wd_num;
            if (Wind2_radiobutton.Checked)
                wd_num = 2;
            else
                wd_num = 10;

            // 收集统计的文件名.......
            DateList dlist = new DateList(StartDate.Value, EndDate.Value);
            List<string> drange = dlist.GetYM("");

            List<List<string>> FileList = new List<List<string>>();
            List<string> new_files = new List<string>();
            List<string> old_files = new List<string>();
            DirectoryInfo new_folder = new DirectoryInfo(bd.NewPath);
            DirectoryInfo old_folder = new DirectoryInfo(bd.OldPath);

            foreach (string d in drange)
            {
                foreach (FileInfo file in new_folder.GetFiles())
                {
                    if (file.Name.Contains(d) && file.Name.Contains(bd.StId))
                    {
                        new_files.Add(file.Name);
                        break;
                    }
                }
            }
            foreach (string d in drange)
            {
                foreach (FileInfo file in old_folder.GetFiles())
                {
                    if (file.Name.Contains(d) && file.Name.Contains(bd.StId))
                    {
                        old_files.Add(file.Name);
                        break;
                    }
                }
            }
            FileList.Add(new_files);
            FileList.Add(old_files);

            //开始统计.....
            Log_text.AppendText("开始统计......\r\n");
            string start_year = "";
            int year_row = 0;

            Workbook wb = new Workbook();
            wb.Worksheets.Clear();
            Worksheet ws_conincidence = wb.Worksheets.Add("风向相符率");
            Worksheet ws_fre_new = wb.Worksheets.Add("新址风向频率");
            Worksheet ws_fre_old = wb.Worksheets.Add("旧址风向频率");
            Worksheet ws_fre_dif = wb.Worksheets.Add("风向频率差");
            //相符率 表头
            for (int i = 1; i <= bd.Months.Length; i++)
            {
                ws_conincidence.Cells[0, i].Value = bd.Months[i - 1];
            }
            //频率表头
            for (int i = 2; i <= bd.WdDirects.Length + 1; i++)
            {
                ws_fre_new.Cells[0, i].Value = bd.WdDirects[i - 2];
                ws_fre_old.Cells[0, i].Value = bd.WdDirects[i - 2];
                ws_fre_dif.Cells[0, i].Value = bd.WdDirects[i - 2];
            }

            for (int i = 0; i < drange.Count; i++)
            {
                string year_month = drange[i];
                string year = year_month.Substring(0, 4);
                // 判断写入相符率的年份，即应该写入哪一行
                if (year != start_year)
                {
                    year_row += 1;
                    start_year = year;
                    ws_conincidence.Cells[year_row, 0].Value = year;
                }
                string month = year_month.Substring(4, 2);
                Log_text.AppendText($"正在统计{year}年{month}月的数据......\r\n");

                string new_file = Path.Combine(bd.NewPath, FileList[0][i]);
                string old_file = Path.Combine(bd.OldPath, FileList[1][i]);

                GetWdatas new_gw = new GetWdatas(new_file, wd_num);
                GetWdatas old_gw = new GetWdatas(old_file, wd_num);
                List<ArrayList> new_datas = new_gw.GetDatas();
                List<ArrayList> old_datas = old_gw.GetDatas();

                StaticResult sr = new StaticResult(new_datas, old_datas);
                //输出相符率
                int month_col = Array.IndexOf(bd.Months, month);
                ws_conincidence.Cells[year_row, month_col + 1].Value = sr.WdConincideceRate();
                //输出风向频率
                Dictionary<string, double> new_fre = sr.WdFrequency(new_datas);
                Dictionary<string, double> old_fre = sr.WdFrequency(old_datas);
                Dictionary<string, double> dif_fre = sr.WdFrequencyDif();

                ws_fre_new.Cells[i + 1, 0].Value = year;
                ws_fre_new.Cells[i + 1, 1].Value = month;
                ws_fre_old.Cells[i + 1, 0].Value = year;
                ws_fre_old.Cells[i + 1, 1].Value = month;
                ws_fre_dif.Cells[i + 1, 0].Value = year;
                ws_fre_dif.Cells[i + 1, 1].Value = month;

                foreach (string direct in bd.WdDirects)
                {
                    int wd_col = Array.IndexOf(bd.WdDirects, direct);
                    ws_fre_new.Cells[i + 1, wd_col + 2].Value = new_fre[$"{direct}"];
                    ws_fre_old.Cells[i + 1, wd_col + 2].Value = old_fre[$"{direct}"];
                    ws_fre_dif.Cells[i + 1, wd_col + 2].Value = dif_fre[$"{direct}"];
                }
                Log_text.AppendText($"{year}年{month}月 统计完成......\r\n");
            }
            wb.Save($"{wd_num}分钟风统计结果.xlsx");
            Log_text.AppendText($"结果写入 {wd_num}分钟风统计结果.xlsx 完成!\r\n");

            //将窗体中的相关参数写入参数文件
            StreamWriter sw = new StreamWriter(@".\Config\StCompara.ini");
            sw.WriteLine($"StartDate={StartDate.Value.ToString("yyyy-MM")}");
            sw.WriteLine($"EndDate={EndDate.Value.ToString("yyyy-MM")}");
            sw.WriteLine($"StId={StId_text.Text}");
            sw.Close();
        }
    }
}
