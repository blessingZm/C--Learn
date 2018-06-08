using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace AwsTools.Archive
{
    public partial class ArchiveTool : Form
    {
        public ArchiveTool()
        {
            InitializeComponent();
            DateTime NOW = DateTime.Now;
            StartDate.Value = NOW.AddMonths(-1);
            EndDate.Value = NOW.AddMonths(-1);
            StartDate.MaxDate = NOW.AddMonths(-1);
            EndDate.MaxDate = NOW.AddMonths(-1);
        }

        private void StartArchive_Click(object sender, EventArgs e)
        {
            Log_text.Clear();
            String dtForm = StartDate.CustomFormat;
            String startDate = StartDate.Value.ToString(dtForm);
            String endDate = EndDate.Value.ToString(dtForm);
            if (String.Compare(startDate, endDate) > 0)
            {
                MessageBox.Show("开始时间大于结束时间", "错误提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // 生成日期序列
            ArrayList dateList = DateRange(startDate, endDate);
            // 从参数文件取得相关数据
            String xmlFile = @".\Config\ArchiveConfig.xml";
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(xmlFile);

            XmlNodeList basicConfig = xmldoc.GetElementsByTagName("Basic");
            String stId = basicConfig[0].Attributes[0].Value;
            String awsPath = basicConfig[0].Attributes[1].Value;
            String awsnetPath = basicConfig[0].Attributes[2].Value;
            String digitPath = basicConfig[0].Attributes[3].Value;

            if (!Directory.Exists(digitPath))
            {
                Directory.CreateDirectory(digitPath);
            }

            XmlNodeList fileConfig = xmldoc.GetElementsByTagName("Parameter");
            ArrayList fileList = new ArrayList();
            for (int i = 0; i < fileConfig.Count; i++)
            {
                ArrayList bufList = new ArrayList();
                for (int j = 0; j < fileConfig[i].Attributes.Count; j++)
                {
                    bufList.Add(fileConfig[i].Attributes[j].Value);
                }
                fileList.Add(bufList);
            }
            // 开始归档
            foreach (String d in dateList)
            {
                String year = d.Split('-')[0];
                String month = d.Split('-')[1];

                String endPath = Path.Combine(digitPath, String.Format("{0}{1}_{2}", year, month, stId));
                Directory.CreateDirectory(endPath);

                foreach (ArrayList flist in fileList)
                {
                    Log_text.AppendText($"开始归档{year}年{month}月数据......\r\n" +
                        $"正在归档：{flist[1].ToString()}.....\r\n");
                    String state = flist[0].ToString();
                    if (state == "1")
                    {
                        state = "";
                    }
                    else
                    {
                        state = "(删除)";
                    }
                    String endFolder = Path.Combine(endPath, flist[1].ToString() + state);
                    Directory.CreateDirectory(endFolder);
                    String fstring = String.Format(flist[2].ToString(), stId, year + month);

                    String fpath = flist[3].ToString();
                    String origiPath;
                    if (flist[1].ToString().Contains("降水现象"))
                    {
                        fpath = String.Format(fpath, Trans_yearmonth(int.Parse(year), int.Parse(month)));
                        origiPath = Path.Combine(awsnetPath, fpath);
                    }
                    else
                    {
                        origiPath = Path.Combine(awsPath, fpath);
                    }

                    MoveFile mf = new MoveFile();
                    if (state == "")
                    {
                        if (!Directory.Exists(origiPath))
                        {
                            MessageBox.Show(String.Format("不存在文件夹 {0},请检查！", origiPath), "错误",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        foreach (String file in Directory.GetFiles(origiPath))
                        {
                            if (Regex.IsMatch(Path.GetFileName(file), fstring))
                            {
                                mf.Move_File(file, endFolder);
                            }
                        }
                    }
                }
            }
            Log_text.AppendText("\r\n归档完成！\r\n");
        }


        // 变化年月为实际年月往后推一个月
        private String Trans_yearmonth(int y, int m)
        {
            String en_year;
            String en_month;
            if (m == 12)
            {
                en_year = (y + 1).ToString();
                en_month = "01";
            }
            else
            {
                en_year = y.ToString();
                en_month = (m + 1).ToString("00");
            }
            return en_year + en_month;
        }

        // 根据起止日期生成日期序列
        private ArrayList DateRange(string stdt, string endt)
        {
            ArrayList dateList = new ArrayList();
            while (String.Compare(stdt, endt) <= 0)
            {
                dateList.Add(stdt);
                stdt = DateTime.Parse(stdt).AddMonths(1).ToString("yyyy-MM");
            }
            return dateList;
        }

        private void SetConfig_Click(object sender, EventArgs e)
        {
            ArchiveCofigForm config_form = new ArchiveCofigForm();
            config_form.Show();
        }
    }
}