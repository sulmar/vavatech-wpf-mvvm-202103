using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Vavatech.Shop.ViewModels.Common;

namespace Vavatech.ViewModelFirst.WpfClient.ViewModels
{

    public class ShellViewModel : BaseViewModel
    {
        private BaseViewModel selectedViewModel;
        private readonly ViewModelLocator viewModelLocator;

        public ICommand ShowFirstViewCommand { get; private set; }
        public ICommand ShowSecondViewCommand { get; set; }

        public ICollection<BaseViewModel> ViewModels { get; set; }

        public BaseViewModel SelectedViewModel
        {
            get => selectedViewModel; set
            {
                selectedViewModel = value;
                OnPropertyChanged();
            }
        }

        public ShellViewModel()
            : this(new ViewModelLocator())
        {

        }

        public ShellViewModel(ViewModelLocator viewModelLocator)
        {
            ShowFirstViewCommand = new DelegateCommand(ShowFirst);
            ShowSecondViewCommand = new DelegateCommand(ShowSecond);
         
            this.viewModelLocator = viewModelLocator;

            ViewModels = new List<BaseViewModel>();

            ViewModels.Add(viewModelLocator.FirstViewModel);
            ViewModels.Add(viewModelLocator.SecondViewModel);

            ShowFirst();
        }

        private void ShowFirst()
        {
            SelectedViewModel = viewModelLocator.FirstViewModel;
        }

        private void ShowSecond()
        {
            SelectedViewModel = viewModelLocator.SecondViewModel;
        }
    }
}
