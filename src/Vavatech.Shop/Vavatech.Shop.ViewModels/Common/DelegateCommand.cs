using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Vavatech.Shop.ViewModels.Common
{

    public interface IDelegateCommand : ICommand
    {
        void OnCanExecuteChanged();
    }

    // RelayCommand

    public class DelegateCommand : IDelegateCommand
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

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }


    public class DelegateCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action<T> execute;
        private readonly Func<T, bool> canExecute; // Predicate

        public DelegateCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            // return canExecute == null ? true : canExecute.Invoke();

            return canExecute == null || canExecute.Invoke((T) parameter);
        }

        public void Execute(object parameter)
        {
            execute?.Invoke((T) parameter);
        }

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
