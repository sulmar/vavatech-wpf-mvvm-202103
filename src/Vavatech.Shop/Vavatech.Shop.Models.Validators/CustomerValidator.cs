using FluentValidation;

namespace Vavatech.Shop.Models.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            // hint: RuleSet
            RuleFor(p => p.Land).NotEmpty().When(p => p.Country == Country.Germany);
            RuleFor(p => p.TaxId).NotEmpty().When(p => p.Country == Country.Germany);

            RuleFor(p => p.Pesel).NotEmpty().When(p => p.Country == Country.Poland);
            RuleFor(p => p.Regon).NotEmpty().When(p => p.Country == Country.Poland);

            RuleFor(p => p.TaxId).NotEmpty().When(p => p.Country == Country.Italy);

        }
    }
}
