using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Proje.Entities;
using System.Data;

namespace Proje
{
    public class Connector
    {
        private static Connector instance = null;
        private DBMS dbms;

        public DBMS Dbms
        {
            get { return dbms; }
            set { dbms = value; }
        }


        private Connector()
        {
        }

        public static Connector getInstance()
        {
            if (instance == null)
            {
                instance = new Connector();
            }
            
            return instance;
        }



        public void connect(string DBMS, string kadi, string sifre, string sunucu)
        {

            dbms = DBMSFactory.createDBMS(DBMS);
            dbms.connect(kadi, sifre,sunucu);
        }




    }
}
