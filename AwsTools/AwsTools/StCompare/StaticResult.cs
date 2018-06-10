using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace StationCompara
{
    class StaticResult
    {
        private SqliteClass sq;
        private BaseDatas bd = new BaseDatas();
        private string table_name;
        private Workbook wb;
        private Worksheet ws_conincidence;
        private Worksheet ws_fre_new;
        private Worksheet ws_fre_old;
        private Worksheet ws_fre_dif;

        // 初始化
        public StaticResult(string dbpath, string dbname, string tablename)
        {
            sq = new SqliteClass(dbpath, dbname);
            table_name = tablename;

            // 创建统计结果的excel文件，并写入表头
            wb = new Workbook();
            wb.Worksheets.Clear();
            ws_conincidence = wb.Worksheets.Add("风向相符率");
            ws_fre_new = wb.Worksheets.Add("新址风向频率");
            ws_fre_old = wb.Worksheets.Add("旧址风向频率");
            ws_fre_dif = wb.Worksheets.Add("风向频率差");

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
        }

        // 写相符率
        public void WriteConincidence()
        {          
            string start_year = "";
            int year_row = 0;
            List<string> select_cols_coin = new List<string>
            {
                "strftime('%Y', datetime(meter_time)) as year",
                "strftime('%m', datetime(meter_time)) as month",
                "(count(case when (abs(wd_dif) < 22.5 or abs(wd_dif) > 337.5) " +
                "then 1 end) / cast (count(wd_dif) as double)) * 100 as coin_rate"
            };
            string end_string_coin = " WHERE new_wd <= 360 and old_wd <= 360 " +
                "group by year,month";

            string sql = $"select {string.Join(",", select_cols_coin)} " +
                $"from {table_name} {end_string_coin}";
            SQLiteDataReader reader = sq.SelectDatas(sql);
            while (reader.Read())
            {
                string year = reader["year"].ToString();
                string month = reader["month"].ToString();
                double rate = Math.Round(Convert.ToDouble(reader["coin_rate"]), 1);
                if (year != start_year)
                {
                    year_row += 1;
                    start_year = year;
                    ws_conincidence.Cells[year_row, 0].Value = year;
                }
                int col = Array.IndexOf(bd.Months, month) + 1;
                ws_conincidence.Cells[year_row, col].Value = rate;
            }
        }

        // 写频率
        public void WriteFrequence()
        {
            string new_sql = select_string("new");
            string old_sql = select_string("old");
            SQLiteDataReader new_reader = sq.SelectDatas(new_sql);
            SQLiteDataReader old_reader = sq.SelectDatas(old_sql);
            int row = 0;
            while (new_reader.Read() && old_reader.Read())
            {
                string year = new_reader["year"].ToString();
                string month = new_reader["month"].ToString();
                ws_fre_new.Cells[row + 1, 0].Value = year;
                ws_fre_new.Cells[row + 1, 1].Value = month;

                ws_fre_old.Cells[row + 1, 0].Value = year;
                ws_fre_old.Cells[row + 1, 1].Value = month;

                ws_fre_dif.Cells[row + 1, 0].Value = year;
                ws_fre_dif.Cells[row + 1, 1].Value = month;

                foreach (string direct in bd.WdDirects)
                {
                    int col = Array.IndexOf(bd.WdDirects, direct) + 2;
                    int new_fre = Convert.ToInt32(Math.Round(
                        Convert.ToDouble(new_reader[$"{direct}"]), MidpointRounding.AwayFromZero));
                    int old_fre = Convert.ToInt32(Math.Round(
                        Convert.ToDouble(old_reader[$"{direct}"]), MidpointRounding.AwayFromZero));
                    int dif = new_fre - old_fre;

                    ws_fre_new.Cells[row + 1, col].Value = new_fre;
                    ws_fre_old.Cells[row + 1, col].Value = old_fre;
                    ws_fre_dif.Cells[row + 1, col].Value = new_fre - old_fre;
                }
                row++;
            }
        }

        private string select_string(string dataset)
        {
            string result;
            List<string> select_cols_fre = new List<string>
            {
                "strftime('%Y', datetime(meter_time)) as year",
                "strftime('%m', datetime(meter_time)) as month"
            };

            string end_string = "";
            
            if (dataset == "new")
            {
                foreach (string direct in bd.WdDirects)
                {
                    select_cols_fre.Add($"(count(case when new_wd_direct == '{direct}' then 1 end) " +
                        $"/ cast (count(new_wd_direct) as double)) * 100 as {direct}");
                }       
                end_string = $" WHERE new_wd_direct != '-' " +
                    $"group by year,month";
            }
                    
            if (dataset == "old")
            {
                end_string = $" WHERE old_wd_direct != '-' " +
                    $"group by year,month";
                foreach (string direct in bd.WdDirects)
                {
                    select_cols_fre.Add($"(count(case when old_wd_direct == '{direct}' then 1 end) " +
                        $"/ cast (count(old_wd_direct) as double)) * 100 as {direct}");
                }  
            }
            result = $"select {string.Join(",", select_cols_fre)} " +
                $"from {table_name} {end_string}";
            return result;
        }

        public void SaveResult(string file_name)
        {
            wb.Save(file_name);
            sq.CloseDb();
        }
    }
}
