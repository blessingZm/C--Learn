using System.Data.SQLite;
using System.IO;
using System.Collections;
using System.Data.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace StationCompara
{
    class SqliteClass
    {
        public SQLiteConnection db;
        public DbTransaction trans;

        // 初始化，连接数据库
        public SqliteClass(string dbpath, string dbname)
        {
            string my_db = Path.Combine(dbpath, dbname);
            if (!File.Exists(my_db))
                SQLiteConnection.CreateFile(my_db);
            db = new SQLiteConnection($"Data Source={my_db}; Version=3");
            db.Open();
        }

        // 创建数据表, 表名，列名，各列的数据类型
        public void CreateTable(string table_name, List<string> columns, 
            List<string> col_datasets)
        {
            List<string> cols = new List<string>();
            for (int i = 0; i < columns.Count; i++)
            {
                string buf = columns[i] + " " + col_datasets[i];
                cols.Add(buf);
            }
            string col_string = String.Join(",", cols.ToArray());
            try
            {
                string sql = $"create table if not exists {table_name} " +
                $"({col_string})";
                SQLiteCommand command = new SQLiteCommand(sql, db);
                command.ExecuteNonQuery();
            }
            catch
            {
                db.Close();
                throw;
            }           
        }

        // 获得数据库中所有的table，返回由所有table_name组成的列表
        public List<string> GetTables()
        {
            List<string> tables = new List<string>();
            string sql = $"SELECT name FROM sqlite_master WHERE type = 'table'";
            SQLiteCommand command = new SQLiteCommand(sql, db);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                foreach (var re in reader.GetValues())
                    tables.Add(reader[re.ToString()].ToString());
            }
            return tables;
        }

        // 获得某个表中所有的列名，返回由所有列名组成的列表
        public List<string> GetColumns(string table_name)
        {
            List<string> columns = new List<string>();
            string sql = $"SELECT * FROM {table_name}";
            SQLiteCommand command = new SQLiteCommand(sql, db);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                foreach (var re in reader.GetValues())
                {
                    if (columns.Contains(re.ToString()))
                        break;
                    columns.Add(re.ToString());
                }
            }
            return columns;
        }

        //开启事务
        public void StartTrans()
        {
            trans = db.BeginTransaction();
        }

        //提交事务
        public void CommitTrans()
        {
            trans.Commit();
        }

        //插入数据,参数包括表名、列名及相应的数据
        public void InsertDatas(string table_name, List<string> columns, 
            ArrayList data)
        {
            string col_string = String.Join(",", columns.ToArray());
            string data_string = String.Join("','", data.ToArray());

            string sql = $"insert into {table_name} ({col_string}) " +
                $"values ('{data_string}')";
            try
            {
                SQLiteCommand command = new SQLiteCommand(sql, db);
                command.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                if (ex.ErrorCode != 19)
                    Debug.WriteLine(ex);
            } 
        }

        // 选择数据
        public SQLiteDataReader SelectDatas(string sql)
        {
            SQLiteCommand command = new SQLiteCommand(sql, db);
            SQLiteDataReader reader = command.ExecuteReader();
            return reader;
        }

        //断开连接
        public void CloseDb()
        {
            db.Close();
        }
    }
}
