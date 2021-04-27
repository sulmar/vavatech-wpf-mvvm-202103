using Bogus;
using System;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.Fakers
{
    public class ServiceFaker : Faker<Service>
    {
        public ServiceFaker()
        {
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.Name, f => f.Hacker.Verb());
            RuleFor(p => p.Duration, f => f.Date.Timespan(TimeSpan.FromHours(4)));
        }
    }
}
