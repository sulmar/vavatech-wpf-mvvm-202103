using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Vavatech.Shop.Models.SearchCriterias
{
    public class PeriodSearchCriteria : BaseSearchCriteria, INotifyDataErrorInfo
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        private readonly IDictionary<string, List<string>> errors = new Dictionary<string, List<string>>();

        public bool HasErrors => errors.Any();

        public PeriodSearchCriteria()
        {
            From = DateTime.Today.AddDays(-30);
            To = DateTime.Today;

            this.PropertyChanged += PeriodSearchCriteria_PropertyChanged;
        }

        private void PeriodSearchCriteria_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Validate();
        }

        private void Validate()
        {
            errors.Clear();
            OnErrorsChanged(nameof(From));
            OnErrorsChanged(nameof(To));

            if (From.HasValue && To.HasValue && To < From)
            {
                AddError(nameof(From), "Data od jest nieprawidłowa");
                AddError(nameof(To), "Data do jest nieprawidłowa");
            }
        }

        private void AddError(string propertyName, string error)
        {
            if (!errors.ContainsKey(propertyName))
            {
                errors[propertyName] = new List<string>();
            }

            if (!errors[propertyName].Contains(error))
            {
                errors[propertyName].Add(error);
                OnErrorsChanged(propertyName);
            }
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        protected void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public IEnumerable GetErrors(string propertyName)
        {
            return errors.ContainsKey(propertyName) ? errors[propertyName] : null;
        }
    }
}
