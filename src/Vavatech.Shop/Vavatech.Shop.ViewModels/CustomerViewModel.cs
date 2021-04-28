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
        private readonly ICustomerService customerService;

        public Customer SelectedCustomer { get; set; }

        public ICommand NextCommand { get; private set; }
        public ICommand BackCommand { get; private set; }

        public CustomerViewModel(INavigationService navigationService, ICustomerService customerService)
        {
            this.navigationService = navigationService;
            this.customerService = customerService;
            NextCommand = new DelegateCommand(Next);
            BackCommand = new DelegateCommand(Back);

            Load();
        }

        private void Load()
        {
            int customerId = (int)navigationService.Parameter;

            SelectedCustomer = customerService.Get(customerId);
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
