using System;
using System.Collections.Generic;
using System.Text;

namespace Vavatech.Shop.Models.SearchCriterias
{
    public abstract class BaseSearchCriteria : Base
    {

    }

    public class CustomerSearchCriteria : BaseSearchCriteria
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal? CreditAmountFrom { get; set; }
        public decimal? CreditAmountTo { get; set; }

        public static CustomerSearchCriteria Default => new CustomerSearchCriteria
        {
            CreditAmountFrom = 100,
            CreditAmountTo = 1000
        };
    }
}
