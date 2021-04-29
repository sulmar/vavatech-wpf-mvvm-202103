using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.ViewModelFirst.WpfClient.FakeServices;
using Vavatech.ViewModelFirst.WpfClient.IServices;
using Vavatech.ViewModelFirst.WpfClient.ViewModels;

namespace Vavatech.ViewModelFirst.WpfClient
{
    public class ViewModelLocator
    {

        private readonly IContainer container;

        public ViewModelLocator()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<ShellViewModel>();

            // Automatyczna rejestracja wszystkich klas, które dziedziczą po BaseViewModel
            containerBuilder.RegisterAssemblyTypes(typeof(BaseViewModel).Assembly)
                .Where(t => t.IsSubclassOf(typeof(BaseViewModel)));

            containerBuilder.RegisterType<FakeFooService>().As<IFoo>();
            containerBuilder.RegisterType<FakeBooService>().As<IBoo>();

            container = containerBuilder.Build();

        }

        public FirstViewModel FirstViewModel => container.Resolve<FirstViewModel>();
        public SecondViewModel SecondViewModel => container.Resolve<SecondViewModel>();
    }
}
