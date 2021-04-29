using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.ViewModelFirst.WpfClient.IServices;

namespace Vavatech.ViewModelFirst.WpfClient.ViewModels
{
    public class FirstViewModel : BaseViewModel
    {
        private readonly IFoo foo;

        public FirstViewModel(IFoo foo)
        {
            this.foo = foo;

            Load();
        }

        public string Name { get; set; }

        private void Load()
        {
            Name = foo.Get();
        }

       
    }
}
