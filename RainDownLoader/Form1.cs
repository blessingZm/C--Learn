using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Aspose.Cells;

namespace RainDownLoader
{
    public struct station
    {
        public string STATIONNUM;
        public string STATIONNAME;
        public string CITY;
        public string COUNTY;
        public string LATITUDE;
        public string LONGITUDE;
        public string PROVINCE;
    }
    public struct metadata
    {
        public int DateTimeIndex;
        public decimal PRE_1H;
        public decimal PRE_10M;
    }

    public struct station_datas
    {
        public int StationIndex;
        public decimal PRE_COUNT;
        public List<metadata> Datas;
    }
    public partial class Form1 : Form
    {
        static public decimal defaultUnData = 9999;

        List<station> Stations = new List<station>();
        List<station> Stations_REG = new List<station>();
        List<DateTime> Datetimes = new List<DateTime>();
        List<station_datas> Datas = new List<station_datas>();
        List<station_datas> Datas_REG = new List<station_datas>();
        public decimal UnData = defaultUnData;
        public string outputtype = "txt";
        public static TimeSpan TSlimit = new TimeSpan(14, 0, 0, 0, 0);
        public DateTime datetime_start = DateTime.Now, datetime_end = DateTime.Now;
        public TimeSpan ts;
        public TimeSpan ts1;
        public TimeSpan ts2;

        public static string UrlEncode(string str)
        {
            StringBuilder sb = new StringBuilder();
            byte[] byStr = System.Text.Encoding.UTF8.GetBytes(str); //默认是System.Text.Encoding.Default.GetBytes(str)
            for (int i = 0; i < byStr.Length; i++)
            {
                sb.Append(@"%" + Convert.ToString(byStr[i], 16));
            }

            return (sb.ToString());
        }

