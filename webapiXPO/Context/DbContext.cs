using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using System.Diagnostics;
using System;

namespace webapiXPO.Context
{
    public class DbContext
    {
        public static UnitOfWork Production()
        {
            string connectionString = SQLiteConnectionProvider.GetConnectionString("C:\\Users\\anton\\source\\repos\\webapiXPO\\webapiXPO\\webapidb.db");
            XpoDefault.DataLayer = XpoDefault.GetDataLayer(connectionString, AutoCreateOption.DatabaseAndSchema);
            UnitOfWork uow = new UnitOfWork();
            return uow;
        }
    }
}
