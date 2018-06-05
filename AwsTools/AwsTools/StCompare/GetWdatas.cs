using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StationCompara
{
    // 从A文件获取风数据，包括气象时间、风向度数、风向方位、风速
    class GetWdatas
    {
        private string afile;
        private int wd_num;
        private readonly string[] wind_directs;
        private readonly string[] Hours;

        public GetWdatas(string a_file, int wdnum)
        {
            afile = a_file;
            BaseDatas bd = new BaseDatas();
            wind_directs = bd.WdDirects;
            Hours = bd.MeterHours;
            wd_num = wdnum;
        }

        public List<ArrayList> GetDatas()
        {
            List<ArrayList> result = new List<ArrayList>();
            int wd = 0;
            double ws = 0.0;
            string wd_direct = " ";
            string year_month = afile.Split('-')[1].Substring(0, 6);
            string year = year_month.Substring(0, 4);
            string month = year_month.Substring(4, 2);
            StreamReader sr = new StreamReader(afile);
            string line;
            while (true)
            {
                line = sr.ReadLine();
                if (line.Contains("FN"))
                    break;   
            }
            // 针对读取10分钟风
            if (wd_num == 10)
            {
                while (true)
                {
                    line = sr.ReadLine();
                    if (line.Contains("="))
                        break;
                }
            }
            else if (wd_num != 2 && wd_num != 10)
                throw new ArgumentOutOfRangeException("第二个参数必须为2或者10！");

            int day = 1;
            int day_start = 0;
            while (true)
            {
                day_start += 1;
                line = sr.ReadLine().Trim();
                string[] buf_line = line.Split();
                for (int i = 0; i < buf_line.Length; i++)
                {
                    ArrayList buf = new ArrayList();
                    string b = buf_line[i];
                    int hour_loc = (day_start - 1) * 6 + i;
                    string hour = Hours[hour_loc];
                    // 组成‘年-月-日 时’格式的日期
                    string date_time = year + "-" + month + "-" + day.ToString("00") + " " + 
                        hour + ":00:00";
                    if (b.Contains("=") || b.Contains('.'))
                    {
                        b = b.Substring(0, b.Length - 1);
                        day_start = 0;
                        day += 1;
                    }
                    bool no_except = true;
                    try
                    {
                        ws = Convert.ToInt32(b.Substring(3, 3)) / 10.0;
                    }
                    catch
                    {
                        wd = 999999;
                        ws = 999999.0;
                        wd_direct = "-";
                        no_except = false;
                    }
                    if (no_except)
                    {
                        if (ws < 0.3)
                        {
                            wd = 999999;
                            wd_direct = "C";
                        }
                        else
                        {
                            // 解析风向
                            try
                            {
                                wd = Convert.ToInt32(b.Substring(0, 3));
                                int wd_loc = Convert.ToInt32(Math.Floor((wd + 11.25) / 22.5));
                                if (wd_loc > 15)
                                    wd_direct = "N";
                                else
                                    wd_direct = wind_directs[wd_loc];
                            }
                            catch
                            {
                                wd = 999999;
                                wd_direct = "-";
                            }                           
                        }
                    }
                    buf = new ArrayList(){ date_time, wd, wd_direct, ws};
                    result.Add(buf);              
                }
                if (line.Contains("="))
                    break;
            }
            return result;
        }
    }
}
