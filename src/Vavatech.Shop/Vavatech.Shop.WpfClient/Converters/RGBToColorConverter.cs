using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Vavatech.Shop.WpfClient.Converters
{
    // [ValueConversion(typeof(IEnumerable<byte>), typeof(Color))]
    public class RGBToColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return Color.FromRgb(
                   r: System.Convert.ToByte(values[0]),
                   g: System.Convert.ToByte(values[1]),
                   b: System.Convert.ToByte(values[2])
                );
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
