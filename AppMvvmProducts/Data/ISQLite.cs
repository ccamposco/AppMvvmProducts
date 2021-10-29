using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppMvvmProducts.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
