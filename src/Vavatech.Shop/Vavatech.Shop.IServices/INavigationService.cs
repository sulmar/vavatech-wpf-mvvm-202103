using System;
using System.Collections.Generic;
using System.Text;

namespace Vavatech.Shop.IServices
{
    public interface INavigationService
    {
        void Navigate(string viewName, object parameter = null);
        bool? ShowDialog(string viewName, object parameter = null);
        void Show(string viewName, object parameter = null);

        void GoBack();
        void GoForward();
        bool CanGoBack { get; }
        bool CanGoForward { get; }

        object Parameter { get; }
    }
}
