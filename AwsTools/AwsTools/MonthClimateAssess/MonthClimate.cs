using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace AwsTools.MonthClimateAssess
{
    public partial class MonthClimate : Form
    {
        String xmlFile = @".\Config\ClimateData30.xml";
        bool ConfigIsReset = false;
        public MonthClimate()
        {
            InitializeComponent();
            DateTime now = DateTime.Now;
            DateSelect.MaxDate = now.AddMonths(-1);
        }

        private void MonthClimate_Load(object sender, EventArgs e)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(xmlFile);

            XmlNodeList DataConfig = xmldoc.GetElementsByTagName("HistoryData");
            for (int i = 0; i < DataConfig.Count; i++)
            {
                String[] values = DataConfig[i].Attributes[0].Value.Split(',');
                HistoryDatas.Rows.Add(values);
            }

            XmlNodeList FileConfig = xmldoc.GetElementsByTagName("Db");
            DBfile_text.Text = FileConfig[0].Attributes[0].Value;
        }

        private void MonthClimate_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ConfigIsReset)
            {
                DialogResult dr = MessageBox.Show("参数有修改,但未保存,请保存,取消则不保存并关闭窗口！",
                    "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.OK)
                {
                    e.Cancel = true;
                }
                else
                {
                    e.Cancel = false;
                }
            }
        }

        private void SaveHistoryButton_Click(object sender, EventArgs e)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(xmlFile);
            // 修改参数
            XmlNodeList HistoryNodes = xmldoc.GetElementsByTagName("HistoryDatas");
            XmlNodeList FileNodes = xmldoc.GetElementsByTagName("Dbfile");
            // 首先清除所有参数
            HistoryNodes[0].RemoveAll();
            FileNodes[0].RemoveAll();
            // 重新写入参数
            XmlElement newnode = xmldoc.CreateElement("Db");
            newnode.SetAttribute("File", DBfile_text.Text);
            FileNodes[0].AppendChild(newnode);

            for (int i = 0; i < HistoryDatas.RowCount; i++)
            {
                XmlElement newNode = xmldoc.CreateElement("HistoryData");
                try
                {
                    ArrayList values = new ArrayList();
                    for (int j = 0; j < HistoryDatas.ColumnCount; j++)
                    {
                        values.Add(HistoryDatas.Rows[i].Cells[j].Value);
                    }
                    String value = String.Join(",", values.ToArray());
                    newNode.SetAttribute("Data", value);
                    HistoryNodes[0].AppendChild(newNode);
                }
                catch
                {
                    continue;
                }
            }
            xmldoc.Save(xmlFile);
            MessageBox.Show("历史数据保存成功", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            ConfigIsReset = false;
        }

        private void HistoryDatas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ConfigIsReset = true;
        }

        private void DBfileSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Filter = "db文件|*.db",
                RestoreDirectory = true,
                CheckPathExists = true,
                CheckFileExists = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                DBfile_text.Text = openFileDialog.FileName;
                ConfigIsReset = true;
            }  
        }

        private double[] GetMonthDatas()
        {
            DateTime dt = DateSelect.Value;
            String dtStr = dt.ToString("yyyy-MM");
            int days = DateTime.DaysInMonth(dt.Year, dt.Month);
            double[] resultsData = new double[4];
            SQLiteConnection conn = null;
            try
            {
                string dbPath = String.Format("Data Source={0}", DBfile_text.Text);
                conn = new SQLiteConnection(dbPath);//创建数据库实例，指定文件位置    
                conn.Open();                        //打开数据库，若文件不存在会自动创建    

                string sql = String.Format("select " +
                    "sum(cast(DailyAVETemp as float)) / ({0} * 10) as averageTemp, " +
                    "(sum(cast(PrecipitationAmount08H as float)) + sum(cast(PrecipitationAmount20H as float))) / 10 as sumR, " +
                    "sum(cast(SunshineAmount as float)) / 10 as sumSun, " +
                    "sum(cast(EvapgaugeAmount as float)) / 10 as sumLe " +
                    "from AWSDAY where ObserveTime >= '{1}-01 00:00:00' and ObserveTime <= '{1}-{2} 00:00:00'", 
                    days, dtStr, days.ToString());
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                SQLiteDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    for (int i = 0; i < reader.GetValues().Count; i++)
                    {
                        resultsData[i] = double.Parse(reader.GetValue(i).ToString());
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return resultsData;
        }

        private void CreateResultButtom_Click(object sender, EventArgs e)
        {
            DateTime dt = DateSelect.Value;
            String head = String.Format("{0}年{1}月气候评价:\r\n\r\n", dt.Year, dt.Month);
            double[] meterDatas = GetMonthDatas();
            double aveTemp = Math.Round(meterDatas[0], 1, MidpointRounding.AwayFromZero);
            double Rsum = meterDatas[1];
            double Ssum = meterDatas[2];
            double Lesum = meterDatas[3];
            double[] historyValues = GetHistoryDatas(dt.Month);
            double difTemp = Math.Round(aveTemp - historyValues[0], 1, MidpointRounding.AwayFromZero);
            double difR = Math.Round((Rsum - historyValues[1]) * 100 / historyValues[1], 0, MidpointRounding.AwayFromZero);
            double difSun = Math.Round((Ssum - historyValues[2]) * 100 / historyValues[2], 0, MidpointRounding.AwayFromZero);

            String content1 = String.Format("本月月平均气温为{0}℃，比历年平均气温{1}℃；" +
                "月总降水量为{2}mm，比历年平均值{3}；" +
                "月日照时数为{4}小时，比历年平均值{5}；" +
                "月蒸发总量为{6}mm。\r\n\r\n", aveTemp, GetDifStr(difTemp, true), 
                Rsum, GetDifStr(difR, false), Ssum, GetDifStr(difSun, false), Lesum);
            String content5 = String.Format("本月月平均气温{0},月总降水量{1},月日照时数{2}。",
                GetDifStr(difTemp, true).Substring(0, 2),
                GetDifStr(difR, false).Substring(0, 2),
                GetDifStr(difSun, false).Substring(0, 2));
            ClimateResult.Text = head + content1 + content5;
        }

        private String GetDifStr(double difvalue, bool istemp)
        {
            String difStr;
            String[] bufStr;
            if (istemp)
            {
                bufStr = new String[2] { "偏高", "偏低" };
            }
            else
            {
                bufStr = new String[2] { "偏多百分之", "偏少百分之" };
            }

            if (difvalue > 0)
            {
                difStr = String.Format("{0}{1}", bufStr[0], Math.Abs(difvalue));
            }
            else if (difvalue < 0)
            {
                difStr = String.Format("{0}{1}", bufStr[1], Math.Abs(difvalue));
            }
            else
            {
                difStr = "相同";
            }
            return difStr;
        }

        private double[] GetHistoryDatas(int month)
        {
            double[] values = new double[HistoryDatas.ColumnCount - 1];
            for (int i = 1; i < HistoryDatas.ColumnCount; i++)
            {
                values[i - 1] = double.Parse(HistoryDatas.Rows[month - 1].Cells[i].Value.ToString());
            }
            return values;
        }
    }
}
