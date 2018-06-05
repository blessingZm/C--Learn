using System;
using System.Collections.Generic;
using System.IO;

namespace StationCompara
{
    class BaseDatas
    {
        //参数文件内容
        public readonly string NewPath = @".\新址A";
        public readonly string OldPath = @".\旧址A";
        public readonly string StId;
        public readonly List<DateTime> DateRange;
        
        public BaseDatas(string config_file = @".\Config\StCompara.ini")
        {
            StreamReader sr = new StreamReader(config_file);
            string line;
            List<string> configs = new List<string>();
            while ((line = sr.ReadLine()) != null)
            {
                configs.Add(line.Trim().Split('=')[1]);
            }
            sr.Close();
            DateRange = new List < DateTime >
            {
                Convert.ToDateTime($"{configs[0]}"), Convert.ToDateTime($"{configs[1]}")
            };
            StId = configs[2];
        }
        // 不变参数
        public readonly string[] WdDirects = new string[]
        {
            "N", "NNE", "NE", "ENE", "E", "ESE", "SE", "SSE",
            "S", "SSW", "SW", "WSW", "W", "WNW", "NW", "NNW", "C"
        };
        public readonly string[] MeterHours = new string[]
        {
            "21", "22", "23", "00", "01", "02", "03", "04", "05", "06", "07", "08",
            "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20"
        };
        public readonly string[] Months = new string[]
        {
            "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"
        };
    }
}
