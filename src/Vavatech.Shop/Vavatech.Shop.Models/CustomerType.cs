using System.ComponentModel;
using Vavatech.Shop.Models.Converters;

namespace Vavatech.Shop.Models
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum CustomerType
    {
        [Description("Wesoły")]
        Smily,

        [Description("Szczęśliwy")]
        Happy,

        [Description("Nerwowy")]
        Nervous        
    }
}
