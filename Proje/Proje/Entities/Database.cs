using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Xml.Serialization;

namespace Proje.Entities
{
    public class Database
    {
        string dbName;

        [XmlAttribute("name")]
        public string DbName
        {
            get { return dbName; }
            set { dbName = value; }
        }
        List<Table> tables;

        public List<Table> Tables
        {
            get { return tables; }
            
        }

        public Database(string name)
        {
            dbName = name;
            tables = new List<Table>();
        }

        public Database()
        {
            tables = new List<Table>();
        }





    
    }
}
