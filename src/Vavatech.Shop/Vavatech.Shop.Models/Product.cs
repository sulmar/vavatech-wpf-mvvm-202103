using System;

namespace Vavatech.Shop.Models
{
    // Exceptions -> ValidatesOnExceptions=True
    public class Product : BaseEntity
    {
        public string Name
        {
            get => name; 
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException();

                name = value;
            }
        }
        public string Color { get; set; }
        public decimal UnitPrice
        {
            get => unitPrice; 
            set
            {
                if (value <= 0 || value > 1000)
                    throw new ArgumentOutOfRangeException();

                unitPrice = value;
            }
        }
        public bool IsDiscount { get; set; }
        public decimal Discount { get; set; }
        public string ImageUrl { get; set; }

        public bool IsOverLimit => UnitPrice > UnitPriceOverLimit;

        public static decimal UnitPriceOverLimit = 500;
        private decimal unitPrice;
        private string name;
    }
}
