using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using net.r_eg.MvsSln;
using net.r_eg.MvsSln.Core;
using net.r_eg.MvsSln.Core.SlnHandlers;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using Microsoft.Build.BuildEngine;
namespace AppLauncher
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public FileInfo FI = new FileInfo();
        public ButtonManager BM = new ButtonManager();
        public List<string> names = new List<string>();
        public string FolderPath;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FolderPathButton(object sender, RoutedEventArgs e)
        {
            PathHandlerWindow PHW = new PathHandlerWindow();
            PHW.Search(myGrid);
        }      
    }
}