        static public string url = "http://10.104.235.2/hbzd/hbase";
        static public string cimissurl = "http://10.104.235.5/hbzd/singleStationQuery?interfaceName=getSurfEleByTimeRangeAndStaID&staIds={0}&timeRange=[{1},{2}]&orderBy=OBSERVTIMES:asc&timeType=Hour&elements=OBSERVTIMES,PRE_1H";
        public void loadStations(string filePath)
        {

            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath);
                string aline;
                while ((aline = sr.ReadLine()) != null)
                {
                    string[] ss = aline.Split(new string[] { ",", ";", "|", "、" }, StringSplitOptions.RemoveEmptyEntries);
                    if (ss.Length > 1)
                        dataGridView1.Rows.Add(new string[] { ss[0], ss[1] });
                }
                sr.Close();
            }

        }
        public void saveStations(string filePath)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);
            int n = 0;
            if (dataGridView1.ReadOnly)
                n = dataGridView1.Rows.Count;
            else
                n = dataGridView1.Rows.Count - 1;
            if (n > 0)
            {
                StreamWriter sw = new StreamWriter(filePath);
                string aline = "";
                for (int i = 0; i < n; i++)
                {
                    aline = (string)dataGridView1.Rows[i].Cells[0].Value + "," + (string)dataGridView1.Rows[i].Cells[1].Value;
                    sw.WriteLine(aline);
                }
                sw.Close();
            }
        }
        public bool check_REG(string STATIONNUM)
        {
            STATIONNUM = STATIONNUM.Trim();
            int it;
            if (int.TryParse(STATIONNUM, out it))
                return false;
            else
                return true;
        }
        public bool check_REG(station station1)
        {
            return check_REG(station1.STATIONNUM);
        }
        public void addlog(string log)
        {
            log = DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分ss秒") + log + @"";
            textBox2.Text = log + textBox2.Text;
            File.AppendAllText("log.txt", log);
        }
        public bool openfile(string file)
        {
            try
            {

                if (MessageBox.Show(this, "已经完成导出，是否直接打开？", "询问", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(file); //打开此文件。

                }
                return true;
            }
            catch (Exception e)
            {
                addlog("文件正被占用，无法保存");
                MessageBox.Show(this, "文件正被占用，无法保存", "错误", MessageBoxButtons.OK);
                return false;
            }
            finally
            {

            }
        }

        public bool savewb(Workbook wb,string path)
        {
            try
            {
                wb.Save(path);
                return true;
            }
            catch (Exception ex)
            {
                addlog("文件正被占用，无法保存");
                if (MessageBox.Show(this, "文件正被占用，无法保存！是否重试？", "询问", MessageBoxButtons.RetryCancel) == DialogResult.Retry)
                    return savewb(wb, path);
                else
                    return false;
            }

        }

        /// <summary>
        /// 导出成通用excel数据表
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool outputexcel(string path)
        {
            #region 导出通用Excel数据表
            try
            {
                Workbook wb = new Workbook();
                wb.Worksheets.Clear();
                Style defaultstyle = new Style();
                defaultstyle.HorizontalAlignment = TextAlignmentType.Center;

                Worksheet mainworksheet = wb.Worksheets.Add("各站逐时数据统计");
                Cells cs0 = mainworksheet.Cells;
                cs0[0, 1].PutValue("各站逐时数据统计    时间：" + datetime_start.ToString("yyyy年MM月dd日HH时") + "到" + datetime_end.ToString("yyyy年MM月dd日HH时"));
                cs0[0, 9].PutValue("缺测标识" + UnData.ToString());

                cs0[1, 0].PutValue("站名");
                cs0[2, 0].PutValue("站号");
                cs0[3, 0].PutValue("合计值");
                cs0[1, 0].SetStyle(defaultstyle);
                cs0[2, 0].SetStyle(defaultstyle);
                cs0[3, 0].SetStyle(defaultstyle);
                cs0[4, 0].SetStyle(defaultstyle);
                cs0.SetColumnWidth(0, 21);

                Worksheet stationsinfosheet = wb.Worksheets.Add("各站站点信息");
                Cells cs1 = stationsinfosheet.Cells;
                cs1[0, 3].PutValue("各站站点信息");
                cs1[1, 0].PutValue("站名");
                cs1[1, 1].PutValue("站号");
                cs1[1, 2].PutValue("地市");
                cs1[1, 3].PutValue("县（市、区）");
                cs1[1, 4].PutValue("纬度");
                cs1[1, 5].PutValue("经度");

                for (int i = 0; i < Stations.Count; i++)
                {
                    cs0[1, i + 1].PutValue(Stations[i].STATIONNAME);
                    cs0[2, i + 1].PutValue(Stations[i].STATIONNUM);
                    cs0[1, i + 1].SetStyle(defaultstyle);
                    cs0[2, i + 1].SetStyle(defaultstyle);


                    cs1[i + 2, 0].PutValue(Stations_REG[i].STATIONNAME);
                    cs1[i + 2, 1].PutValue(Stations_REG[i].STATIONNUM);
                    cs1[i + 2, 2].PutValue(Stations_REG[i].CITY);
                    cs1[i + 2, 3].PutValue(Stations_REG[i].COUNTY);
                    cs1[i + 2, 4].PutValue(Stations_REG[i].LATITUDE);
                    cs1[i + 2, 5].PutValue(Stations_REG[i].LONGITUDE);


                    TimeSpan Ts = (new TimeSpan(0));
                    decimal daydata = 0;
                    for (int j = 0; j < Datas[i].Datas.Count; j++)
                    {
                        DateTime dt = Datetimes[Datas[i].Datas[j].DateTimeIndex];
                        cs0[4 + j, 0].PutValue(checkBox1.Checked ? dt.ToString("yyyy年MM月dd日 HH时mm分") : dt.ToString("yyyy年MM月dd日 HH时"));
                        cs0[4 + j, 0].SetStyle(defaultstyle);
                        cs0[4 + j, i + 1].PutValue(Datas[i].Datas[j].PRE_10M);
                        cs0[4 + j, i + 1].SetStyle(defaultstyle);
                        if (Datas[i].Datas[j].PRE_10M != UnData)
                            daydata += Datas[i].Datas[j].PRE_10M;

                        Ts = Ts.Add(ts);
                    }
                    cs0[3, i + 1].SetStyle(defaultstyle);
                    cs0[3, i + 1].PutValue(daydata);
                }


                for (int i = 0; i < Stations_REG.Count; i++)
                {
                    cs0[1, i + 1 + Stations.Count].PutValue(Stations_REG[i].STATIONNAME);
                    cs0[2, i + 1 + Stations.Count].PutValue(Stations_REG[i].STATIONNUM);
                    cs0[1, i + 1 + Stations.Count].SetStyle(defaultstyle);
                    cs0[2, i + 1 + Stations.Count].SetStyle(defaultstyle);

                    cs1[i + 2 + Stations.Count, 0].PutValue(Stations_REG[i].STATIONNAME);
                    cs1[i + 2 + Stations.Count, 1].PutValue(Stations_REG[i].STATIONNUM);
                    cs1[i + 2 + Stations.Count, 2].PutValue(Stations_REG[i].CITY);
                    cs1[i + 2 + Stations.Count, 3].PutValue(Stations_REG[i].COUNTY);
                    cs1[i + 2 + Stations.Count, 4].PutValue(Stations_REG[i].LATITUDE);
                    cs1[i + 2 + Stations.Count, 5].PutValue(Stations_REG[i].LONGITUDE);

                    TimeSpan Ts = (new TimeSpan(0));
                    decimal daydata = 0;
                    for (int j = 0; j < Datas_REG[i].Datas.Count; j++)
                    {
                        DateTime dt = Datetimes[Datas_REG[i].Datas[j].DateTimeIndex];
                        cs0[4 + j, 0].PutValue(checkBox1.Checked ? dt.ToString("yyyy年MM月dd日 HH时mm分") : dt.ToString("yyyy年MM月dd日 HH时"));
                        cs0[4 + j, 0].SetStyle(defaultstyle);
                        cs0[4 + j, i + 1 + Stations.Count].PutValue(Datas_REG[i].Datas[j].PRE_10M);
                        cs0[4 + j, i + 1 + Stations.Count].SetStyle(defaultstyle);
                        if (Datas_REG[i].Datas[j].PRE_10M != UnData)
                            daydata += Datas_REG[i].Datas[j].PRE_10M;

                        Ts = Ts.Add(ts);
                    }
                    cs0[3, i + 1 + Stations.Count].SetStyle(defaultstyle);
                    cs0[3, i + 1 + Stations.Count].PutValue(daydata);

                }
                
                return savewb(wb, path) && openfile(path);
            }
            catch (Exception edx)
            {
                addlog("导出出错");
                MessageBox.Show(this, "导出出错", "错误", MessageBoxButtons.OK);
                return false;
            }
            #endregion
        }
        /// <summary>
        /// 导出成兴山水电服务模版的excel数据表
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>       
        public bool outputxsexcel(string path)
        {
            #region 导出兴山订制模板的Excel数据表
            try
            {
                Workbook wb = new Workbook();
                wb.Worksheets.Clear();
                Worksheet mainworksheet = wb.Worksheets.Add("统计汇总表");
                Cells cs0 = mainworksheet.Cells;
                cs0[0, 3].PutValue("各站逐日数据汇总");
                cs0[1, 0].PutValue("站名");
                cs0[1, 1].PutValue("站号");
                List<Worksheet> Stations_sheet = new List<Worksheet>();
                decimal ds = 59 + 60 * 59 + 60 * 60 * 3;
                DateTime dt1 = datetime_start.AddSeconds((double)ds);
                TimeSpan Ts0 = new TimeSpan(dt1.Hour, dt1.Minute, dt1.Second);
                for (int i = 0; i < Stations.Count; i++)
                {
                    cs0[i + 2, 0].PutValue(Stations[i].STATIONNAME);
                    cs0[i + 2, 1].PutValue(Stations[i].STATIONNUM);

                    Worksheet ws = wb.Worksheets.Add(Stations[i].STATIONNAME);
                    Stations_sheet.Add(ws);
                    ws.Cells[0, 3].PutValue(Stations[i].STATIONNUM);
                    ws.Cells[0, 4].PutValue(Stations[i].STATIONNAME);
                    ws.Cells.SetColumnWidth(0, 12);
                    ws.Cells[1, 0].PutValue("日期");
                    ws.Cells[1, 25].PutValue("当日合计");
                    TimeSpan Ts = (new TimeSpan(0)) + Ts0;
                    int lastday = 0;
                    decimal daydata = 0;
                    for (int j = 0; j < Datas[i].Datas.Count; j++)
                    {
                        DateTime dt = Datetimes[Datas[i].Datas[j].DateTimeIndex];
                        if (Ts.Days != lastday)
                            daydata = 0;
                        cs0[1, 2 + Ts.Days].PutValue(dt.AddSeconds((double)ds).ToString("yyyy-MM-dd"));
                        cs0.SetColumnWidth(2 + Ts.Days, 12);
                        if (Datas[i].Datas[j].PRE_1H != UnData)
                            daydata += Datas[i].Datas[j].PRE_1H;
                        cs0[i + 2, 2 + Ts.Days].PutValue(daydata);
                        ws.Cells[2 + Ts.Days, 25].PutValue(daydata);
                        ws.Cells[1, dt.AddSeconds(Convert.ToDouble(ds)).Hour + 1].PutValue(dt.Hour.ToString());
                        ws.Cells[2 + Ts.Days, 0].PutValue(dt.ToString("yyyy-MM-dd"));
                        ws.Cells[2 + Ts.Days, dt.AddSeconds(Convert.ToDouble(ds)).Hour + 1].PutValue(Datas[i].Datas[j].PRE_1H);

                        lastday = Ts.Days;
                        Ts = Ts.Add(ts);
                    }

                }

                List<Worksheet> Stations_REG_sheet = new List<Worksheet>();
                for (int i = 0; i < Stations_REG.Count; i++)
                {
                    cs0[i + 2 + Stations.Count, 0].PutValue(Stations_REG[i].STATIONNAME);
                    cs0[i + 2 + Stations.Count, 1].PutValue(Stations_REG[i].STATIONNUM);
                    Worksheet ws = wb.Worksheets.Add(Stations_REG[i].STATIONNAME);
                    Stations_REG_sheet.Add(ws);
                    ws.Cells[0, 3].PutValue(Stations_REG[i].STATIONNUM);
                    ws.Cells[0, 4].PutValue(Stations_REG[i].STATIONNAME);
                    ws.Cells.SetColumnWidth(0, 12);
                    ws.Cells[1, 0].PutValue("日期");
                    ws.Cells[1, 25].PutValue("当日合计");
                    TimeSpan Ts = (new TimeSpan(0)) + Ts0;
                    int lastday = 0;
                    decimal daydata = 0;
                    for (int j = 0; j < Datas_REG[i].Datas.Count; j++)
                    {

                        DateTime dt = Datetimes[Datas_REG[i].Datas[j].DateTimeIndex];
                        if (Ts.Days != lastday)
                            daydata = 0;

                        cs0[1, 2 + Ts.Days].PutValue(dt.AddSeconds(Convert.ToDouble(ds)).ToString("yyyy-MM-dd"));
                        cs0.SetColumnWidth(2 + Ts.Days, 12);
                        if (Datas_REG[i].Datas[j].PRE_1H != UnData)
                            daydata += Datas_REG[i].Datas[j].PRE_1H;
                        cs0[i + 2 + Stations.Count, 2 + Ts.Days].PutValue(daydata);
                        ws.Cells[2 + Ts.Days, 25].PutValue(daydata);
                        ws.Cells[1, dt.AddSeconds(Convert.ToDouble(ds)).Hour + 1].PutValue(dt.Hour.ToString());
                        ws.Cells[2 + Ts.Days, 0].PutValue(dt.ToString("yyyy-MM-dd"));
                        ws.Cells[2 + Ts.Days, dt.AddSeconds(Convert.ToDouble(ds)).Hour + 1].PutValue(Datas_REG[i].Datas[j].PRE_1H);

                        lastday = Ts.Days;
                        Ts = Ts.Add(ts);

                    }

                }
                return savewb(wb, path) && openfile(path);
            }
            catch (Exception ex)
            {
                addlog("导出出错");
                MessageBox.Show(this, "导出出错", "错误", MessageBoxButtons.OK);
                return false;
            }
            #endregion
        }
        public bool outputyaexcel(string path)
        {
            #region 导出远安订制模板的Excel数据表
            try
            {
                Workbook wb = new Workbook();
                wb.Worksheets.Clear();
                Worksheet mainworksheet = wb.Worksheets.Add("统计汇总表");
                Cells cs0 = mainworksheet.Cells;
                cs0[0, 3].PutValue("各站逐日数据汇总");
                cs0[1, 0].PutValue("站名");
                cs0[1, 1].PutValue("站号");
                List<Worksheet> Stations_sheet = new List<Worksheet>();
                decimal ds = -1 * (60 * 60 * 8 + 1);
                DateTime dt1 = datetime_start.AddSeconds((double)ds);
                TimeSpan Ts0 = new TimeSpan(dt1.Hour, dt1.Minute, dt1.Second);
                for (int i = 0; i < Stations.Count; i++)
                {
                    cs0[i + 2, 0].PutValue(Stations[i].STATIONNAME);
                    cs0[i + 2, 1].PutValue(Stations[i].STATIONNUM);

                    Worksheet ws = wb.Worksheets.Add(Stations[i].STATIONNAME);
                    Stations_sheet.Add(ws);
                    ws.Cells[0, 3].PutValue(Stations[i].STATIONNUM);
                    ws.Cells[0, 4].PutValue(Stations[i].STATIONNAME);
                    ws.Cells.SetColumnWidth(0, 12);
                    ws.Cells[1, 0].PutValue("日期");
                    ws.Cells[1, 25].PutValue("当日合计");
                    TimeSpan Ts = (new TimeSpan(0)) + Ts0;
                    int lastday = 0;
                    decimal daydata = 0;
                    for (int j = 0; j < Datas[i].Datas.Count; j++)
                    {
                        DateTime dt = Datetimes[Datas[i].Datas[j].DateTimeIndex];
                        if (Ts.Days != lastday)
                            daydata = 0;
                        cs0[1, 2 + Ts.Days].PutValue(dt.AddSeconds((double)ds).ToString("yyyy-MM-dd"));
                        cs0.SetColumnWidth(2 + Ts.Days, 12);
                        if (Datas[i].Datas[j].PRE_1H != UnData)
                            daydata += Datas[i].Datas[j].PRE_1H;
                        cs0[i + 2, 2 + Ts.Days].PutValue(daydata);
                        ws.Cells[2 + Ts.Days, 25].PutValue(daydata);
                        ws.Cells[1, dt.AddSeconds(Convert.ToDouble(ds)).Hour + 1].PutValue(dt.Hour.ToString());
                        ws.Cells[2 + Ts.Days, 0].PutValue(dt.ToString("yyyy-MM-dd"));
                        ws.Cells[2 + Ts.Days, dt.AddSeconds(Convert.ToDouble(ds)).Hour + 1].PutValue(Datas[i].Datas[j].PRE_1H);

                        lastday = Ts.Days;
                        Ts = Ts.Add(ts);
                    }

                }

                List<Worksheet> Stations_REG_sheet = new List<Worksheet>();
                for (int i = 0; i < Stations_REG.Count; i++)
                {
                    cs0[i + 2 + Stations.Count, 0].PutValue(Stations_REG[i].STATIONNAME);
                    cs0[i + 2 + Stations.Count, 1].PutValue(Stations_REG[i].STATIONNUM);
                    Worksheet ws = wb.Worksheets.Add(Stations_REG[i].STATIONNAME);
                    Stations_REG_sheet.Add(ws);
                    ws.Cells[0, 3].PutValue(Stations_REG[i].STATIONNUM);
                    ws.Cells[0, 4].PutValue(Stations_REG[i].STATIONNAME);
                    ws.Cells.SetColumnWidth(0, 12);
                    ws.Cells[1, 0].PutValue("日期");
                    ws.Cells[1, 25].PutValue("当日合计");
                    TimeSpan Ts = (new TimeSpan(0)) + Ts0;
                    int lastday = 0;
                    decimal daydata = 0;
                    for (int j = 0; j < Datas_REG[i].Datas.Count; j++)
                    {

                        DateTime dt = Datetimes[Datas_REG[i].Datas[j].DateTimeIndex];
                        if (Ts.Days != lastday)
                            daydata = 0;

                        cs0[1, 2 + Ts.Days].PutValue(dt.AddSeconds(Convert.ToDouble(ds)).ToString("yyyy-MM-dd"));
                        cs0.SetColumnWidth(2 + Ts.Days, 12);
                        if (Datas_REG[i].Datas[j].PRE_1H != UnData)
                            daydata += Datas_REG[i].Datas[j].PRE_1H;
                        cs0[i + 2 + Stations.Count, 2 + Ts.Days].PutValue(daydata);
                        ws.Cells[2 + Ts.Days, 25].PutValue(daydata);
                        ws.Cells[1, dt.AddSeconds(Convert.ToDouble(ds)).Hour + 1].PutValue(dt.Hour.ToString());
                        ws.Cells[2 + Ts.Days, 0].PutValue(dt.ToString("yyyy-MM-dd"));
                        ws.Cells[2 + Ts.Days, dt.AddSeconds(Convert.ToDouble(ds)).Hour + 1].PutValue(Datas_REG[i].Datas[j].PRE_1H);

                        lastday = Ts.Days;
                        Ts = Ts.Add(ts);

                    }

                }
                return savewb(wb, path) && openfile(path);
            }
            catch (Exception ex)
            {
                addlog("导出出错");
                MessageBox.Show(this, "导出出错", "错误", MessageBoxButtons.OK);
                return false;
            }
            #endregion
        }
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now.AddDays(-1);
            dateTimePicker2.Value = DateTime.Now;
            if (File.Exists("Stations.txt"))
                loadStations("Stations.txt");
            textBox1.Text = UnData.ToString();
            checkbos1check();
            addlog("软件启动");
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown s = (NumericUpDown)sender;
            s.Value = (decimal)(Math.Round(s.Value / Convert.ToDecimal(10)) * Convert.ToDecimal(10));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < openFileDialog1.FileNames.Length; i++)
                {
                    loadStations(openFileDialog1.FileNames[i]);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "统计并导出数据")
            {
                #region 统计时间判断

                #region 制备需统计时间
                datetime_start = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day, (int)numericUpDown2.Value, 0, 0);
                datetime_end = new DateTime(dateTimePicker2.Value.Year, dateTimePicker2.Value.Month, dateTimePicker2.Value.Day, (int)numericUpDown4.Value, 0, 0);
                ts = new TimeSpan(1, 0, 0);
                if (checkBox1.Checked)
                {
                    ts = new TimeSpan(0, 10, 0);
                    datetime_start = datetime_start.AddMinutes(-50);
                }
                #endregion
                if (datetime_start >= datetime_end)
                {
                    MessageBox.Show("时间错误！统计开始时间大于结束时间");
                    return;
                }
                #endregion

                #region 导出数据类型判断
                if (radioButton1.Checked)
                {
                    saveFileDialog1.DefaultExt = ".xls";
                    saveFileDialog1.Filter = "Excel文件|*.xls";
                    saveFileDialog1.FileName = "雨量数据.xls";
                    outputtype = "xls";
                }
                else
                {
                    if (radioButton2.Checked)
                    {
                        saveFileDialog1.DefaultExt = ".txt";
                        saveFileDialog1.Filter = "文本文件|*.txt";
                        saveFileDialog1.FileName = "雨量数据.txt";
                        outputtype = "txt";
                    }
                    else
                    {
                        if (radioButton3.Checked)
                        {
                            saveFileDialog1.DefaultExt = ".xls";
                            saveFileDialog1.Filter = "Excel文件|*.xls";
                            saveFileDialog1.FileName = "雨量数据.xls";
                            outputtype = "xls2";
                        }
                        else
                        {
                            if (radioButton5.Checked)
                            {
                                saveFileDialog1.DefaultExt = ".txt";
                                saveFileDialog1.Filter = "文本文件|*.txt";
                                saveFileDialog1.FileName = checkBox1.Checked ? datetime_start.ToString("MM月dd日HH时mm分") + "至" + datetime_end.ToString("dd日HH时mm分") + "雨情短信.txt" : datetime_start.ToString("MM月dd日HH时") + "到" + datetime_end.ToString("dd日HH时") + "雨情短信.txt";
                                outputtype = "txt2";
                            }
                            else
                            {
                                if (radioButton6.Checked)
                                {
                                    saveFileDialog1.DefaultExt = ".txt";
                                    saveFileDialog1.Filter = "文本文件|*.txt";
                                    saveFileDialog1.FileName = "宜都" + (checkBox1.Checked ? datetime_start.ToString("MM月dd日HH时mm分") + "至" + datetime_end.ToString("dd日HH时mm分") + "雨情短信.txt" : datetime_start.ToString("MM月dd日HH时") + "到" + datetime_end.ToString("dd日HH时") + "雨情短信.txt");
                                    outputtype = "yidutxt";
                                }
                                else
                                {
                                    saveFileDialog1.DefaultExt = ".xls";
                                    saveFileDialog1.Filter = "Excel文件|*.xls";
                                    saveFileDialog1.FileName = "雨量数据.xls";
                                    outputtype = "xls3";
                                }
                            }
                        }
                    }
                }
                #endregion
                DialogResult dr;
                //dr = folderBrowserDialog1.ShowDialog();
                dr = saveFileDialog1.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    saveStations("Stations.txt");
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.AllowUserToDeleteRows = false;
                    dataGridView1.ReadOnly = true;
                    groupBox2.Enabled = false;
                    groupBox5.Enabled = false;

                    backgroundWorker1.RunWorkerAsync();
                    button1.Text = "取消统计导出";
                    button2.Enabled = false;
                    button3.Enabled = false;
                }
            }
            else
            {
                if (backgroundWorker1.IsBusy)
                    backgroundWorker1.CancelAsync();
            }

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            addlog("开始下载数据");

            #region 初始化
            DateTime DT_work_start = DateTime.Now;
            Stations.Clear();
            Stations_REG.Clear();
            Datetimes.Clear();
            Datas.Clear();
            Datas_REG.Clear();
            string stationnums = "";
            string stationnums_REG = "";

            if (dataGridView1.Rows.Count < 1)
            {
                addlog("无需要统计的站点，统计结束");
                return;
            }
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            #region 审查区分国家站和区域站
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (backgroundWorker1.CancellationPending)
                {
                    addlog("用户取消统计，结束");
                    return;
                }
                station s = new station();
                s.STATIONNUM = (string)dataGridView1.Rows[i].Cells[0].Value;
                s.STATIONNAME = (string)dataGridView1.Rows[i].Cells[1].Value;
                station_datas station_data = new station_datas();
                station_data.PRE_COUNT = UnData;
                station_data.Datas = new List<metadata>();
                if (check_REG((string)dataGridView1.Rows[i].Cells[0].Value))
                {
                    station_data.StationIndex = Stations_REG.Count;
                    Stations_REG.Add(s);
                    Datas_REG.Add(station_data);
                }
                else
                {
                    station_data.StationIndex = Stations.Count;
                    Stations.Add(s);
                    Datas.Add(station_data);
                }
            }
            #endregion
            #region 下载站点信息数据
            if (Stations.Count > 0)
            {
                try
                {
                    string[] Stationnums = new string[Stations.Count];
                    for (int i = 0; i < Stations.Count; i++)
                        Stationnums[i] = Stations[i].STATIONNUM;
                    stationnums = Stationnums.Length > 0 ? "'" + string.Join("','", Stationnums) + "'" : "";
                    string station_SQL = @"select OBSERVTIMES,STATIONNAME,STATIONNUM,PROVINCE,CITY,COUNTY,LATITUDE,LONGITUDE,PRE_1H,Q_PRE_1H from SURF_DATA where STATIONNUM in ('$StationNUM$') and OBSERVTIMES = to_date('$DateTime$','yyyy-MM-dd HH:mm:ss') ";
                    for (int i = 0; i < Stations.Count; i++)
                    {
                        bool f = true;
                        DateTime DTT = DateTime.Now.AddHours(-1);
                        int downn = 0;
                        while (f && (downn < 720 || DTT >= datetime_start))
                        {
                            string station_url = url + "?sql=" + station_SQL.Replace("$StationNUM$", Stations[i].STATIONNUM).Replace("$DateTime$", DTT.ToString("yyyy-MM-dd HH:00:00"));
                            string jsonstr = wc.DownloadString(station_url);
                            if (jsonstr.Trim().Length > 0)
                            {
                                JArray ja = JArray.Parse(jsonstr);
                                if (ja.Count > 0)
                                {
                                    station s = Stations[i];
                                    s.CITY = ja[0]["CITY"].Value<string>();
                                    s.COUNTY = ja[0]["COUNTY"].Value<string>();
                                    s.LATITUDE = ja[0]["LATITUDE"].Value<string>();
                                    s.LONGITUDE = ja[0]["LONGITUDE"].Value<string>();
                                    s.PROVINCE = ja[0]["PROVINCE"].Value<string>();
                                    Stations[i] = s;
                                    f = false;
                                }
                            }
                            downn++;
                            DTT = DTT.AddHours(-1);
                        }
                    }
                }
                catch (Exception ex) { }
            }
            if (Stations_REG.Count > 0)
            {
                try
                {
                    string[] Stationnums = new string[Stations_REG.Count];
                    for (int i = 0; i < Stations_REG.Count; i++)
                        Stationnums[i] = Stations_REG[i].STATIONNUM;
                    stationnums_REG = Stationnums.Length > 0 ? "'" + string.Join("','", Stationnums) + "'" : "";
                    string stations_REG_SQL = @"select OBSERVTIMES,STATIONNAME,STATIONNUM,PROVINCE,CITY,COUNTY,LATITUDE,LONGITUDE,PRE_1H,Q_PRE_1H from SURF_DATA_REG where STATIONNUM in ('$StationNUM$') and OBSERVTIMES = to_date('$DateTime$','yyyy-MM-dd HH:mm:ss') ";
                    for (int i = 0; i < Stations_REG.Count; i++)
                    {
                        bool f = true;
                        DateTime DTT = DateTime.Now.AddHours(-1);
                        int downn = 0;
                        while (f && (downn < 720 || DTT >= datetime_start))
                        {
                            string station_REG_url = url + "?sql=" + stations_REG_SQL.Replace("$StationNUM$", Stations_REG[i].STATIONNUM).Replace("$DateTime$", DTT.ToString("yyyy-MM-dd HH:00:00"));
                            string jsonstr = wc.DownloadString(station_REG_url);
                            if (jsonstr.Trim().Length > 0)
                            {
                                JArray ja = JArray.Parse(jsonstr);
                                if (ja.Count > 0)
                                {
                                    station s = Stations_REG[i];
                                    s.CITY = ja[0]["CITY"].Value<string>();
                                    s.COUNTY = ja[0]["COUNTY"].Value<string>();
                                    s.LATITUDE = ja[0]["LATITUDE"].Value<string>();
                                    s.LONGITUDE = ja[0]["LONGITUDE"].Value<string>();
                                    s.PROVINCE = ja[0]["PROVINCE"].Value<string>();
                                    Stations_REG[i] = s;
                                    f = false;
                                }
                            }
                            downn++;
                            DTT = DTT.AddHours(-1);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            #endregion

            #endregion

            DateTime DT = datetime_start;
            TimeSpan mainTs = datetime_end - datetime_start;
            int dcount = Convert.ToInt32(Math.Floor((decimal)(mainTs.Ticks / ts.Ticks)));
            int di = 0;
            progressBar1.Maximum = dcount + 1;
            if (radioButton8.Checked)
            {
                #region 从Hbase数据库下载数据
                while (DT <= datetime_end)
                {
                    if (backgroundWorker1.CancellationPending)
                    {
                        addlog("用户取消统计，结束");
                        return;
                    }
                    progressBar1.Value = di;
                    Datetimes.Add(DT);
                    #region 下载国家站数据
                    if (Stations.Count > 0)
                    {
                        for (int i = 0; i < Stations.Count; i++)
                        {

                            metadata md = new metadata();
                            md.DateTimeIndex = di;
                            md.PRE_1H = UnData;
                            md.PRE_10M = UnData;
                            Datas[i].Datas.Add(md);
                        }
                        string station_SQL = @"select STATIONNAME,STATIONNUM,PROVINCE,CITY,COUNTY,LATITUDE,LONGITUDE,PRE_1H,Q_PRE_1H from SURF_DATA where OBSERVTIMES = to_date('" + DT.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-MM-dd HH:mm:ss') and STATIONNUM in(" + stationnums + ")";
                        try
                        {
                            string jsonstr = wc.DownloadString(url + "?sql=" + station_SQL);
                            JArray ja = JArray.Parse(jsonstr);
                            for (int i = 0; i < ja.Count; i++)
                            {
                                bool f = true;
                                for (int j = 0; j < Stations.Count && f; j++)
                                    if (Stations[j].STATIONNUM == ja[i]["STATIONNUM"].Value<string>())
                                    {
                                        metadata md = Datas[j].Datas[di];
                                        md.PRE_1H = ja[i]["PRE_1H"].Value<decimal>();
                                        if (md.PRE_1H >= 9998)
                                        {
                                            md.PRE_1H = UnData;
                                        }
                                        md.PRE_10M = md.PRE_1H;
                                        Datas[j].Datas[di] = md;
                                        f = false;
                                    }
                            }
                        }
                        catch (Exception ex) { }
                    }
                    #endregion
                    #region 下载区域站数据
                    if (Stations_REG.Count > 0)
                    {
                        for (int i = 0; i < Stations_REG.Count; i++)
                        {

                            metadata md = new metadata();
                            md.DateTimeIndex = di;
                            md.PRE_1H = UnData;
                            md.PRE_10M = UnData;
                            Datas_REG[i].Datas.Add(md);
                        }

                        string stations_REG_SQL = @"select STATIONNAME,STATIONNUM,PROVINCE,CITY,COUNTY,LATITUDE,LONGITUDE,PRE_1H,Q_PRE_1H from SURF_DATA_REG where OBSERVTIMES = to_date('" + DT.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-MM-dd HH:mm:ss') and STATIONNUM in(" + stationnums_REG + ")";
                        try
                        {
                            string jsonstr = wc.DownloadString(url + "?sql=" + stations_REG_SQL);
                            JArray ja = JArray.Parse(jsonstr);
                            for (int i = 0; i < ja.Count; i++)
                            {
                                bool f = true;
                                for (int j = 0; j < Stations_REG.Count && f; j++)
                                    if (Stations_REG[j].STATIONNUM == ja[i]["STATIONNUM"].Value<string>())
                                    {
                                        metadata md = Datas_REG[j].Datas[di];
                                        md.PRE_1H = ja[i]["PRE_1H"].Value<decimal>();
                                        if (md.PRE_1H >= 9998)
                                        {
                                            md.PRE_1H = UnData;
                                        }
                                        md.PRE_10M = md.PRE_1H;
                                        Datas_REG[j].Datas[di] = md;
                                        f = false;
                                    }
                            }
                        }
                        catch (Exception ex) { }
                    }
                    #endregion
                    addlog("完成" + DT.ToString("yyyy-MM-dd HH:mm") + "的数据下载");
                    DT += ts;
                    di++;
                }
                #region 分钟数据处理
                if (checkBox1.Checked)
                {

                    if (Stations.Count > 0)
                    {
                        for (int i = 0; i < Stations.Count; i++)
                        {
                            for (int j = 0; j < Datetimes.Count; j++)
                            {
                                if (Datetimes[Datas[i].Datas[j].DateTimeIndex].Minute != 10)
                                {
                                    metadata md = Datas[i].Datas[j];
                                    if (md.PRE_10M != UnData && Datas[i].Datas[j - 1].PRE_1H != UnData)
                                        md.PRE_10M = md.PRE_10M - Datas[i].Datas[j - 1].PRE_1H;

                                    Datas[i].Datas[j] = md;
                                }
                            }
                        }
                    }

                    if (Stations_REG.Count > 0)
                    {
                        for (int i = 0; i < Stations_REG.Count; i++)
                        {
                            for (int j = 0; j < Datetimes.Count; j++)
                            {
                                if (Datetimes[Datas_REG[i].Datas[j].DateTimeIndex].Minute != 10)
                                {
                                    metadata md = Datas_REG[i].Datas[j];
                                    if (md.PRE_10M != UnData && Datas_REG[i].Datas[j - 1].PRE_1H != UnData)
                                        md.PRE_10M = md.PRE_10M - Datas_REG[i].Datas[j - 1].PRE_1H;

                                    Datas_REG[i].Datas[j] = md;
                                }
                            }
                        }
                    }
                }
                #endregion
                #endregion
            }
            else
            {
                #region 从CIMISS下载数据

                int Station_Count = Stations.Count + Stations_REG.Count;
                int StationsCount = Stations.Count;
                progressBar1.Maximum = Station_Count + 1;
                while (DT <= datetime_end)
                {
                    Datetimes.Add(DT);
                    DT += ts;
                    di++;
                }
                for (int i = 0; i < Station_Count; i++)
                {
                    station s = i < StationsCount ? Stations[i] : Stations_REG[i - StationsCount];
                    station_datas sd = i < StationsCount ? Datas[i] : Datas_REG[i - StationsCount];
                    #region 初始化站点数据集
                    List<metadata> dds = new List<metadata>();
                    DT = datetime_start;
                    di = 0;
                    while (DT <= datetime_end)
                    {
                        metadata md = new metadata();
                        md.DateTimeIndex = di;
                        md.PRE_1H = UnData;
                        md.PRE_10M = UnData;
                        dds.Add(md);
                        DT += ts;
                        di++;
                    }
                    #endregion

                    #region 下载数据
                    DT = datetime_start;
                    DateTime dtt;
                    while (DT < datetime_end)
                    {
                        dtt = DT + TSlimit;
                        if (dtt > datetime_end)
                            dtt = datetime_end;

                        string durl = string.Format(cimissurl, s.STATIONNUM, DT.AddHours(-8).ToString("yyyyMMddHH0000"), dtt.AddHours(-8).ToString("yyyyMMddHH0000"));

                        string jsonstr = wc.DownloadString(durl);
                        JObject jo = JObject.Parse(jsonstr);
                        JArray sds = (JArray)jo["data"];
                        for (int j = 0; j < sds.Count; j++)
                        {
                            DateTime d = sds[j]["OBSERVTIMES"].Value<DateTime>();
                            TimeSpan dts = d - datetime_start;
                            int index = Convert.ToInt32(Math.Floor((decimal)(dts.Ticks / ts.Ticks)));
                            metadata md = dds[index];
                            md.DateTimeIndex = index;
                            string v = sds[j]["PRE_1H"].Value<string>();
                            if (!decimal.TryParse(v, out md.PRE_10M))
                                md.PRE_10M = UnData;

                            dds[index] = md;
                        }
                        DT = dtt;
                    }
                    #endregion

                    sd.Datas = dds;
                    if (i < StationsCount)
                        Datas[i] = sd;
                    else
                        Datas_REG[i-StationsCount] = sd;

                    progressBar1.Value = i;
                    addlog("完成" + s.STATIONNAME + "的数据下载");
                }
                #endregion
            }

            #region 合计值统计

            if (Stations.Count > 0)
            {
                for (int i = 0; i < Stations.Count; i++)
                {
                    decimal count = 0;
                    for (int j = 0; j < Datetimes.Count; j++)
                    {
                        if (Datas[i].Datas[j].PRE_10M != UnData)
                        {
                            count += Datas[i].Datas[j].PRE_10M;
                        }
                    }
                    station_datas sd = Datas[i];
                    sd.PRE_COUNT = count;
                    Datas[i] = sd;
                }
            }

            if (Stations_REG.Count > 0)
            {
                for (int i = 0; i < Stations_REG.Count; i++)
                {
                    decimal count = 0;
                    for (int j = 0; j < Datetimes.Count; j++)
                    {
                        if (Datas_REG[i].Datas[j].PRE_10M != UnData)
                        {
                            count += Datas_REG[i].Datas[j].PRE_10M;
                        }
                    }
                    station_datas sd = Datas_REG[i];
                    sd.PRE_COUNT = count;
                    Datas_REG[i] = sd;
                }
            }

            #endregion
            addlog("完成数据采集，开始导出");
            switch (outputtype)
            {
                case "xls":
                    outputxsexcel(saveFileDialog1.FileName);
                    break;

                case "xls2":
                    outputexcel(saveFileDialog1.FileName);
                    break;
                case "xls3":
                    outputyaexcel(saveFileDialog1.FileName);
                    break;
                case "yidutxt":
                case "txt2":
                    List<int> Sequence = new List<int>();
                    int Station_Count = Stations.Count + Stations_REG.Count;
                    int StationsCount = Stations.Count;
                    for (int i = 0; i < Station_Count; i++)
                        Sequence.Add(i);
                    for (int i = 0; i < Station_Count; i++)
                    {
                        for (int j = 1; j < Station_Count; j++)
                        {
                            station_datas sd1 = Sequence[j - 1] >= StationsCount ? Datas_REG[Sequence[j - 1] - StationsCount] : Datas[Sequence[j - 1]];
                            station_datas sd2 = Sequence[j] >= StationsCount ? Datas_REG[Sequence[j] - StationsCount] : Datas[Sequence[j]];
                            if (sd1.PRE_COUNT < sd2.PRE_COUNT)
                            {
                                int d = Sequence[j - 1];
                                Sequence[j - 1] = Sequence[j];
                                Sequence[j] = d;
                            }
                        }
                    }
                    string outstring = "", outstring1 = "", outstring2 = "", outstring3 = "";

                    for (int i = 0; i < Station_Count; i++)
                    {
                        station st = Sequence[i] >= StationsCount ? Stations_REG[Sequence[i] - StationsCount] : Stations[Sequence[i]];
                        station_datas sd1 = Sequence[i] >= StationsCount ? Datas_REG[Sequence[i] - StationsCount] : Datas[Sequence[i]];
                        station_datas sd2 = i + 1 < Station_Count ? (Sequence[i + 1] >= StationsCount ? Datas_REG[Sequence[i + 1] - StationsCount] : Datas[Sequence[i + 1]]) : new station_datas();
                        outstring1 += st.STATIONNAME + sd1.PRE_COUNT.ToString();

                        if (i < Station_Count - 1 && Math.Round(sd1.PRE_COUNT, 0, MidpointRounding.AwayFromZero) == Math.Round(sd2.PRE_COUNT, 0, MidpointRounding.AwayFromZero))
                            outstring2 += st.STATIONNAME + "、";
                        else
                            outstring2 += st.STATIONNAME + Math.Round(sd1.PRE_COUNT, 0, MidpointRounding.AwayFromZero).ToString();

                        outstring3 += st.STATIONNAME + Math.Round(sd1.PRE_COUNT, 0, MidpointRounding.AwayFromZero).ToString();

                    }

                    if (outputtype != "yidutxt")
                    {
                        string headerstring = (datetime_start.Minute > 0 ? datetime_start.ToString("yyyy年MM月dd日HH时mm分") : datetime_start.ToString("yyyy年MM月dd日HH时")) + "至" + (datetime_end.Minute > 0 ? datetime_end.ToString("dd日HH时mm分") + "雨量：" : datetime_end.ToString("dd日HH时") + "雨量：");

                        outstring = headerstring + outstring1 + @"

" + headerstring + outstring3 + @"

" + headerstring + outstring2;
                    }
                    else
                    {
                        if (datetime_start.Hour == 9 && datetime_end.Hour == 8)
                            outstring = "【宜都气象】" + datetime_start.ToString("yyyy年MM月dd日08时") + "至" + datetime_end.ToString("dd日HH时") + "雨量：";
                        else
                            outstring = "【宜都气象】" + datetime_start.ToString("yyyy年MM月dd日HH时") + "至" + datetime_end.ToString("dd日HH时") + "雨量：";

                        outstring += outstring2 + @"

";
                    }

                    if (File.Exists(saveFileDialog1.FileName))
                        File.Delete(saveFileDialog1.FileName);
                    File.WriteAllText(saveFileDialog1.FileName, outstring);
                    openfile(saveFileDialog1.FileName);
                    break;
                case "txt":
                default:
                    #region 导出Micaps第3类数据
                    //                    StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, false, Encoding.GetEncoding("GBK"));
                    //                    sw.WriteLine("diamond 3 " + datetime_start.ToString("yyyy年MM月dd日HH时mm分") + "到" + datetime_end.ToString("yyyy年MM月dd日HH时mm分") + "降水");
                    //                    sw.WriteLine(datetime_start.ToString("yyyy MM dd HH   ") + dcount.ToString());
                    //                    sw.WriteLine(@"      8
                    //      1      5     10     25     50    100    150    200
                    //      1     25     39
                    //  122.7   37.3  122.5   36.7  120.8   36.2  119.3   35.0  120.4   34.3
                    //  121.1   32.7  122.3   30.9  122.5   30.1  121.5   28.0  119.8   25.0
                    //  116.1   22.6  111.0   21.0  111.0   18.6  109.6   18.1  108.3   18.5
                    //  108.9   19.9  109.3   21.0  106.4   21.6  104.1   22.2  101.6   20.8
                    //   98.7   22.0   97.1   24.1   97.7   27.0   91.7   26.6   85.7   27.7
                    //   78.9   30.6   73.3   37.1   74.1   40.7   87.6   49.8   98.5   43.9
                    //  110.4   44.3  122.0   54.7  135.7   48.3  131.5   42.2  125.2   39.4
                    //  121.3   38.5  121.2   40.3  118.5   38.6  120.8   38.1");
                    //                    sw.WriteLine("1    " + (Stations.Count + Stations_REG.Count).ToString());
                    //                    for (int i = 0; i < Stations.Count; i++)
                    //                    {
                    //                        sw.Write(Stations[i].STATIONNUM + "  " + Stations[i].LONGITUDE + "  " + Stations[i].LATITUDE + "  0");
                    //                        for (int j = 0; j < Datas[i].Datas.Count; j++)
                    //                        {
                    //                            sw.Write(" " + Datas[i].Datas[j].PRE_1H.ToString());

                    //                        }
                    //                        sw.WriteLine();

                    //                    }

                    //                    for (int i = 0; i < Stations_REG.Count; i++)
                    //                    {
                    //                        sw.Write(Stations_REG[i].STATIONNUM + "  " + Stations_REG[i].LATITUDE + "  " + Stations_REG[i].LONGITUDE + "  0");
                    //                        for (int j = 0; j < Datas_REG[i].Datas.Count; j++)
                    //                        {
                    //                            sw.Write(" " + Datas_REG[i].Datas[j].PRE_1H.ToString());

                    //                        }
                    //                        sw.WriteLine();

                    //                    }

                    //                    sw.Close();
                    #endregion
                    #region 导出R数据文件
                    StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                    for (int i = 0; i < Stations.Count; i++)
                    {
                        decimal lon, lat;
                        string lonstr = "     ", latstr = "     ";
                        if (decimal.TryParse(Stations[i].LONGITUDE, out lon))
                        {
                            int lon1 = Convert.ToInt32(Math.Floor(lon));
                            int lon2 = Convert.ToInt32(Math.Round((lon - lon1) * 60));
                            lonstr = lon1.ToString("000") + lon2.ToString("00");
                        };

                        if (decimal.TryParse(Stations[i].LATITUDE, out lat))
                        {
                            int lat1 = Convert.ToInt32(Math.Floor(lat));
                            int lat2 = Convert.ToInt32(Math.Round((lat - lat1) * 60));
                            latstr = lat1.ToString("000") + lat2.ToString("00");
                        };
                        sw.Write(Stations[i].STATIONNUM + lonstr + latstr);
                        for (int j = 0; j < Datas[i].Datas.Count - 1; j++)
                        {
                            sw.Write(Datas[i].Datas[j].PRE_10M.ToString() + ",");
                        }
                        sw.WriteLine(Datas[i].Datas[Datas[i].Datas.Count - 1].PRE_10M.ToString());
                    }

                    for (int i = 0; i < Stations_REG.Count; i++)
                    {
                        decimal lon, lat;
                        string lonstr = "     ", latstr = "     ";
                        if (decimal.TryParse(Stations_REG[i].LONGITUDE, out lon))
                        {
                            int lon1 = Convert.ToInt32(Math.Floor(lon));
                            int lon2 = Convert.ToInt32(Math.Round((lon - lon1) * 60));
                            lonstr = lon1.ToString("000") + lon2.ToString("00");
                        };

                        if (decimal.TryParse(Stations_REG[i].LATITUDE, out lat))
                        {
                            int lat1 = Convert.ToInt32(Math.Floor(lat));
                            int lat2 = Convert.ToInt32(Math.Round((lat - lat1) * 60));
                            latstr = lat1.ToString("000") + lat2.ToString("00");
                        };
                        sw.Write(Stations_REG[i].STATIONNUM + lonstr + latstr);
                        for (int j = 0; j < Datas_REG[i].Datas.Count - 1; j++)
                        {
                            sw.Write(Datas_REG[i].Datas[j].PRE_10M.ToString() + ",");
                        }
                        sw.WriteLine(Datas_REG[i].Datas[Datas_REG[i].Datas.Count - 1].PRE_10M.ToString());
                    }
                    sw.Close();
                    #endregion
                    break;
            }

            progressBar1.Value = progressBar1.Maximum;

            DateTime DT_work_end = DateTime.Now;
            TimeSpan TS_work = DT_work_end - DT_work_start;

            addlog("完成统计导出,耗时" + TS_work.TotalSeconds.ToString() + "秒");

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.ReadOnly = false;
            button1.Text = "统计并导出数据";
            button2.Enabled = true;
            button3.Enabled = true;
            groupBox2.Enabled = true;
            groupBox5.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            decimal d;
            if (decimal.TryParse(((TextBox)sender).Text, out d))
            {
                UnData = d;
            }
            else
            {
                MessageBox.Show(this, "请输入数字用于表示缺测", "错误");
                ((TextBox)sender).Text = defaultUnData.ToString();
            }
        }

        #region 界面逻辑
        private void checkbos1check()
        {
            radioButton1.Enabled = radioButton4.Enabled = radioButton5.Enabled = radioButton6.Enabled = radioButton7.Enabled = !checkBox1.Checked;

            if (radioButton1.Checked || radioButton4.Checked || radioButton5.Checked || radioButton6.Checked || radioButton7.Checked)
            {
                checkBox1.Enabled = false;
            }
            else
            {
                checkBox1.Enabled = true;
            }
            if (!checkBox1.Enabled)
                checkBox1.Checked = false;
            if (checkBox1.Checked)
            {
                if (radioButton1.Checked || radioButton4.Checked || radioButton5.Checked || radioButton6.Checked)
                    radioButton3.Checked = true;
                if (radioButton7.Checked)
                    radioButton8.Checked = true;
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkbos1check();
        }
        private void button4_Click(object sender, EventArgs e)
        {

            saveFileDialog1.DefaultExt = ".txt";
            saveFileDialog1.Filter = "自动站表文件|*.txt";
            saveFileDialog1.FileName = "Stations.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveStations(saveFileDialog1.FileName);
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                numericUpDown2.Value = 21;
                numericUpDown4.Value = 20;
            }
            checkbos1check();
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                numericUpDown2.Value = 9;
                numericUpDown4.Value = 8;
            }
            checkbos1check();
        }
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            checkbos1check();
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                numericUpDown2.Value = 9;
                numericUpDown4.Value = 8;
            }

            checkbos1check();
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

            checkbos1check();
        }
        #endregion  

    }

}

