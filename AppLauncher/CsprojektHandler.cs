using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace AppLauncher
{
    class CsprojektHandler
    {
        private FileInfo FI = new FileInfo();
        private List<string> fileNames = new List<string>();

        public List<string> GetFileNames(string path)
        {
            foreach (string data in Directory.GetFiles(path, "*.csproj", SearchOption.AllDirectories))
            {
                if (File.Exists(FI.GetExe(data))) //kontrola, zda existuje exe soubor
                {
                    fileNames.Add(data);
                }
                
            }
            return fileNames;
        } 
    }
}
