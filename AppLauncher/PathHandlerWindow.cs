using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
namespace AppLauncher
{
    class PathHandlerWindow
    {

        /*public string GetPath()
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Core.FileDialog fileDialog = app.get_FileDialog(Microsoft.Office.Core.MsoFileDialogType.msoFileDialogFolderPicker);
            fileDialog.InitialFileName = "c:\\Temp\\"; 
            int nres = fileDialog.Show();
            if (nres == -1) //ok
            {
                Microsoft.Office.Core.FileDialogSelectedItems selectedItems = fileDialog.SelectedItems;

                string[] selectedFolders = selectedItems.Cast<string>().ToArray();

                if (selectedFolders.Length > 0)
                {
                    string selectedFolder = selectedFolders[0];
                    return selectedFolder;
                }
            }
            return "";
        }*/

        public void Search(Grid myGrid)
        {
            PathHandler PH = new PathHandler();
            string FolderPath = PH.GetPath("Select folder with projects");
            if (FolderPath != "")
            {
                CsprojektHandler CsH = new CsprojektHandler();
                List<string> names = CsH.GetFileNames(FolderPath);
                ButtonManager BM = new ButtonManager();
                BM.CreateRefreshButton(FolderPath, myGrid);
                BM.CreateButtons(names, myGrid);
            }
        }

        public void Refresh(string path, Grid myGrid)
        {
            for (int i = 0; i < myGrid.Children.Count; i++)
            {
                if (i > 2)
                {
                    myGrid.Children.RemoveAt(i);
                }
            }
            CsprojektHandler CsH = new CsprojektHandler();
            List<string> names = CsH.GetFileNames(path);
            ButtonManager BM = new ButtonManager();
            BM.CreateButtons(names, myGrid);
        }
    }
}
