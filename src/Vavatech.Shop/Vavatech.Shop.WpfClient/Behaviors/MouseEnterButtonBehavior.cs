using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Vavatech.Shop.WpfClient.Behaviors
{
    // PM> Install-Package Microsoft.Xaml.Behaviors.Wpf
    public class MouseEnterButtonBehavior : Behavior<Button>
    {
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(MouseEnterButtonBehavior), new PropertyMetadata(null));


        // snippet: propdp
        public double Width
        {
            get { return (double)GetValue(WidthProperty); }
            set { SetValue(WidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Width.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WidthProperty =
            DependencyProperty.Register("Width", typeof(double), typeof(MouseEnterButtonBehavior), new PropertyMetadata(50d));

        // public double Width { get; set; }

        protected override void OnAttached()
        {
            Button button = this.AssociatedObject;

            button.MouseEnter += Button_MouseEnter;
        }

        private void Button_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Button button = (Button) sender;
            
            button.Width += Width;

            Command?.Execute(button.Width);
        }
    }
}
