using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Vavatech.Shop.IServices;
using Vavatech.Shop.ViewModels;
using Vavatech.Shop.ViewModels.Common;

namespace MetalDesignWpfClient.ViewModels
{
    public class MainWindowViewModel
    {
        private readonly IMessageBoxService messageBoxService;

        public int Age { get; set; }

        //public ICommand AcceptDialogCommand { get; private set; }
        //public ICommand CancelDialogCommand { get; private set; }


        public ICommand RemoveCommand { get; private set; }

        public MainWindowViewModel()
            : this(new MetalDesignMessageBoxService())
        {

        }

        public MainWindowViewModel(IMessageBoxService messageBoxService)
        {
            //AcceptDialogCommand = new DelegateCommand(Remove);
            //CancelDialogCommand = new DelegateCommand(Cancel);
            RemoveCommand = new DelegateCommand(Remove);

            this.messageBoxService = messageBoxService;
        }

        private void Cancel()
        {
            throw new NotImplementedException();
        }

        private async void Remove()
        {
            var result = await messageBoxService.ShowDialogAsync("Are you sure?");

            if (result)
            {

            }


        }
    }
}
