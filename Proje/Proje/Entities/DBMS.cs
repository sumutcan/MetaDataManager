using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Proje.Entities
{
    
    public abstract class DBMS
    {
        private string name;

        [XmlAttribute("name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private List<Database> databases;

        public List<Database> Databases
        {
            get { return databases; }
            
        }

        public DBMS(string name)
        {
            this.databases = new List<Database>();
            this.name = name;
        }

        public DBMS()
        {
            this.databases = new List<Database>();
        }

        public abstract void getDatabases();
        public abstract void getTables();
        public abstract void connect(string kadi, string sifre, string sunucu);

    }
}
