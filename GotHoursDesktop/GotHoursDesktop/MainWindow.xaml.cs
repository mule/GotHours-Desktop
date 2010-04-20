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
using System.Diagnostics;


namespace GotHoursDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public static readonly RoutedEvent ShowTimelogEvent =
            EventManager.RegisterRoutedEvent("ShowTimeLog",
            RoutingStrategy.Tunnel,
            typeof(RoutedEventHandler),
            typeof(MainWindow));




        private MainWindowController _controller;



        public MainWindow()
        {
            this.InitializeComponent();
            _controller = new MainWindowController();
            TrayMinimizer.EnableMinimizeToTray(this);



            TaskView.CurrentUser = _controller.CurrentUser;




        }


        public event RoutedEventHandler ShowTimeLog
        {
            add { AddHandler(ShowTimelogEvent, value); }
            remove { RemoveHandler(ShowTimelogEvent, value); }
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


        private void pnlRoot_TimeLogged(object sender, RoutedEventArgs e)
        {
            Trace.TraceInformation("TaskView caught TimeLogged Event");

            this.TaskView.RefreshData();

        }

        private void pnlRoot_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Trace.TraceInformation("pnlRoot caught SelectedItemChanged routed event");

            

            if (e.NewValue.GetType() == typeof(ViewModel.TimeLogViewModel))
            {
                var tlog = (ViewModel.TimeLogViewModel) e.NewValue;
                this.pnllTimeLogDetail.Visibility = System.Windows.Visibility.Visible;
                this.viewTimelogDetail.SetViewToTimeLog(tlog.Id);                
                

            }


        }

    }
}