using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Vavatech.Shop.IServices;
using Vavatech.Shop.ViewModels.Common;

namespace Vavatech.Shop.ViewModels
{
    public class ShellViewModel : BaseViewModel
    {
        private readonly IMessageBoxService messageBoxService;
        private readonly IApplicationService applicationService;

        public ICommand ExitCommand { get; set; }

        public ShellViewModel(IMessageBoxService messageBoxService, IApplicationService applicationService)
        {
            ExitCommand = new DelegateCommand(Exit);
            this.messageBoxService = messageBoxService;
            this.applicationService = applicationService;
        }

        public void ShowCustomers()
        {

        }

        public void ShowCounter()
        {

        }

        public void ShowProducts()
        {

        }

        public void Exit()
        {
            if (messageBoxService.ShowMessage("Are you sure?", "Exit"))
            {
                applicationService.Close();
            }
        }
    }
}
