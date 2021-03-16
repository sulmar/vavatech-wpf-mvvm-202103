using Bogus;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;
using Vavatech.Shop.ViewModels.Common;

namespace Vavatech.Shop.ViewModels
{

    public class CustomersViewModel : BaseViewModel
    {
        public BindingList<Customer> Customers { get; set; }

        public IEnumerable<Customer> SelectedCustomers => Customers.Skip(0).Take(10).ToList();

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

        public ICommand AddCustomerCommand { get; private set; }
        public ICommand RemoveCustomerCommand { get; private set; }

        public IEnumerable<CustomerType> CustomerTypes { get; set; }

        private readonly ICustomerService customerService;
        private readonly Faker<Customer> customerFaker;
        private Customer selectedCustomer;

        public CustomersViewModel(ICustomerService customerService, Faker<Customer> customerFaker)
        {
            AddCustomerCommand = new DelegateCommand(AddCustomer);
            RemoveCustomerCommand = new DelegateCommand(RemoveCustomer);

            this.customerService = customerService;
            this.customerFaker = customerFaker;

            Load();
        }

        private void Load()
        {
            // Customers = new BindingList<Customer>(customerService.Get().ToList());

            Customers = customerService.Get().ToBindingList();

            Customers.ListChanged += (s, e) => OnPropertyChanged(nameof(TotalCreditAmount));

            CustomerTypes = Enum.GetValues(typeof(CustomerType)).Cast<CustomerType>();
        }


        public void AddCustomer()
        {
            SelectedCustomer = customerFaker.Generate();

            Customers.Add(SelectedCustomer);
        }


        public void RemoveCustomer()
        {
            Customers[5].CreditAmount += 1000;
        }
    }
}
