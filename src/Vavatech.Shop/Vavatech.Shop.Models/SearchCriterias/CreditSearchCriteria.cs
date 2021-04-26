using System;
using System.Collections;
using System.ComponentModel;

namespace Vavatech.Shop.Models.SearchCriterias
{
    public class CreditSearchCriteria : BaseSearchCriteria, INotifyDataErrorInfo
    {
        public decimal? CreditAmountFrom { get; set; }
        public decimal? CreditAmountTo { get; set; }
        public CreditType CreditType { get; set; }

        public bool HasErrors => false;

        public CreditSearchCriteria()
        {
            CreditAmountFrom = 100;
            CreditAmountTo = 1000;
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            throw new NotImplementedException();
        }
    }
}
