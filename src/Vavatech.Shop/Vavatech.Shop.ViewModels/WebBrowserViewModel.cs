using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Vavatech.Shop.ViewModels.Common;

namespace Vavatech.Shop.ViewModels
{
    public class WebBrowserViewModel : BaseViewModel
    {
        private string url;

        public string Url
        {
            get => url; set
            {
                url = value;
                OnPropertyChanged();
            }
        }

        public ICommand ShowWebPageCommand { get; private set; }


        public WebBrowserViewModel()
        {
            ShowWebPageCommand = new DelegateCommand<string>(ShowWebPage);
        }

        private void ShowWebPage(string url)
        {
            Url = url;
        }
    }
}
