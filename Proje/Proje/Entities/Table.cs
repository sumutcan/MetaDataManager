using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Proje.Entities
{
    public class Table
    {
        string name;

        [XmlAttribute("name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Table(string name)
        {
            // TODO: Complete member initialization
            this.name = name;
        }

        public Table()
        { 
        
        }
    }
}
