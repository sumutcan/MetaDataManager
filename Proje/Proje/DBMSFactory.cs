using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Proje.Entities;

namespace Proje
{
    public class DBMSFactory
    {
        public static DBMS createDBMS(string DBMS)
        {
            switch (DBMS)
            {
                case "MSSQL":
                    return new MSSQL();
                case "MYSQL":
                    return new MYSQL();
                default:
                    return null;
            }
        }
    }
}
