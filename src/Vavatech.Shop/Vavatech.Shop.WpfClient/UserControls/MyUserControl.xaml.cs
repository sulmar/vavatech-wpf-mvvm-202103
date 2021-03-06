using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Vavatech.Shop.WpfClient.UserControls
{
    /// <summary>
    /// Interaction logic for MyUserControl.xaml
    /// </summary>
    public partial class MyUserControl : UserControl
    {


        public int Id
        {
            get { return (int)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(int), typeof(MyUserControl), new PropertyMetadata(0));

                

        public MyUserControl()
        {
            InitializeComponent();

            Trace.WriteLine($"Constructor of {nameof(MyUserControl)} #{Id}");
        }
    }
}
