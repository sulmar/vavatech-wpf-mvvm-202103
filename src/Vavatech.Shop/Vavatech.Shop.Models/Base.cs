using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Results;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Vavatech.Shop.Models
{
    public abstract class Base : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        #region INotifyDataErrorInfo

        // private IValidator validator => new AttributedValidatorFactory().GetValidator(this.GetType());

        private IValidator validator;

        public virtual bool HasErrors => !(validator?.Validate(new ValidationContext<object>(this)).IsValid ?? true);

        public Base(IValidator validator)
            : this()
        {
            this.validator = validator;
        }

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
            if (validationResult == null)
                return null;

            return validationResult.Errors;
        }

        private ValidationResult validationResult;

        protected virtual void Validate(string propertyName)
        {
            if (validator == null)
                return;

            var properties = new List<string> { propertyName };

            var context = new ValidationContext<object>(
                this,
                new PropertyChain(),
                new MemberNameValidatorSelector(properties));

             validationResult = validator.Validate(context);


            OnErrorsChanged(propertyName);
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


    }
}
