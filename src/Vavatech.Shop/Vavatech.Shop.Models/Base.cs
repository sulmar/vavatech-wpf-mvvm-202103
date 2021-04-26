using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Results;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Vavatech.Shop.Models
{

    public static class ValidatorExtensions
    {
        //public static ValidationResult Validate<T>(this IValidator<T> validator, T instance, string propertyName)
        //{
        //    IEnumerable<string> properties = new List<string> { propertyName };

        //    var context = new ValidationContext<T>(instance, new PropertyChain(), new MemberNameValidatorSelector(properties));

        //    return validator.Validate(context);
        //}

        public static ValidationResult MyValidate(this IValidator validator, object instance, string propertyName)
        {
            IEnumerable<string> properties = new List<string> { propertyName };

            var context = new ValidationContext<object>(instance, new PropertyChain(), new MemberNameValidatorSelector(properties));

            return validator.Validate(context);
        }
    }

    public abstract class Base : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        #region INotifyDataErrorInfo

        private readonly IDictionary<string, List<string>> errors = new Dictionary<string, List<string>>();

        public virtual bool HasErrors => errors.Any();

        public Base()
        {
            this.PropertyChanged += Base_PropertyChanged;
        }

        private void Base_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Validate(e.PropertyName);
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return errors.ContainsKey(propertyName) ? errors[propertyName] : null;
        }

        protected virtual void Validate(string propertyName)
        {
            errors.Clear();           
        }

        protected void AddError(string propertyName, string error)
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

        protected void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        //#region INotifyDataErrorInfo

        //IValidator validator;

        //public bool HasErrors => validator?.Validate(this).IsValid ?? true;

        //public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        //public IEnumerable GetErrors(string propertyName)
        //{
        //    var result = validator.MyValidate(this, propertyName);

        //    return result.Errors;
        //}

        //#endregion


    }
}
