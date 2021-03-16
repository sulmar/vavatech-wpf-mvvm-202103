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
using Vavatech.Shop.WpfClient.Modules;

namespace Vavatech.Shop.WpfClient
{

    // Install-Package AutoFac

    public class ViewModelLocator
    {
        private readonly IContainer container;

        public ViewModelLocator()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();

            //containerBuilder.RegisterType<FakeCustomerService>().As<ICustomerService>().SingleInstance();
            //containerBuilder.RegisterType<CustomerFaker>().As<Faker<Customer>>().SingleInstance();

            // containerBuilder.RegisterModule(new CustomerModule());

            // containerBuilder.RegisterType<CustomersViewModel>();
            // containerBuilder.RegisterType<ShellViewModel>();

            // Automatyczna rejestracja wszystkich klas, które dziedziczą po BaseViewModel
            containerBuilder.RegisterAssemblyTypes(typeof(BaseViewModel).Assembly)
                .Where(t => t.IsSubclassOf(typeof(BaseViewModel)));

            // Automatyczna rejestracja klas z modułów
            containerBuilder.RegisterAssemblyModules(typeof(CustomerModule).Assembly);

            containerBuilder.RegisterType<WpfMessageBoxService>().As<IMessageBoxService>();
            containerBuilder.RegisterType<WpfApplicationService>().As<IApplicationService>();

            containerBuilder.RegisterType<FrameNavigationService>().As<INavigationService>().SingleInstance();

            container = containerBuilder.Build();
        }

        // public CustomersViewModel CustomersViewModel => new CustomersViewModel(new FakeCustomerService(new CustomerFaker()));

        public CustomersViewModel CustomersViewModel => container.Resolve<CustomersViewModel>();
        public ShellViewModel ShellViewModel => container.Resolve<ShellViewModel>();
        public CounterViewModel CounterViewModel => container.Resolve<CounterViewModel>();
    }
}
