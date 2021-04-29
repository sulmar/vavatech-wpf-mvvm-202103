using System;
using System.Collections.Generic;
using System.Text;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.ViewModels
{
    public class VirtualizingViewModel : BaseViewModel
    {
        private readonly ICustomerService customerService;

        public IEnumerable<Customer> Customers { get; set; }

        public VirtualizingViewModel(ICustomerService customerService)
        {
            this.customerService = customerService;

            Load();
        }

        private void Load()
        {
            Customers = customerService.Get();
        }
    }
}
