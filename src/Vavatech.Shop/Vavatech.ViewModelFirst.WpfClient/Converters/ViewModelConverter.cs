using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Vavatech.ViewModelFirst.WpfClient.ViewModels;

namespace Vavatech.ViewModelFirst.WpfClient.Converters
{
    public class ViewModelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string viewModel = value.ToString();

            string view = "";

            switch (viewModel)
            {
                case "Vavatech.ViewModelFirst.WpfClient.ViewModels.FirstViewModel": view = "FirstPageView.xaml"; break;
                case "Vavatech.ViewModelFirst.WpfClient.ViewModels.SecondViewModel": view = "SecondPageView.xaml"; break;

                default: throw new NotSupportedException();
            }

            return new Uri(view, UriKind.Relative);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
