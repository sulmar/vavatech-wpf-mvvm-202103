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
        private readonly INavigationService navigationService;
        private readonly IMessageBoxService messageBoxService;
        private readonly IApplicationService applicationService;

        public ICommand ExitCommand { get; private set; }
        public ICommand ShowViewCommand { get; private set; }

        public ShellViewModel(
            INavigationService navigationService,
            IMessageBoxService messageBoxService, 
            IApplicationService applicationService)
        {
            ExitCommand = new DelegateCommand(Exit);

            ShowViewCommand = new DelegateCommand<string>(ShowView);

            this.navigationService = navigationService;
            this.messageBoxService = messageBoxService;
            this.applicationService = applicationService;
        }

        public void ShowView(string viewName)
        {
            navigationService.Navigate(viewName);
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
