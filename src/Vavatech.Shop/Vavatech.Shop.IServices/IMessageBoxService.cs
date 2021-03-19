using System;
using System.Collections.Generic;
using System.Text;

namespace Vavatech.Shop.IServices
{
    public interface IMessageBoxService
    {
        bool ShowMessage(string text, string caption);

        void Show(string viewName, object parameter = null);

        void ShowDialog(string viewName, object parameter = null);

        object Parameter { get; }
    }
}
