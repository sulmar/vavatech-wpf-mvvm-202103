using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Vavatech.Shop.WpfClient.MarkupExtensions
{
    public class EnumSourceExtension : MarkupExtension
    {
        private Type _enumType;

        public EnumSourceExtension(Type enumType)
        {
            if (enumType == null)
                throw new ArgumentNullException("enumType");


            this._enumType = enumType;
        }

        public Type EnumType
        {
            get { return _enumType; }
            private set
            {
                if (_enumType == value)
                    return;

                var enumType = Nullable.GetUnderlyingType(value) ?? value;

                if (enumType.IsEnum == false)
                    throw new ArgumentException("Type must be an Enum.");

                _enumType = value;
            }
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var items = Enum.GetValues(_enumType)
                .Cast<object>()
                .Select(item => new { Value = item, Description = GetDesciption(item) });

            return items;

        }

        private object GetDesciption(object enumValue)
        {
            var desciptionAttribute = _enumType.GetField(enumValue.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .FirstOrDefault() as DescriptionAttribute;

            return desciptionAttribute.Description;
        }
    }
}
