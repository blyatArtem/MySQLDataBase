using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Asn1.Esf;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Text;

namespace MySQLDataBase
{
    internal static class DataBase
    {
        public static void Initialize(string hostname, string database, string user = "root", string password = "")
        {
            sqlConnection = new MySqlConnection($"Server={hostname};Port=3306;Database={database};Uid={user};Pwd={password}");
            sqlConnection.StateChange += SqlConnection_StateChange;
        }

        public static bool Open()
        {
            try
            {
                sqlConnection.Open();
                return true;
            }
            catch { }
            return false;
        }

        public static bool RunCommand(string commandStr, out SQLTable table)
        {
            table = new SQLTable();
            try
            {
                MySqlCommand commandSql = new MySqlCommand(commandStr, sqlConnection);
                table.ExecuteAndRead(commandSql);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static void SqlConnection_StateChange(object sender, StateChangeEventArgs e)
        {
            //e.CurrentState;
        }

        public static string DateTimeToString(DateTime time)
        {
            return $"{time.ToString("yyyy:MM:dd").Replace(":", "-")} {time.ToString("HH:mm:ss")}";
        }

        public static readonly string tableSchema = "users", tableName = "userList";

        private static MySqlConnection sqlConnection;

    }
}
