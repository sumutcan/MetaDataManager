using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Proje.Entities
{
    public class Column
    {
        private string name;
        private string datatype;

        [XmlElement("datatype")]
        public string Datatype
        {
            get { return datatype; }
            set { datatype = value; }
        }
        private bool nullable;

        [XmlElement("nullable")]
        public bool Nullable
        {
            get { return nullable; }
            set { nullable = value; }
        }

        [XmlAttribute("name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Column()
        { 
            
        }
        public override string ToString()
        {
            return Name + " - " + datatype + " - Nullable: " + Nullable;
        }
    }
}
