using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Vavatech.Shop.IServices;

namespace Vavatech.Shop.WpfClient
{
    public class WpfMessageBoxService : IMessageBoxService
    {
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
