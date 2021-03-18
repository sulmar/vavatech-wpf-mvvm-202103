using System;
using System.Collections.Generic;
using System.Text;

namespace Vavatech.Shop.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CountryAttribute : Attribute
    {
        public string Country { get; set; }

        public CountryAttribute(string country)
        {
            Country = country;
        }
    }
}
