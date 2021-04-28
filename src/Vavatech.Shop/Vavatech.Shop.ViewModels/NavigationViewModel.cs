using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;
using Vavatech.Shop.ViewModels.Common;

namespace Vavatech.Shop.ViewModels
{
    public class NavigationViewModel : BaseViewModel
    {
        private readonly ICustomerService customerService;
        private readonly INavigationService navigationService;

        public IEnumerable<Customer> Customers { get; set; }

        public Customer SelectedCustomer { get; set; }

        public ICommand ShowSelectedCustomerCommand { get; private set; }

        public ICommand ShowWindowCommand { get; private set; }
        public ICommand LoadCommand { get; set; }

        public NavigationViewModel(ICustomerService customerService, INavigationService navigationService)
        {
            this.customerService = customerService;
            this.navigationService = navigationService;

            ShowSelectedCustomerCommand = new DelegateCommand(ShowSelectedCustomer);
            ShowWindowCommand = new DelegateCommand(ShowWindow);
            LoadCommand = new DelegateCommand(Load);
        }

        private void ShowWindow()
        {
            navigationService.Show("Window", SelectedCustomer.Id);
        }

        private void ShowSelectedCustomer()
        {
            navigationService.Navigate("Customer", SelectedCustomer.Id);
        }

        private async void Load()
        {
            Customers = await customerService.GetAsync();

            OnPropertyChanged(nameof(Customers));
        }


    }
}
