using Autofac;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.Shop.Fakers;
using Vavatech.Shop.FakeServices;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;
using Vavatech.Shop.ViewModels;

namespace Vavatech.Shop.WpfClient
{

    // Install-Package AutoFac

    public class ViewModelLocator
    {
        private readonly IContainer container;

        public ViewModelLocator()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<CustomersViewModel>();
            containerBuilder.RegisterType<FakeCustomerService>().As<ICustomerService>().SingleInstance();
            containerBuilder.RegisterType<CustomerFaker>().As<Faker<Customer>>().SingleInstance();

            container = containerBuilder.Build();
        }

        // public CustomersViewModel CustomersViewModel => new CustomersViewModel(new FakeCustomerService(new CustomerFaker()));

        public CustomersViewModel CustomersViewModel => container.Resolve<CustomersViewModel>();
    }
}
