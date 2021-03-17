using Bogus;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.Fakers
{
    public class CoordinateFaker : Faker<Coordinate>
    {
        public CoordinateFaker()
        {
            RuleFor(p => p.Latitude, f => f.Address.Latitude(49, 52));
            RuleFor(p => p.Longitude, f => f.Address.Longitude(18, 22));
        }
    }
}
