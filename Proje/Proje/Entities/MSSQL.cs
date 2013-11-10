using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Serialization;

namespace Proje.Entities
{
    [XmlRoot("DBMS")]
    public class MSSQL : DBMS
    {
        private SqlConnection cn;
        public override void getDatabases()
        {
            DataTable dt = getConnection().GetSchema("Databases");
            foreach (DataRow dr in dt.Rows)
            {
                base.Databases.Add(new Database(dr.ItemArray[0].ToString()));
            }
        }

        public override void connect(string kadi, string sifre, string sunucu)
        {
            string connectionString = string.Format("Data Source={0};User ID={1};password={2};", sunucu, kadi, sifre);
            cn = new SqlConnection(connectionString);
            cn.Open();
            base.Name = "MSSQL";
        }

        public SqlConnection getConnection()
        {
            return cn;
        }


        public override void getTables()
        {
            foreach (Database d in Databases)
            {
                getConnection().ChangeDatabase(d.DbName);
                DataTable dt = getConnection().GetSchema("Tables");
                foreach (DataRow dr in dt.Rows)
                    d.Tables.Add(new Table(dr.ItemArray[2].ToString()));
            }
        }
    }

}
