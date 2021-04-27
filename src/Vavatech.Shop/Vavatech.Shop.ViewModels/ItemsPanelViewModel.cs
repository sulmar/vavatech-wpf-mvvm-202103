using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.ViewModels
{
    public class ItemsPanelViewModel : BaseViewModel
    {
        private readonly ICustomerService customerService;

        public ICollection<Customer> Customers { get; set; }

        public ItemsPanelViewModel(ICustomerService customerService)
        {
            this.customerService = customerService;

            Load();
        }

        private void Load()
        {
            Customers = customerService.Get().Take(10).ToBindingList();
        }
    }
}
