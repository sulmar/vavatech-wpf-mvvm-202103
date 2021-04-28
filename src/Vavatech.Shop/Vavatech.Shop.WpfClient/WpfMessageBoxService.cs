using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Vavatech.Shop.IServices;
using Vavatech.Shop.WpfClient.Views;

namespace Vavatech.Shop.WpfClient
{
    public class WpfMessageBoxService : IMessageBoxService
    {
        public object Parameter { get; private set; }

        public void Show(string viewName, object parameter = null)
        {
            Parameter = parameter;

            Window window = new MyWindow();
            window.Show();
        }

        public void ShowDialog(string viewName, object parameter = null)
        {
            Parameter = parameter;

            Window window = new MyWindow();
            window.ShowDialog();
        }

        public Task<bool> ShowDialogAsync(string viewName)
        {
            throw new NotImplementedException();
        }

        public bool ShowMessage(string text, string caption)
        {
            return MessageBox.Show(text, caption, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;
        }


    }

    public class WpfApplicationService : IApplicationService
    {
        public void Close()
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
