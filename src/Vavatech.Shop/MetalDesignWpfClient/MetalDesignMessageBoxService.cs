using MaterialDesignThemes.Wpf;
using MetalDesignWpfClient.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.Shop.IServices;

namespace MetalDesignWpfClient
{
    class MetalDesignMessageBoxService : IMessageBoxService
    {
        public object Parameter => throw new NotImplementedException();

        public void Show(string viewName, object parameter = null)
        {
            throw new NotImplementedException();
        }

        public void ShowDialog(string viewName, object parameter = null)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ShowDialogAsync(string viewName)
        {
            DialogView view = new DialogView();

            var result = await DialogHost.Show(view, "RootDialog");

            return (bool)result;
        }

       

        public bool ShowMessage(string text, string caption)
        {
             

            throw new NotImplementedException();


        }
    }
}
