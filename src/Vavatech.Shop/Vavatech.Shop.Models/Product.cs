namespace Vavatech.Shop.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsDiscount { get; set; }
        public decimal Discount { get; set; }
        public string ImageUrl { get; set; }

        public bool IsOverLimit => UnitPrice > UnitPriceOverLimit;

        public static decimal UnitPriceOverLimit = 500;
    }
}
