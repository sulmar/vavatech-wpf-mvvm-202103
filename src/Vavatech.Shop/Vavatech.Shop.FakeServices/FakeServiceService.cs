using Bogus;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.FakeServices
{
    public class FakeServiceService : FakeEntityService<Service>, IServiceService
    {
        public FakeServiceService(Faker<Service> faker) : base(faker)
        {
        }
    }
}
