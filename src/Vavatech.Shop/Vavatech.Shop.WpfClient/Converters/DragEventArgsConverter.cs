using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.WpfClient.Converters
{
    public class DragEventArgsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DragEventArgs e = (DragEventArgs)value;

            Customer customer = e.Data.GetData(typeof(Customer)) as Customer;

            return customer;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
