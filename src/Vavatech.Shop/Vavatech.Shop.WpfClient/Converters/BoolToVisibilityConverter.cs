using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Vavatech.Shop.WpfClient.Converters
{

    // wbudowany
    // BooleanToVisibilityConverter
    // https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.booleantovisibilityconverter?view=net-5.0

    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool bValue = (bool)value;

            if (targetType != typeof(Visibility))
            {
                throw new InvalidCastException("Oczekiwano Visilibity");
            }

            if (bValue)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
