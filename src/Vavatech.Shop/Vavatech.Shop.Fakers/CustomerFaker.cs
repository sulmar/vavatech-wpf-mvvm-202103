using Bogus;
using System;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.Fakers
{
    // Install-Package Bogus
    public class CustomerFaker : Faker<Customer>
    {
        public CustomerFaker()
        {
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.FirstName, f => f.Person.FirstName);
            RuleFor(p => p.LastName, f => f.Person.LastName);
            RuleFor(p => p.Avatar, f => f.Person.Avatar);
            RuleFor(p => p.CustomerType, f => f.PickRandom<CustomerType>());
            RuleFor(p => p.CreditAmount, f => Math.Round(f.Random.Decimal(1, 1000), 2));
            RuleFor(p => p.IsRemoved, f => f.Random.Bool(0.2f));
        }
    }
}
