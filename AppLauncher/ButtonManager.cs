using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace AppLauncher
{
    public class ButtonManager
    {
        private FileInfo FI = new FileInfo();
        private ProjectManager PM = new ProjectManager();
        private PathHandlerWindow PHW = new PathHandlerWindow();
        public float RowCount;

        public void CreateRefreshButton(string path, Grid myGrid)
        {
            System.Windows.Controls.Button button = new System.Windows.Controls.Button();
            System.Windows.Controls.Image img = new System.Windows.Controls.Image();
            img.Source = new BitmapImage(new Uri("/Images/refresh.png", UriKind.Relative));
            img.Width = 60;
            StackPanel stackPnl = new StackPanel();
            stackPnl.Children.Add(img);
            button.Content = stackPnl;

            RoutedEventHandler handler = (s, e) => PHW.Refresh(path, myGrid);
            button.Click += handler;

            myGrid.Children.Add(button);
            Grid.SetColumn(button, 4);
            Grid.SetRow(button, 0);
        }

        public void CreateButtons(List<string> names, Grid myGrid)
        {
            int currentX = 0;
            RowCount = names.Count / 7 + 1;
            int x = 0;
            for (int i = 7; i < names.Count+7; i++)
            {
                if (currentX >= 7)
                {
                    currentX = 0;
                }
                int y = i / 7;

                System.Windows.Controls.Button button = new System.Windows.Controls.Button();
                button.Tag = names[i-7];

                System.Windows.Controls.Image img = new System.Windows.Controls.Image();
                img.Source = FI.GetIcon(button.Tag.ToString()).ToImageSource();
                img.Width = 40;
                img.VerticalAlignment = VerticalAlignment.Top;


                System.Windows.Controls.TextBlock text = new System.Windows.Controls.TextBlock();
                text.Text = FI.GetName(button.Tag.ToString());
                text.FontWeight = FontWeights.Bold;
                text.VerticalAlignment = VerticalAlignment.Bottom;

                ContextMenu contextmenu = new ContextMenu();
                MenuItem mi1 = new MenuItem();
                MenuItem mi2 = new MenuItem();
                MenuItem mi3 = new MenuItem();
                mi1.Header = "Read Me";
                mi2.Header = "Relocate";
                mi3.Header = "Delete";
                RoutedEventHandler handlermi1 = (s, e) => PM.ReadMe(button.Tag.ToString());
                RoutedEventHandler handlermi2 = (s, e) => PM.Relocate(button.Tag.ToString());
                RoutedEventHandler handlermi3 = (s, e) => PM.Delete(button.Tag.ToString());

                mi1.Click += handlermi1;
                mi2.Click += handlermi2;
                mi3.Click += handlermi3;

                contextmenu.Items.Add(mi1);
                contextmenu.Items.Add(mi2);
                contextmenu.Items.Add(mi3);

                StackPanel stackPnl = new StackPanel();
                /*stackPnl.Orientation = System.Windows.Controls.Orientation.Horizontal;
                stackPnl.Margin = new Thickness(10);*/
                stackPnl.Children.Add(img);
                stackPnl.Children.Add(text);

                button.Content = stackPnl;
                RoutedEventHandler handler = (s, e) => StartFile(button.Tag.ToString());
                button.Click += handler;
                button.ContextMenu = contextmenu;

                myGrid.Children.Add(button);
                Grid.SetColumn(button, currentX);
                Grid.SetRow(button, y);
                currentX++;

            }
        }

        protected void StartFile(string path)
        {
            string newPath = FI.GetExe(path);
            System.Diagnostics.Process.Start(newPath);
        }
    }
}
