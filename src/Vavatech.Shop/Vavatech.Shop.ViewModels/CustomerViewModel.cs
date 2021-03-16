using Bogus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;
using Vavatech.Shop.ViewModels.Common;

namespace Vavatech.Shop.ViewModels
{
    public class CustomerViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;

        public Customer SelectedCustomer { get; set; }

        public ICommand NextCommand { get; private set; }
        public ICommand BackCommand { get; private set; }

        public CustomerViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            NextCommand = new DelegateCommand(Next);
            BackCommand = new DelegateCommand(Back);

            SelectedCustomer = new Customer() { CustomerType = CustomerType.Smily };
        }

        public void Next()
        {
            navigationService.Navigate("CustomerProducts", SelectedCustomer);
        }

        public void Back()
        {
            navigationService.GoBack();
        }
    }
}
