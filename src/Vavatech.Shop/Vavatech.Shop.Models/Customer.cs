using System;

namespace Vavatech.Shop.Models
{

    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerType CustomerType { get; set; }
        public bool IsRemoved { get; set; }        
    }
}
