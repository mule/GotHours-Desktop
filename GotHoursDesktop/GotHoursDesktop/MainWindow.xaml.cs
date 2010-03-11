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
using System.Windows.Threading;

namespace GotHoursDesktop
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
        private MainWindowController _controller;
        private DispatcherTimer _timer;
        private DateTime _startTime;

        
		public MainWindow()
		{
			this.InitializeComponent();

            TrayMinimizer.EnableMinimizeToTray(this);

            _controller = new MainWindowController();
            _timer = new DispatcherTimer();
        

            this.Title += " - Hello " + _controller.CurrentUser.UserName;

            cbxTask.ItemsSource = _controller.ListOfTasks;

            _timer.Interval = new TimeSpan(0, 15, 0);
            _timer.Tick += new EventHandler(_timer_Tick);
            _startTime = DateTime.Now;
            _timer.Start();


           
         
		}

        void _timer_Tick(object sender, EventArgs e)
        {
            this.WindowState = WindowState.Normal;
            this.Activate();
        }

        private void btnLogTime_Click(object sender, RoutedEventArgs e)
        {
            String taskName = cbxTask.Text;
            _controller.LogTime(taskName, _startTime, DateTime.Now);
       

            txtPopUpLogTime.Text =
                String.Format(
                    @"Time logged for task: {0}
                                                   From {1} to {2}",
                    taskName, _startTime.ToShortTimeString(), DateTime.Now.ToShortTimeString());

            _startTime = DateTime.Now;
            popUpLogTime.IsOpen = true;

           

      
           
        }


	}
}