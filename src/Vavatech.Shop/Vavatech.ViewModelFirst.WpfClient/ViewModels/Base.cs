
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Vavatech.ViewModelFirst.WpfClient.ViewModels
{
    public abstract class Base : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
