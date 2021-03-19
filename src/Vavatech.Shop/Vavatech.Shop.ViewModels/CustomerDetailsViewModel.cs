using System;
using System.Collections.Generic;
using System.Text;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.ViewModels
{
    public class CustomerDetailsViewModel : BaseViewModel
    {
        private readonly ICustomerService customerService;

        public Customer Customer { get; set; }

        public CustomerDetailsViewModel(ICustomerService customerService, IMessageBoxService messageBoxService)
        {
            this.customerService = customerService;

            Customer = messageBoxService.Parameter as Customer;
        }
    }
}
