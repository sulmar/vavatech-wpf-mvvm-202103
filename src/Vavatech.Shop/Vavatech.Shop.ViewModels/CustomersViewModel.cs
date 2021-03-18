using Bogus;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;
using Vavatech.Shop.Models.SearchCriterias;
using Vavatech.Shop.ViewModels.Common;

namespace Vavatech.Shop.ViewModels
{

    public class CustomersViewModel : BaseViewModel
    {
        public BindingList<Customer> Customers { get; set; }

        public IEnumerable<Customer> SelectedCustomers => Customers.ToList();

        public CustomerSearchCriteria SearchCriteria { get; set; }

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


        public Coordinate CenterLocation { get; private set; }

        public ICommand AddCustomerCommand { get; private set; }
        public ICommand RemoveCustomerCommand { get; private set; }
        public ICommand SearchCommand { get; private set; }

        public IEnumerable<CustomerType> CustomerTypes { get; set; }

        private readonly ICustomerService customerService;
        private readonly Faker<Customer> customerFaker;
        private Customer selectedCustomer;

        public CustomersViewModel(ICustomerService customerService, Faker<Customer> customerFaker)
        {
            AddCustomerCommand = new DelegateCommand(AddCustomer);
            RemoveCustomerCommand = new DelegateCommand(RemoveCustomer);
            SearchCommand = new DelegateCommand(Search);

            this.customerService = customerService;
            this.customerFaker = customerFaker;

            SearchCriteria = CustomerSearchCriteria.Default;

            Load();
        }

        private void Load()
        {
            // Customers = new BindingList<Customer>(customerService.Get().ToList());

            CenterLocation = new Coordinate(52, 21);

            Customers = customerService.Get().ToBindingList();

            Customers.ListChanged += (s, e) =>
            {
                OnPropertyChanged(nameof(TotalCreditAmount));
                OnPropertyChanged(nameof(SelectedCustomers));
            };

            CustomerTypes = Enum.GetValues(typeof(CustomerType)).Cast<CustomerType>();

            SelectedCustomer = new Customer();
        }


        public void AddCustomer()
        {
            Customers.Add(SelectedCustomer);
            customerService.Add(SelectedCustomer);
        }


        public void RemoveCustomer()
        {
            Customers.Remove(SelectedCustomer);
            customerService.Remove(SelectedCustomer.Id);
        }


        public void Search()
        {
            Customers = customerService.Get(SearchCriteria).ToBindingList();
            OnPropertyChanged(nameof(SelectedCustomers));
        }
    }
}
