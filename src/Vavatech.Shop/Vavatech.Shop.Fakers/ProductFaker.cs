using Bogus;
using System;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.Fakers
{
    public class ProductFaker : Faker<Product>
    {
        public ProductFaker()
        {
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.Name, f => f.Commerce.ProductName());
            RuleFor(p => p.Color, f => f.Commerce.Color());
            RuleFor(p => p.Weight, f => f.Random.Float(100, 1000));
            RuleFor(p => p.UnitPrice, f => decimal.Parse(f.Commerce.Price()));
            RuleFor(p => p.ImageUrl, f => f.Image.PicsumUrl(50, 50));
            RuleFor(p => p.IsDiscount, f => f.Random.Bool(0.3f));
            RuleFor(p => p.Discount, (f, p) => p.IsDiscount ?  Math.Round( f.Random.Decimal(1, 100), 2) : 0);
        }
    }
}
