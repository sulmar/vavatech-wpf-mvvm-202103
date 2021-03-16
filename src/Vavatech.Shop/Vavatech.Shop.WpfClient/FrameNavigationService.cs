using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Vavatech.Shop.IServices;

namespace Vavatech.Shop.WpfClient
{
    public class FrameNavigationService : INavigationService
    {
        public bool CanGoBack => Frame.CanGoBack;

        public bool CanGoForward => Frame.CanGoForward;

        public object Parameter { get; private set; }

        public Frame Frame => Get("MainFrame");

        public void GoBack() => Frame.GoBack();

        public void GoForward() => Frame.GoForward();

        public void Navigate(string viewName, object parameter = null)
        {
            Uri uri = new Uri($"Views/{viewName}View.xaml", UriKind.Relative);

            Frame.Navigate(uri, parameter);

            Parameter = parameter;
        }

        private Frame Get(string frameName)
        {
            if (Application.Current.MainWindow.FindName(frameName) is Frame frame )
            {
                return frame;
            }

            throw new KeyNotFoundException(frameName);
        }
    }
}
