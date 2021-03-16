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

namespace Vavatech.Shop.WpfClient.Modules
{
    public class CustomerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FakeCustomerService>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<CustomerFaker>().As<Faker<Customer>>().SingleInstance();
        }
    }
}
