using System;
using System.Collections.Generic;
using System.Text;

namespace Vavatech.Shop.Models
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address HomeAddress { get; set; }
        public Address WorkAddress { get; set; }
    }
    
}
