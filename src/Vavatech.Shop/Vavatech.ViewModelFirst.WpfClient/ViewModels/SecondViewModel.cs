using System;
using Vavatech.ViewModelFirst.WpfClient.IServices;

namespace Vavatech.ViewModelFirst.WpfClient.ViewModels
{
    public class SecondViewModel : BaseViewModel
    {
        private readonly IBoo boo;

        public SecondViewModel(IBoo boo)
        {
            this.boo = boo;

            Load();
            
        }

        private void Load()
        {
            Name = boo.Get();
        }

        public string Name { get; set; }
    }
}
