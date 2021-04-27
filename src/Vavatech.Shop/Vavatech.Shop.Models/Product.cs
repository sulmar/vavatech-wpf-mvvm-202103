using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Vavatech.Shop.Models
{


    // Exceptions -> ValidatesOnExceptions=True

    // INotifyDataErrorInfo -> ValidatesOnNotifyDataErrors = true

    public class Product : Item
    {
      
        //public string Name
        //{
        //    get => name; 
        //    set
        //    {
        //        if (string.IsNullOrEmpty(value))
        //            throw new ArgumentNullException();

        //        name = value;
        //    }
        //}

        public string Color { get; set; }

        public float Weight { get; set; }

        //public decimal UnitPrice
        //{
        //    get => unitPrice; 
        //    set
        //    {
        //        if (value <= 0 || value > 1000)
        //            throw new ArgumentOutOfRangeException();

        //        unitPrice = value;
        //    }
        //}


        public bool IsDiscount { get; set; }
        public decimal Discount { get; set; }
        public string ImageUrl { get; set; }

        public bool IsOverLimit => UnitPrice > UnitPriceOverLimit;



        public static decimal UnitPriceOverLimit = 500;
        private decimal unitPrice;


        //public IEnumerable GetErrors(string propertyName)
        //{
          
        //    if (propertyName == nameof(Name))
        //    {
        //        if (string.IsNullOrEmpty(Name))
        //        {
        //            errors.Add("Nazwa nie może być pusta");
        //        }
        //    }

        //    if (propertyName == nameof(UnitPrice))
        //    {
        //        if (UnitPrice <= 0 || UnitPrice > 1000)
        //        {
        //            errors.Add("Wartość UnitPrice jest spoza zakresu");
        //        }
        //    }

         
        //    return errors;
        //}

        
    }
}
