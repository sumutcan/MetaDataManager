using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proje.Entities
{
    class MYSQL : DBMS
    {
        public override void getDatabases()
        {
            throw new NotImplementedException();
        }

        public override void getTables()
        {
            throw new NotImplementedException();
        }

        public override void connect(string kadi, string sifre, string sunucu)
        {
            base.Name = "MYSQL";
        }

        public override void getColumns()
        {
            throw new NotImplementedException();
        }
    }
}
