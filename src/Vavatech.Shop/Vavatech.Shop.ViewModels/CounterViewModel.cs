using System;
using System.Collections.Generic;
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

        public void Add()
        {
            Counter++;
        }

        public bool CanAdd() => Counter < 110;

    }
}
