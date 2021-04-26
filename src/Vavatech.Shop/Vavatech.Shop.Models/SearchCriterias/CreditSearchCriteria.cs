using FluentValidation;
using System;
using System.Collections;
using System.ComponentModel;

namespace Vavatech.Shop.Models.SearchCriterias
{
    public class CreditSearchCriteria : BaseSearchCriteria
    {
        public decimal? CreditAmountFrom { get; set; }
        public decimal? CreditAmountTo { get; set; }
        public CreditType CreditType { get; set; }

        public CreditSearchCriteria(IValidator<CreditSearchCriteria> validator)
            : base(validator)
        {
            CreditAmountFrom = 100;
            CreditAmountTo = 1000;
        }

        //protected override void Validate(string propertyName)
        //{
        //    base.Validate(propertyName);

        //    OnErrorsChanged(nameof(CreditAmountFrom));
        //    OnErrorsChanged(nameof(CreditAmountTo));

        //    if (CreditAmountFrom.HasValue && CreditAmountTo.HasValue && CreditAmountTo < CreditAmountFrom)
        //    {
        //        AddError(nameof(CreditAmountFrom), "Wartość CreditAmountFrom jest nieprawidłowa");
        //        AddError(nameof(CreditAmountTo), "Wartość CreditAmountTo jest nieprawidłowa");
        //    }
        //}

    }
}
