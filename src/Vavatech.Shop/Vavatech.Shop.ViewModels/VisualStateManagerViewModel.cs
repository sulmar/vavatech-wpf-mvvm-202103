using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Vavatech.Shop.ViewModels.Common;

namespace Vavatech.Shop.ViewModels
{
    public class VisualStateManagerViewModel : BaseViewModel
    {
        private string visualStateName;

        public string VisualStateName
        {
            get => visualStateName; set
            {
                visualStateName = value;
                OnPropertyChanged();
            }
        }


        public ICommand GoToStateCommand { get; set; }

        public VisualStateManagerViewModel()
        {
            GoToStateCommand = new DelegateCommand<string>(GoToState);
        }

        private void GoToState(string stateName)
        {
            VisualStateName = stateName;
        }
    }
}
