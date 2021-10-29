using AppMvvmProducts.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]

namespace AppMvvmProducts.Data
{
    public class SQLite_Android : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var dbName = "ContactDB.sqlite";
            var dbPath = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(dbPath, dbName);
            SQLiteConnection conn = new SQLiteConnection(path);
            return conn;
        }
    }
}
