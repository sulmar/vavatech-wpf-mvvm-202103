using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.Shop.Fakers;
using Vavatech.Shop.FakeServices;
using Vavatech.Shop.ViewModels;

namespace Vavatech.Shop.WpfClient
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {

        }

        public CustomersViewModel CustomersViewModel => new CustomersViewModel(new FakeCustomerService(new CustomerFaker()));
    }
}
