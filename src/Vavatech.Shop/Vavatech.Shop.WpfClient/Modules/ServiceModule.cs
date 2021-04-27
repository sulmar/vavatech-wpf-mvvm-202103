using Autofac;
using Bogus;
using Vavatech.Shop.Fakers;
using Vavatech.Shop.FakeServices;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.WpfClient.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FakeServiceService>().As<IServiceService>().SingleInstance();
            builder.RegisterType<ServiceFaker>().As<Faker<Service>>().SingleInstance();
        }
    }
}
