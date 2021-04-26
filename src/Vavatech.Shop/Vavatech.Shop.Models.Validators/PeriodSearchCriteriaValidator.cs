using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Vavatech.Shop.Models.SearchCriterias;

namespace Vavatech.Shop.Models.Validators
{
    public class PeriodSearchCriteriaValidator : AbstractValidator<PeriodSearchCriteria>
    {
        public PeriodSearchCriteriaValidator()
        {
            RuleFor(p => p.To).GreaterThan(p => p.From)
                .WithMessage("Data końca musi być późniejsza niż data początkowa")
                .When(p => p.To.HasValue && p.From.HasValue);

            RuleFor(p => p.From).LessThan(p => p.To)
                .WithMessage("Data końca musi być późniejsza niż data początkowa")
                .When(p => p.From.HasValue && p.To.HasValue);

        }
    }
}
