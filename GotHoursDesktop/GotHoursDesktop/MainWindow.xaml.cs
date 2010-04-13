using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace GotHoursDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
     


        private MainWindowController _controller;



        public MainWindow()
        {
            this.InitializeComponent();
            _controller = new MainWindowController();
            TrayMinimizer.EnableMinimizeToTray(this);



            TaskView.CurrentUser = _controller.CurrentUser;




        }




        private void btnActivity_Click(object sender, RoutedEventArgs e)
        {
            if (pnlTaskView.Visibility == System.Windows.Visibility.Collapsed)
                pnlTaskView.Visibility = System.Windows.Visibility.Visible;
            else
            {
                pnlTaskView.Visibility = System.Windows.Visibility.Collapsed;
            }

        }

    }
}