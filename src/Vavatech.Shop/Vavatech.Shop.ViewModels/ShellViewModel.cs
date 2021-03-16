using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Vavatech.Shop.IServices;
using Vavatech.Shop.ViewModels.Common;

namespace Vavatech.Shop.ViewModels
{
    public class ShellViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        private readonly IMessageBoxService messageBoxService;
        private readonly IApplicationService applicationService;

        public ICommand ExitCommand { get; private set; }

        public ICommand ShowViewCommand { get; private set; }

        //public ICommand ShowCustomersCommand { get; private set; }
        //public ICommand ShowProductsCommand { get; private set; }
        //public ICommand ShowCounterCommand { get; private set; }

        public ShellViewModel(
            INavigationService navigationService,
            IMessageBoxService messageBoxService, 
            IApplicationService applicationService)
        {
            ExitCommand = new DelegateCommand<CancelEventArgs>(Exit);

            ShowViewCommand = new DelegateCommand<string>(ShowView);

            //ShowCustomersCommand = new DelegateCommand(ShowCustomers);
            //ShowProductsCommand = new DelegateCommand(ShowProducts);
            //ShowCounterCommand = new DelegateCommand(ShowCounter);

            this.navigationService = navigationService;
            this.messageBoxService = messageBoxService;
            this.applicationService = applicationService;
        }

        public void ShowView(string viewName)
        {
            navigationService.Navigate(viewName);
        }

        //public void ShowCustomers()
        //{
        //    navigationService.Navigate("Customers");
        //}

        //public void ShowCounter()
        //{
        //    navigationService.Navigate("Counter");
        //}

        //public void ShowProducts()
        //{
        //    navigationService.Navigate("Products");
        //}

        public void Exit(CancelEventArgs args)
        {
            if (messageBoxService.ShowMessage("Are you sure?", "Exit"))
            {
                applicationService.Close();
            }
            else
            {
                args.Cancel = true;
            }



        }
    }
}
