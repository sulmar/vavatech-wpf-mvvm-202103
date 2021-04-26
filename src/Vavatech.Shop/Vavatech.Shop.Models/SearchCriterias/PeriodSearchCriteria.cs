using FluentValidation;
using System;

namespace Vavatech.Shop.Models.SearchCriterias
{
    // [Validator(typeof(PeriodSearchCriteriaValidator))]
    public class PeriodSearchCriteria : BaseSearchCriteria
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public PeriodSearchCriteria(IValidator<PeriodSearchCriteria> validator)
            : base(validator)

        {
            From = DateTime.Today.AddDays(-30);
            To = DateTime.Today;
        }
    }
}
