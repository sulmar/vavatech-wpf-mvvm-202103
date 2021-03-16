using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Vavatech.Shop.ViewModels.Common;

namespace Vavatech.Shop.ViewModels
{
    public class CounterViewModel : BaseViewModel
    {
        public int Counter { get; set; }

        public ICommand AddCommand { get; private set; }

        public CounterViewModel()
        {
            AddCommand = new DelegateCommand(Add);
        }

        public void Add()
        {
            Counter++;
        }

      
       
    }
}
