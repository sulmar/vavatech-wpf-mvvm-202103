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

        public Customer SelectedCustomer { get; set; }

        public DragDropCustomersViewModel(ICustomerService customerService)
        {
            this.customerService = customerService;

            AddCustomerCommand = new DelegateCommand(AddCustomer);
            RemoveCustomerCommand = new DelegateCommand(RemoveCustomer);

            Load();
        }

        private void RemoveCustomer()
        {
            SourceCustomers.Add(SelectedCustomer);
            TargetCustomers.Remove(SelectedCustomer);         
        }

        private void AddCustomer()
        {
            
            TargetCustomers.Add(SelectedCustomer);
            SourceCustomers.Remove(SelectedCustomer);
        }

        private void Load()
        {
            SourceCustomers = customerService.Get().ToBindingList();
            TargetCustomers = new BindingList<Customer>();
        }


    }
}
