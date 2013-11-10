using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using Proje.Entities;
using System.Xml.Serialization;
using System.Xml.Schema;

namespace Proje
{
    public class XMLUtilizer
    {
        private DBMS dbms;

        public XMLUtilizer(DBMS dbms)
        {
            this.dbms = dbms;
        }

        public void validate(string filename)
        {
            System.IO.FileStream fs = null;

            try
            {
               
                XmlSchemaSet schemaSet = new XmlSchemaSet();
                
                schemaSet.Add(null,filename);

                XmlSchema compiledSchema = null;

                foreach (XmlSchema schema in schemaSet.Schemas())
                {
                    compiledSchema = schema;
                }

                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Schemas.Add(compiledSchema);
                settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
                settings.ValidationType = ValidationType.Schema;

                //Create the schema validating reader.
                XmlReader vreader = XmlReader.Create(dbms.Name+".xml", settings);

                while (vreader.Read()) { }

                //Close the reader.
                vreader.Close();
            }
            catch (System.IO.FileNotFoundException)
            {
                throw new Exception("Specified file was not found.");
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while XML was being validated: " + ex.Message);
            }
            finally {
                
                if (fs != null)
                    fs.Close();
            }
        }

        public void createXMLFile()
        {
       
            System.IO.FileStream fs = new System.IO.FileStream(dbms.Name+".xml", System.IO.FileMode.Create);
            XmlTextWriter xmlWriter = new XmlTextWriter(fs,System.Text.Encoding.UTF8) { Formatting=Formatting.Indented};
            XmlSerializer serializer = new XmlSerializer(dbms.GetType());
            serializer.Serialize(xmlWriter, dbms);
            xmlWriter.Close();
           
 
            
        }

        private static void ValidationCallBack(object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Warning)
                throw new Exception("\tWarning: Matching schema not found.  No validation occurred." + args.Message);
            else
                throw new Exception("\tValidation error: " + args.Message);

        }
    }
}
