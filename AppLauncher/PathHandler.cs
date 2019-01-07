using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace AppLauncher
{
    class PathHandler : Form
    { 
        public string GetPath(string des)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            //fbd.RootFolder = Environment.SpecialFolder.Desktop;
            fbd.SelectedPath = @"C:\Users\admin\source\repos";
            fbd.Description = des;
            fbd.ShowNewFolderButton = false;

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                return fbd.SelectedPath;
            }
            return "";
        }
    }
}
