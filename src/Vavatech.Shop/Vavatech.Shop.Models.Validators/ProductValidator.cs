using FluentValidation;
using System;

namespace Vavatech.Shop.Models.Validators
{

    // Install-Package FluentValidation
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.UnitPrice).InclusiveBetween(1, 1000);
            RuleFor(p => p.Discount).GreaterThan(0).When(p => p.IsDiscount);
        }
    }
}
