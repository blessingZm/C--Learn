using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xmldoc = new XmlDocument();

            String xmlFile = @"G:\C#\objects\Test\Test\ArchiveConfig.xml";
            xmldoc.Load(xmlFile);

            XmlNodeList fileNodes = xmldoc.GetElementsByTagName("FileParameters");
            fileNodes[0].RemoveAll();

           
            for (int i = 0; i < 10; i++)
            {
                XmlElement newnode = xmldoc.CreateElement("Parameter");
                newnode.SetAttribute("FileState", "1");
                newnode.SetAttribute("FileType", "111");
                fileNodes[0].AppendChild(newnode);
            }        
            
            /*
            XmlNodeList fileConfig = xmldoc.GetElementsByTagName("Parameter");
            int i = 0;
            while(i < fileConfig.Count)
            {
                XmlNode xn = fileConfig[i];
                XmlElement xe = (XmlElement)xn;
                if (xe.GetAttribute("FileState") == "0")
                {
                    xmldoc.RemoveChild(xn);
                }
                else
                {
                    i++;
                }
            }
            */
            xmldoc.Save(@"G:\C#\objects\Test\Test\ArchiveConfig1.xml");
        }
    }
}
