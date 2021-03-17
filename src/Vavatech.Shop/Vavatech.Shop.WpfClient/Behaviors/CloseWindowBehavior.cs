using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Vavatech.Shop.IServices;

namespace Vavatech.Shop.WpfClient.Behaviors
{
    public class CloseWindowBehavior : Behavior<Window>
    {
        private readonly IMessageBoxService messageBoxService;

        public CloseWindowBehavior()
            : this(new WpfMessageBoxService())
        {

        }

        public CloseWindowBehavior(IMessageBoxService messageBoxService)
        {
            this.messageBoxService = messageBoxService;
        }

        protected override void OnAttached()
        {
            Window window = this.AssociatedObject;

            window.Closing += Window_Closing;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!messageBoxService.ShowMessage("Are you sure?", "Close Behavior"))
            {
                e.Cancel = true;
            }    
        }
    }
}
