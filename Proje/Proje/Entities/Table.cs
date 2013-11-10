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
            columns = new List<Column>();
        }

        private List<Column> columns;

        public List<Column> Columns
        {
            get { return columns; }
            set { columns = value; }
        }

        public Table()
        {
            columns = new List<Column>();
        }
    }
}
