using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;
using Vavatech.Shop.ViewModels.Common;

namespace Vavatech.Shop.ViewModels
{
    public class CustomerProductsViewModel : BaseViewModel
    {

        public Customer SelectedCustomer { get; set; }

        public ICommand NextCommand { get; private set; }
        public ICommand BackCommand { get; private set; }

        private readonly INavigationService navigationService;

        public CustomerProductsViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            NextCommand = new DelegateCommand(Next);
            BackCommand = new DelegateCommand(Back);

            SelectedCustomer = navigationService.Parameter as Customer;
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
