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

        public override void getColumns()
        {
            foreach (Database d in Databases)
            {
                foreach (Table t in d.Tables)
                {
                    DataTable dt = getConnection().GetSchema("Columns", new[] { d.DbName, "dbo", t.Name });
                    foreach (DataRow dr in dt.Rows)
                    {
                        Column c = new Column();
                        c.Name = dr.ItemArray[3].ToString();
                        c.Datatype = dr.ItemArray[7].ToString();

                        if (dr.ItemArray[6].ToString() == "YES")
                            c.Nullable = true;
                        else
                            c.Nullable = false;
                        
                        t.Columns.Add(c);
                    }
                }
            }
        }
    }

}
