using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Vavatech.Shop.ViewModels.Common;

namespace Vavatech.ViewModelFirst.WpfClient.ViewModels
{

    public class ShellViewModel : BaseViewModel
    {
        private BaseViewModel selectedViewModel;
        private readonly ViewModelLocator viewModelLocator;

        // public ICommand ShowFirstViewCommand { get; private set; }
        // public ICommand ShowSecondViewCommand { get; private set; }


        public ICommand ShowFirstViewCommand => commandManager.Bind(ShowFirst);
        public ICommand ShowSecondViewCommand => commandManager.Bind(ShowSecond);


        private CommandManager commandManager;

        public string SelectedViewModelName { get; set; }

        //private ICommand _ShowFirstViewCommand;
        //public ICommand ShowFirstViewCommand
        //{
        //    get
        //    {
        //        if (_ShowFirstViewCommand == null)
        //        {
        //            _ShowFirstViewCommand = new DelegateCommand(ShowFirst);
        //        }

        //        return _ShowFirstViewCommand;
        //    }
        //}




        public ICollection<BaseViewModel> ViewModels { get; set; }

        public BaseViewModel SelectedViewModel
        {
            get => selectedViewModel; set
            {
                selectedViewModel = value;
                OnPropertyChanged();
            }
        }

        public ShellViewModel()
            : this(new ViewModelLocator(), new CommandManager())
        {

        }

        public ShellViewModel(ViewModelLocator viewModelLocator, CommandManager commandHelper)
        {
            // ShowFirstViewCommand = new DelegateCommand(ShowFirst);
            // ShowSecondViewCommand = new DelegateCommand(ShowSecond);

            this.commandManager = commandHelper;
         
            this.viewModelLocator = viewModelLocator;

            ViewModels = new List<BaseViewModel>();

            ViewModels.Add(viewModelLocator.FirstViewModel);
            ViewModels.Add(viewModelLocator.SecondViewModel);

            ShowFirst();
        }

        public void ShowFirst()
        {
            SelectedViewModel = viewModelLocator.FirstViewModel;
        }

        private void ShowSecond()
        {
            SelectedViewModel = viewModelLocator.SecondViewModel;
        }
    }
}
