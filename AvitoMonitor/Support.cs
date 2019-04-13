using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using CsQuery;

namespace AvitoMonitor{
    internal static class Support {
        public static void CreationOfDataBase(string WAY) { 
            if (!System.IO.File.Exists(WAY)) {
                SQLiteConnection.CreateFile(WAY);
                using (SQLiteConnection connection = new SQLiteConnection(@"Data Source=AvitoMonitor.db; Version=3;")){
                    string commandText = "CREATE TABLE [AvitoMonitor] ( " +
                        //"[id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, " +
                        "[name] CHAR(200) NOT NULL, " +
                        "[city] CHAR(100) NOT NULL, " +
                        "[time] CHAR(50) NOT NULL, " +
                        "[type] CHAR(500) NOT NULL, " +
                        "[image] BLOB, " +
                        "[image_format] VARCHAR(10), " +
                        "[image_name] NVARCHAR(128)" +
                        ")";
                    SQLiteCommand Command = new SQLiteCommand(commandText, connection);
                    connection.Open(); 
                    Command.ExecuteNonQuery(); 
                    connection.Close(); 
                }
            } 
        }
        public static void CreationOfDirectory(string PATHtoIMG) { 
            if (!Directory.Exists(PATHtoIMG)) {
                DirectoryInfo directoryInfo = new DirectoryInfo(PATHtoIMG);
                directoryInfo.Create();
            } 
        }
    }
}
