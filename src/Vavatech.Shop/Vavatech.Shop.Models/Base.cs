using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Results;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Vavatech.Shop.Models
{

    //public static class ValidatorExtensions
    //{
    //    public static ValidationResult<T>(this IValidator<T> validator, object instance, string propertyName)
    //    {
    //        IEnumerable<string> properties = new List<string> { propertyName };

    //        var context = new ValidationContext(instance, new PropertyChain(), new MemberNameValidatorSelector(properties));


    //    }
    //}

    public abstract class Base : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

      //  #region INotifyDataErrorInfo

        //IValidator validator;

        //public bool HasErrors => validator.Validate()

        //public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        //public IEnumerable GetErrors(string propertyName)
        //{
        //    var result = validator.Validate()

        //    return result.Errors;
        //}

        //#endregion


    }


}
