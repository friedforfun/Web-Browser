using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Windows.Forms;

namespace Web_Browser
{
    class Persistance
    {
        private string filename;
        private string rootPath;

        public Persistance(string name)
        {
            rootPath = Application.StartupPath;
            this.filename = name;
        }

        public void Example()
        {
            try
            {
                XmlTextReader reader = new XmlTextReader(getPath());
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

        private string getPath()
        {

            return string.Format("{0}\\{1}.xsd", rootPath, filename);
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
