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
            string db_path = @".\";
            string db_name = "w_datas.db";
            string table_name = $"min{wd_num}";
            string result_file = $"{wd_num}分钟风统计结果.xlsx";

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
            // 将原始数据提取存入临时数据库"w_datas.db"
            Log_text.AppendText($"将数据提取写入临时数据库{db_name} ........\r\n");

            SqliteClass new_sq = new SqliteClass(db_path, db_name);
            List<string> columns = new List<string>
            {
                "meter_time", "new_wd", "new_wd_direct", "new_ws",
                "old_wd", "old_wd_direct", "old_ws", "wd_dif"
            };
            List<string> col_datasets = new List<string>
            {
                "char(20) PRIMARY KEY NOT NULL", "char(10)", "char(10)", "char(10)",
                "char(10)", "char(10)", "char(10)", "char(10)"
            };
            new_sq.CreateTable(table_name, columns, col_datasets);
            new_sq.StartTrans();

            for (int i = 0; i < drange.Count; i++)
            {
                string year_month = drange[i];
                string year = year_month.Substring(0, 4);
                string month = year_month.Substring(4, 2);

                string new_file = Path.Combine(bd.NewPath, FileList[0][i]);
                string old_file = Path.Combine(bd.OldPath, FileList[1][i]);

                GetWdatas new_gw = new GetWdatas(new_file, wd_num);
                GetWdatas old_gw = new GetWdatas(old_file, wd_num);
                List<ArrayList> new_datas = new_gw.GetDatas();
                List<ArrayList> old_datas = old_gw.GetDatas();

                for (int j = 0; j < new_datas.Count; j++)
                {
                    ArrayList result = new_datas[j];
                    for (int k = 1; k < old_datas[j].Count; k++)
                        result.Add(old_datas[j][k]);
                    result.Add(Convert.ToInt32(new_datas[j][1]) -
                        Convert.ToInt32(old_datas[j][1]));
                    new_sq.InsertDatas(table_name, columns, result);
                }
                
                Log_text.AppendText($"{year}年{month}月 写入完成......\r\n");
            }
            new_sq.CommitTrans();
            new_sq.CloseDb();

            Log_text.AppendText($"原始数据写入数据库{db_name}完成\r\n");

            Log_text.AppendText($"开始统计并数据结果至：{result_file}\r\n");

            // 创建统计结果的excel文件，并写入表头
            Workbook wb = new Workbook();
            wb.Worksheets.Clear();
            Worksheet ws_conincidence = wb.Worksheets.Add("风向相符率");
            Worksheet ws_fre_new = wb.Worksheets.Add("新址风向频率");
            Worksheet ws_fre_old = wb.Worksheets.Add("旧址风向频率");
            Worksheet ws_fre_dif = wb.Worksheets.Add("风向频率差");

            //相符率 表头， 从第二列开始
            for (int i = 1; i <= bd.Months.Length; i++)
            {
                ws_conincidence.Cells[0, i].Value = bd.Months[i - 1];
            }
            //频率表头, 从第三列开始
            for (int i = 2; i <= bd.WdDirects.Length + 1; i++)
            {
                ws_fre_new.Cells[0, i].Value = bd.WdDirects[i - 2];
                ws_fre_old.Cells[0, i].Value = bd.WdDirects[i - 2];
                ws_fre_dif.Cells[0, i].Value = bd.WdDirects[i - 2];
            }

            StaticResult sr = new StaticResult(db_path, db_name);

            string start_year = "";
            int year_row = 0;

            Log_text.AppendText("开始输出风向相符率......\r\n");
            // 写相符率
            List<List<string>> rates = sr.WdConincideceRate(table_name);
            foreach (List<string> data in rates)
            {
                string year = data[0];
                string month = data[1];
                string rate = data[2];
                if (year != start_year)
                {
                    start_year = year;
                    year_row += 1;
                    ws_conincidence.Cells[year_row, 0].Value = start_year;
                }
                int month_col = Array.IndexOf(bd.Months, month) + 1;
                ws_conincidence.Cells[year_row, month_col].Value = rate;
            }
            Log_text.AppendText("风向相符率 统计完成.....\r\n");

            // 写风向频率
            Log_text.AppendText("开始输出风向频率......\r\n");
            string[] directs = bd.WdDirects;
            for (int i = 0; i < directs.Count(); i++)
            {
                List<List<string>> new_fres = sr.WdFrequency(table_name, "new_wd_direct", directs[i]);
                List<List<string>> old_fres = sr.WdFrequency(table_name, "old_wd_direct", directs[i]);
                for (int j = 0; j < new_fres.Count; j++)
                {
                    if (i == 0)
                    {
                        ws_fre_new.Cells[j + 1, 0].Value = new_fres[j][0];
                        ws_fre_new.Cells[j + 1, 1].Value = new_fres[j][1];

                        ws_fre_old.Cells[j + 1, 0].Value = old_fres[j][0];
                        ws_fre_old.Cells[j + 1, 1].Value = old_fres[j][1];

                        ws_fre_dif.Cells[j + 1, 0].Value = new_fres[j][0];
                        ws_fre_dif.Cells[j + 1, 1].Value = new_fres[j][1];
                    }
                    int new_fre = Convert.ToInt32(new_fres[j][2]);
                    int old_fre = Convert.ToInt32(old_fres[j][2]);
                    int col_num = i + 2;

                    ws_fre_new.Cells[j + 1, col_num].Value = new_fre;                    
                    ws_fre_old.Cells[j + 1, col_num].Value = old_fre;
                    ws_fre_dif.Cells[j + 1, col_num].Value = new_fre - old_fre;
                }
            }
            Log_text.AppendText("风向频率 统计完成......\r\n");
            sr.CloseDb();

            wb.Save($"{wd_num}分钟风统计结果.xlsx");
            Log_text.AppendText($"结果写入 {result_file} 完成!\r\n");

            if (MessageBox.Show("是否删除临时数据库文件？", "删除前确认", 
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Log_text.AppendText($"删除临时数据库文件{db_name}\r\n");
                File.Delete(Path.Combine(db_path, db_name));
                Log_text.AppendText($"临时数据库文件{db_name} 删除完成！\r\n");
            }
               
            //将窗体中的相关参数写入参数文件
            StreamWriter sw = new StreamWriter(@".\Config\StCompara.ini");
            sw.WriteLine($"StartDate={StartDate.Value.ToString("yyyy-MM")}");
            sw.WriteLine($"EndDate={EndDate.Value.ToString("yyyy-MM")}");
            sw.WriteLine($"StId={StId_text.Text}");
            sw.Close();

            Log_text.AppendText("Done!\r\n");
        }
    }
}
