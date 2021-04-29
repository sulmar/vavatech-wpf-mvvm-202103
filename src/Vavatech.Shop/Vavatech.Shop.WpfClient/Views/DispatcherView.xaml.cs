using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Vavatech.Shop.WpfClient.Views
{
    /// <summary>
    /// Interaction logic for DispatcherView.xaml
    /// </summary>
    public partial class DispatcherView : Page
    {
        private System.Timers.Timer timer;

        // https://docs.microsoft.com/pl-pl/dotnet/api/system.windows.threading.dispatchertimer?view=net-5.0
        private DispatcherTimer dispatcherTimer;

        public DispatcherView()
        {
            InitializeComponent();

            Trace.WriteLine($"DispatcherView {Thread.CurrentThread.ManagedThreadId}");

            var measures = Enumerable.Range(1, 1000);

            // Task.Run(() => Calculate(measures));

            //timer = new System.Timers.Timer(TimeSpan.FromSeconds(1).TotalMilliseconds);
            //timer.Elapsed += Timer_Elapsed;
            //timer.Enabled = true;


            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Start();


        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            StatusTextBlock.Text = $"{DateTime.Now.ToString()}";
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                StatusTextBlock.Text = $"{DateTime.Now.ToString()}";
            }));
        }

        private void Calculate(IEnumerable<int> measures)
        {
            foreach (var measure in measures)
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    StatusTextBlock.Text = $"#{Thread.CurrentThread.ManagedThreadId} Calculating {measure}...";
                }));

                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }

    }
}
