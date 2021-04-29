using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vavatech.Shop.WpfClient.Views
{
    /// <summary>
    /// Interaction logic for VisualStateManagerView.xaml
    /// </summary>
    public partial class VisualStateManagerView : Page
    {
        public VisualStateManagerView()
        {
            InitializeComponent();
        }

        private void GoToStateA_Click(object sender, RoutedEventArgs e)
        {
            VisualStateManager.GoToElementState(LayoutRoot, "StateA", true);
        }

        private void GoToStateB_Click(object sender, RoutedEventArgs e)
        {
            VisualStateManager.GoToElementState(LayoutRoot, "StateB", true);
        }
    }
}
