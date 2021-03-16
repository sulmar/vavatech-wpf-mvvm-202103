using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Vavatech.Shop.ViewModels.Common;

namespace Vavatech.Shop.ViewModels
{
    public class CounterViewModel : BaseViewModel
    {
        private int counter;

        public int Counter
        {
            get => counter; set
            {
                counter = value;

                OnPropertyChanged();

                AddCommand.OnCanExecuteChanged();
            }
        }

        public DelegateCommand AddCommand { get; private set; }

        public CounterViewModel()
        {
            AddCommand = new DelegateCommand(Add, CanAdd);

            Counter = 100;
        }

        // [Timer]
        public void Add()
        {
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();

            Counter++;

            stopWatch.Stop();

            Trace.WriteLine($"{stopWatch.ElapsedMilliseconds} ms");
        }

        public bool CanAdd() => Counter < 110;

    }
}
