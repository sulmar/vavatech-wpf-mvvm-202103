using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Vavatech.Shop.ViewModels.Common
{

    // RelayCommand

    public class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action execute;
        private readonly Func<bool> canExecute; // Predicate

        public DelegateCommand(Action execute, Func<bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            // return canExecute == null ? true : canExecute.Invoke();

            return canExecute == null || canExecute.Invoke();
        }

        public void Execute(object parameter)
        {
            execute?.Invoke();
        }
    }
}
