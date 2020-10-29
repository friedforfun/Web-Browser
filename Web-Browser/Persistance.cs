using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Reflection;

namespace Web_Browser
{
    public sealed class Persistance <T>
    {
        private string filename;
        private string rootPath;
        private string path => string.Format("{0}\\{1}.xml", rootPath, filename);
        private FileStream xmlFile;

        public Persistance(string name)
        {
            rootPath = Application.StartupPath;
            filename = name;
        }

        public void SerializeCollection(List<T> collection)
        {
            try
            {
                using(xmlFile = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    var serializer = new DataContractSerializer(typeof(List<T>));
                    using (XmlTextWriter xwriter = new XmlTextWriter(xmlFile, new UTF8Encoding()))
                    {
                        xwriter.Formatting = Formatting.Indented;
                        serializer.WriteObject(xwriter, collection);
                        Console.WriteLine("Write To XML");
                        xwriter.Flush();
                    }
                        
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public List<T> DeserializeCollection()
        {
            List<T> list;
            try
            {
                using (xmlFile = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    var serializer = new DataContractSerializer(typeof(List<T>));
                    using (XmlTextReader xreader = new XmlTextReader(xmlFile))
                    {
                        //xreader.Formatting = Formatting.Indented;
                        //serializer.WriteObject(xreader, collection);
                        list = (List<T>)serializer.ReadObject(xreader);
                        Console.WriteLine("Read from XML");
                        return list;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        private static void ValidationCallback(object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Warning)
                Console.Write("WARNING: ");
            else if (args.Severity == XmlSeverityType.Error)
                Console.Write("ERROR: ");

            Console.WriteLine(args.Message);
        }

    }
}
