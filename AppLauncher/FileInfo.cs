using System;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AppLauncher
{
    public class FileInfo
    {
        public XElement output;
        public XElement name;
        public string GetExe(string path)
        {
            string newPath = System.IO.Path.GetDirectoryName(path) + "\\";
            XDocument doc = XDocument.Parse(File.ReadAllText(path, Encoding.UTF8));

            foreach (XNode node in doc.DescendantNodes())
            {
                if (node is XElement)
                {
                    XElement element = (XElement)node;
                    if (element.Name.LocalName.Equals("AssemblyName"))
                    {
                        name = element;
                    }
                    if (element.Name.LocalName.Equals("OutputPath"))
                    {
                        output = element;
                        newPath += output.Value + name.Value + ".exe";
                        return newPath;
                    }

                }
            }
            return "";
            //Xelement output obsahuje bin/debug, xelement name obsahuje jméno "AppLauncher"
        }

        public Icon GetIcon(string path)
        {
            string newPath = GetExe(path);
            Icon icon = Icon.ExtractAssociatedIcon(newPath);
            return icon;
        }

        public string GetName(string path)
        {
            string newPath = System.IO.Path.GetDirectoryName(path) + "\\";
            XDocument doc = XDocument.Parse(File.ReadAllText(path, Encoding.UTF8));

            foreach (XNode node in doc.DescendantNodes())
            {
                if (node is XElement)
                {
                    XElement element = (XElement)node;
                    if (element.Name.LocalName.Equals("AssemblyName"))
                    {
                        name = element;
                        return name.Value;
                    }
                }
            }
            return "";
        }
    }
}
