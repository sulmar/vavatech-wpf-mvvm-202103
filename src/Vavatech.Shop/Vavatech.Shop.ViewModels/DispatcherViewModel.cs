using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Vavatech.Shop.IServices;

namespace Vavatech.Shop.ViewModels
{
    public class DispatcherViewModel : BaseViewModel
    {
        private double voltage;
        public double Voltage
        {
            get => voltage; set
            {
                voltage = value;
                OnPropertyChanged();
            }
        }

        private readonly IMeasureService measureService;


        private System.Timers.Timer timer;

        private System.Threading.Timer timer2;
        private string status;

        public DispatcherViewModel(IMeasureService measureService)
        {
            this.measureService = measureService;

            //timer = new Timer(TimeSpan.FromSeconds(1).TotalMilliseconds);
            //timer.Elapsed += Timer_Elapsed;
            //timer.Enabled = true;

            //timer2 = new System.Threading.Timer(
            //    callback: new TimerCallback(TimerTask),
            //    state: this,
            //    dueTime: 1000,
            //    period: 2000
            //    );

            //var measures = Enumerable.Range(1, 1000);

            //Task.Run(() => Calculate(measures));

        }

        public string Status
        {
            get => status; set
            {
                status = value;
                OnPropertyChanged();
            }
        }

        private void Calculate(IEnumerable<int> measures)
        {
            foreach (var measure in measures)
            {                
                Status = $"#{Thread.CurrentThread.ManagedThreadId} Calculating {measure}...";

                

                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }

        private static void TimerTask(object timerState)
        {
            var vm = timerState as DispatcherViewModel;

            Trace.WriteLine(Thread.CurrentThread.ManagedThreadId);

            vm.Voltage = vm.measureService.Get();
        }

        //private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        //{
        //    Voltage = measureService.Get();
        //}
    }
}
