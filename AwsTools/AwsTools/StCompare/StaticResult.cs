using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StationCompara
{
    // 根据某个月的风数据统计风向相符率、风向频率、风向频率差
    class StaticResult
    {
        private readonly List<ArrayList> new_datas;
        private readonly List<ArrayList> old_datas;
        private readonly BaseDatas bd = new BaseDatas();

        public StaticResult(List<ArrayList> newdatas, List<ArrayList> olddatas)
        {
            new_datas = newdatas;
            old_datas = olddatas;
        }

        //风向相符率
        public double WdConincideceRate()
        {
            int all_num = 0;
            int conincidece_num = 0;
            for (int i = 0; i < new_datas.Count; i++)
            {
                ArrayList new_buf = new_datas[i];
                ArrayList old_buf = old_datas[i];

                if (Convert.ToInt32(new_buf[1]) > 360 || Convert.ToInt32(old_buf[1]) > 360)
                    continue;
                if (Math.Abs(Convert.ToInt32(new_buf[1]) - Convert.ToInt32(old_buf[1])) < 23)
                    conincidece_num += 1;
                all_num += 1;
            }
            double result = Convert.ToDouble(conincidece_num) / Convert.ToDouble(all_num) * 100;
            result = Math.Round(result, 1);
            return result;
        }

        //风向频率
        public Dictionary<string, double> WdFrequency(List<ArrayList> datas)
        {
            Dictionary<string, double> result = new Dictionary<string, double>();
            foreach(string direct in bd.WdDirects)
            {
                result[$"{direct}"] = 0.0;
            }
            foreach(ArrayList data in datas)
            {
                string direct = data[2].ToString();
                if (bd.WdDirects.Contains(direct))
                {
                    result[$"{direct}"] += 1.0;
                }
            }
            // 所有风向出现的总回数
            double all_nums = 0.0;
            foreach (double value in result.Values)
                all_nums += value;
            // 各风向出现的频率
            foreach (string direct in bd.WdDirects)
            {
                double buf = result[$"{direct}"] / all_nums * 100;
                result[$"{direct}"] = Math.Round(buf, MidpointRounding.AwayFromZero);
            }               
            return result;
        }

        //风向频率差
        public Dictionary<string, double> WdFrequencyDif()
        {
            Dictionary<string, double> new_fre = WdFrequency(new_datas);
            Dictionary<string, double> old_fre = WdFrequency(old_datas);
            Dictionary<string, double> result = new Dictionary<string, double>();
            foreach (string direct in bd.WdDirects)
            {
                result[$"{direct}"] = new_fre[$"{direct}"] - old_fre[$"{direct}"];
            }
            return result;
        }
    }
}
