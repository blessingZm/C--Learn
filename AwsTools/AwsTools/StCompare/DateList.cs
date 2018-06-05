using System;
using System.Collections.Generic;

namespace StationCompara
{
    class DateList
    {
        // 根据日期格式的 起止日期，生成指定的时间序列
        private readonly DateTime start_dt;
        private readonly DateTime end_dt;

        public DateList(DateTime stdt, DateTime enddt)
        {
            start_dt = stdt;
            end_dt = enddt;
        }

        // 年月 序列,sep_str为年月之间的连接字符
        public List<string> GetYM(string sep_str="")
        {
            DateTime dt = new DateTime();
            List<string> result = new List<string>();
            for (dt = start_dt; dt.CompareTo(end_dt) <= 0; dt = dt.AddMonths(1))
            {
                result.Add(dt.ToString($"yyyy{sep_str}MM"));
            }
            return result;
        }

        // 年月日 序列,sep_str为年月日之间的连接字符
        public List<string> GetYMD(string sep_str = "")
        {
            DateTime dt = new DateTime();
            List<string> result = new List<string>();
            for (dt = start_dt; dt.CompareTo(end_dt) <= 0; dt = dt.AddDays(1))
            {
                result.Add(dt.ToString($"yyyy{sep_str}MM{sep_str}dd"));
            }
            return result;
        }

        // 年月日 序列,sep_str1为年月日之间的连接字符, sep_str2为日与时之间的连接字符
        public List<string> GetYMDH(string sep_str1 = "", string sep_str2="")
        {
            DateTime dt = new DateTime();
            List<string> result = new List<string>();
            for (dt = start_dt; dt.CompareTo(end_dt) <= 0; dt = dt.AddHours(1))
            {
                result.Add(dt.ToString($"yyyy{sep_str1}MM{sep_str1}dd{sep_str2}HH"));
            }
            return result;
        }
    }
}
