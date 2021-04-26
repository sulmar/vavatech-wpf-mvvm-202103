using FluentValidation;
using Vavatech.Shop.Models.SearchCriterias;

namespace Vavatech.Shop.Models.Validators
{
    public class CreditSearchCriteriaValidator : AbstractValidator<CreditSearchCriteria>
    {
        public CreditSearchCriteriaValidator()
        {
            RuleFor(p => p.CreditAmountFrom).GreaterThan(0);
        }
    }
}
