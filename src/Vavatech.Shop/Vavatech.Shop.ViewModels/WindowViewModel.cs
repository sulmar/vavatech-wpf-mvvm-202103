using System;
using System.Collections.Generic;
using System.Text;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.ViewModels
{
    public class WindowViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        private readonly ICustomerService customerService;

        public Customer SelectedCustomer { get; set; }

        public WindowViewModel(INavigationService navigationService, ICustomerService customerService)
        {
            this.navigationService = navigationService;
            this.customerService = customerService;
            Load();
        }

        private void Load()
        {
            int customerId = (int)navigationService.Parameter;

            SelectedCustomer = customerService.Get(customerId);
        }
    }
}
