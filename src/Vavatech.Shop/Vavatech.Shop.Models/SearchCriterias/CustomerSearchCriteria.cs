using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Vavatech.Shop.Models.SearchCriterias
{
    public abstract class BaseSearchCriteria : Base
    {

    }

    // GET api/customers?firsname=John&lastname=Smith&Period.From=2021-02-02
    public class CustomerSearchCriteria : BaseSearchCriteria, INotifyDataErrorInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressSearchCriteria Address { get; set; }
        public PeriodSearchCriteria Period { get; set; }
        public CreditSearchCriteria Credit { get; set; }

        public static CustomerSearchCriteria Default => new CustomerSearchCriteria();

        public bool HasErrors => Period.HasErrors; // || Credit.HasErrors;

        public CustomerSearchCriteria()
        {
            Address = new AddressSearchCriteria();
            Period = new PeriodSearchCriteria();
            Credit = new CreditSearchCriteria();

            Period.ErrorsChanged += CustomerSearchCriteria_ErrorsChanged;
            Credit.ErrorsChanged += CustomerSearchCriteria_ErrorsChanged;
        }

       

        private void CustomerSearchCriteria_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            ErrorsChanged.Invoke(this, new DataErrorsChangedEventArgs(nameof(e.PropertyName)));
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return Period.GetErrors(propertyName);
        }
    }
}
