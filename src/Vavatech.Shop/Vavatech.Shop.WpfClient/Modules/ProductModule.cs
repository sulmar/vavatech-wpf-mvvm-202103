using Autofac;
using Bogus;
using Vavatech.Shop.Fakers;
using Vavatech.Shop.FakeServices;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.WpfClient.Modules
{
    public class ProductModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FakeProductService>().As<IProductService>().SingleInstance();
            builder.RegisterType<ProductFaker>().As<Faker<Product>>().SingleInstance();
        }
    }
}
