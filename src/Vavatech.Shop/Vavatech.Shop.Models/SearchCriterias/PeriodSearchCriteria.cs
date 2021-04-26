using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Vavatech.Shop.Models.SearchCriterias
{
    public class PeriodSearchCriteria : BaseSearchCriteria
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public PeriodSearchCriteria()
            : base()
        {
            From = DateTime.Today.AddDays(-30);
            To = DateTime.Today;
        }

        protected override void Validate(string propertyName)
        {
            base.Validate(propertyName);

            OnErrorsChanged(nameof(From));
            OnErrorsChanged(nameof(To));

            if (From.HasValue && To.HasValue && To < From)
            {
                AddError(nameof(From), "Data od jest nieprawidłowa");
                AddError(nameof(To), "Data do jest nieprawidłowa");
            }
        }
       

    }
}
