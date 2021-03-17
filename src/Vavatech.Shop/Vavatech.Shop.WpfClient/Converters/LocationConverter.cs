using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Microsoft.Maps.MapControl.WPF;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.WpfClient.Converters
{

    [ValueConversion(typeof(Coordinate), typeof(Location))]
    public class LocationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(Location))
                throw new InvalidCastException();

            Coordinate coordinate = (Coordinate)value;

            return new Location(latitude: coordinate.Latitude, longitude: coordinate.Longitude);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
