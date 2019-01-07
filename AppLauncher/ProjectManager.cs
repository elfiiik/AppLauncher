using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLauncher
{
    public class ProjectManager
    {
        public void ReadMe(string path)
        {
            string newPath = System.IO.Path.GetDirectoryName(path);
            string dir = newPath;
            newPath += "//README.md";
            if (!File.Exists(newPath))
            {
                File.Create(newPath);
            }
            Process.Start(newPath);
        }

        public void Relocate(string path)
        {
            PathHandler PH = new PathHandler();
            string newPath = PH.GetPath("Select new folder for project");
            if (newPath != "")
            {
                string orig = Path.GetDirectoryName(path);
                orig = Directory.GetParent(orig).ToString();
                DirectoryInfo dir_info = new DirectoryInfo(orig);
                string origDirName = dir_info.Name;

                newPath += "\\" + origDirName;

                foreach (string dirPath in Directory.GetDirectories(orig, "*",
                    SearchOption.AllDirectories))
                    Directory.CreateDirectory(dirPath.Replace(orig, newPath));

                foreach (string njuPath in Directory.GetFiles(orig, "*",
                    SearchOption.AllDirectories))
                    File.Copy(njuPath, njuPath.Replace(orig, newPath), true);
                Directory.Delete(orig, true);
            }      
        }

        public void Delete(string path)
        {
            string newPath = Path.GetDirectoryName(path);
            newPath = Directory.GetParent(newPath).ToString();
            Directory.Delete(newPath, true);
        }
    }
}
