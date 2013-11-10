using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Proje.Entities;

namespace Proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBaglan_Click(object sender, EventArgs e)
        {
            try
            {
                Connector.getInstance().connect(cmbDBMS.Text, txtKadi.Text, txtSifre.Text, txtSunucu.Text);
               
                Connector.getInstance().Dbms.getDatabases();
                Connector.getInstance().Dbms.getTables();
                Connector.getInstance().Dbms.getColumns();

                foreach (Database db in Connector.getInstance().Dbms.Databases)
                {
                    TreeNode dbNode = new TreeNode(db.DbName);
                    tvDB.Nodes.Add(dbNode);

                    foreach (Table t in db.Tables)
                    {
                        TreeNode tableNode = new TreeNode(t.Name);
                        dbNode.Nodes.Add(tableNode);
                        foreach (Column c in t.Columns)
                        {
                            tableNode.Nodes.Add(c.ToString());
                        }
                            
                     
                    }
                    btnCreateXml.Visible = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreateXml_Click(object sender, EventArgs e)
        {
            try
            {
                XMLUtilizer util = new XMLUtilizer(Connector.getInstance().Dbms);
                util.createXMLFile();
                util.validate("dbms.xsd");
                MessageBox.Show("XML file has been created.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(null,ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }   


    }
}
