using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;

namespace StationCompara
{
    class StaticResult
    {
        public SQLiteConnection db;
        private BaseDatas bd = new BaseDatas();

        public StaticResult(string dbpath, string dbname)
        {
            string my_db = Path.Combine(dbpath, dbname);
            if (!File.Exists(my_db))
                SQLiteConnection.CreateFile(my_db);
            db = new SQLiteConnection($"Data Source={my_db}; Version=3");
            db.Open();
        }

        public List<List<string>> WdConincideceRate(string table_name)
        {
            List<List<string>> results = new List<List<string>>();

            string sql = $"SELECT strftime('%Y', datetime(meter_time)) as year, " +
                $"strftime('%m', datetime(meter_time)) as month, " +
                $"(count(case when (abs(wd_dif) < 22.5 or abs(wd_dif) > 337.5) then 1 end) / " +
                $"cast (count(wd_dif) as double)) * 100 as coin_rate " +
                $"FROM {table_name} WHERE new_wd <= 360 and old_wd <= 360 " +
                $"group by year,month";
            SQLiteCommand command = new SQLiteCommand(sql, db);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                List<string> buf = new List<string>
                {
                    reader["year"].ToString(),
                    reader["month"].ToString(),
                    Math.Round(Convert.ToDouble(reader["coin_rate"]), 1).ToString()
                };
                results.Add(buf);   
            }
            return results;
        }

        public List<List<string>> WdFrequency(string table_name, string col_name, string direct)
        {
            List<List<string>> results = new List<List<string>>();

            string sql = $"SELECT strftime('%Y', datetime(meter_time)) as year, " +
                $"strftime('%m', datetime(meter_time)) as month, " +
                $"(count(case when {col_name} == '{direct}' then 1 end) / " +
                $"cast (count({col_name}) as double)) * 100 as fre " +
                $"FROM {table_name} WHERE {col_name} != '-'" +
                $"group by year,month";

            SQLiteCommand command = new SQLiteCommand(sql, db);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                List<string> buf = new List<string>
                {
                    reader["year"].ToString(),
                    reader["month"].ToString(),
                    Math.Round(Convert.ToDouble(reader["fre"]), 
                    MidpointRounding.AwayFromZero).ToString()
                };
                results.Add(buf);
            }
            return results;
        }

        public void CloseDb()
        {
            db.Close();
            //db.Dispose();
            //GC.WaitForPendingFinalizers();
        }
    }
}
