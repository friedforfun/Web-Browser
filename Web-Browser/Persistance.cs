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
    class Persistance <T>
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

        public void Example()
        {
            try
            {
                XmlTextReader reader = new XmlTextReader(path);
                XmlSchema schema = XmlSchema.Read(reader, ValidationCallback);
                schema.Write(Console.Out);
                FileStream file = new FileStream("new.xsd", FileMode.Create, FileAccess.ReadWrite);
                XmlTextWriter xwriter = new XmlTextWriter(file, new UTF8Encoding());
                xwriter.Formatting = Formatting.Indented;
                schema.Write(xwriter);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void openWriteFileStream(FileMode mode)
        {
            //Mode enum: https://docs.microsoft.com/en-us/dotnet/api/system.io.filemode?view=netcore-3.1
            try
            {
                
            }
            catch(Exception e)
            {

            }
            
        }

        public void SerizalizeCollection(SortedList<string, T> collection)
        {
            try
            {
                using(xmlFile = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    var serializer = new DataContractSerializer(typeof(SortedList<string, T>));
                    using (XmlTextWriter xwriter = new XmlTextWriter(xmlFile, new UTF8Encoding()))
                    {
                        xwriter.Formatting = Formatting.Indented;
                        serializer.WriteObject(xwriter, collection);
                        Console.WriteLine("Should be written");
                        xwriter.Flush();
                    }
                        
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

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
