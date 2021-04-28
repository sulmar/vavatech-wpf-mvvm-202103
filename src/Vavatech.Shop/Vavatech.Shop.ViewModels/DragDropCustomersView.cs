using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;
using Vavatech.Shop.ViewModels.Common;

namespace Vavatech.Shop.ViewModels
{
    public class DragDropCustomersViewModel : BaseViewModel
    {
        public BindingList<Customer> SourceCustomers
        {
            get => sourceCustomers; set
            {
                sourceCustomers = value;
                OnPropertyChanged();
            }
        }

        public BindingList<Customer> TargetCustomers
        {
            get => targetCustomers; set
            {
                targetCustomers = value;
                OnPropertyChanged();
            }
        }


        private readonly ICustomerService customerService;
        private BindingList<Customer> sourceCustomers;
        private BindingList<Customer> targetCustomers;

        public ICommand AddCustomerCommand { get; private set; }
        public ICommand RemoveCustomerCommand { get; private set; }

        public ICommand DropAddCustomerCommand { get; private set; }
        public ICommand DropRemoveCustomerCommand { get; private set; }


        public Customer SelectedCustomer { get; set; }

        public DragDropCustomersViewModel(ICustomerService customerService)
        {
            this.customerService = customerService;

            AddCustomerCommand = new DelegateCommand(AddCustomer);
            RemoveCustomerCommand = new DelegateCommand(RemoveCustomer);
            DropAddCustomerCommand = new DelegateCommand<Customer>(DropAddCustomer);
            DropRemoveCustomerCommand = new DelegateCommand<Customer>(DropRemoveCustomer);

            Load();
        }

        private void DropAddCustomer(Customer customer)
        {
            SelectedCustomer = customer;
            AddCustomer();
        }

        private void DropRemoveCustomer(Customer customer)
        {
            SelectedCustomer = customer;
            RemoveCustomer();
        }

        private void RemoveCustomer()
        {
            if (!SourceCustomers.Contains(SelectedCustomer))
            {
                SourceCustomers.Add(SelectedCustomer);
                TargetCustomers.Remove(SelectedCustomer);
            }
        }

        private void AddCustomer()
        {
            if (!TargetCustomers.Contains(SelectedCustomer))
            {
                TargetCustomers.Add(SelectedCustomer);
                SourceCustomers.Remove(SelectedCustomer);
            }
        }

        private void Load()
        {
            SourceCustomers = customerService.Get().ToBindingList();
            TargetCustomers = new BindingList<Customer>();
        }

    }
}
