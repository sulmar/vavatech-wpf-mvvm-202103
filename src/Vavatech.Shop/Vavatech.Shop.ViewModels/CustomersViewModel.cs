using System;
using System.Collections.Generic;
using System.Linq;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.ViewModels
{

    public class CustomersViewModel : BaseViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }

        public decimal TotalCreditAmount => Customers
            .Where(c=>c.CreditAmount.HasValue)
            .Sum(c => c.CreditAmount.Value);

        public Customer SelectedCustomer
        {
            get => selectedCustomer; set
            {
                selectedCustomer = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<CustomerType> CustomerTypes { get; set; }

        private readonly ICustomerService customerService;
        private Customer selectedCustomer;

        public CustomersViewModel(ICustomerService customerService)
        {
            this.customerService = customerService;

            Load();
        }

        private void Load()
        {
            Customers = customerService.Get();
            CustomerTypes = Enum.GetValues(typeof(CustomerType)).Cast<CustomerType>();
        }
    }
}
