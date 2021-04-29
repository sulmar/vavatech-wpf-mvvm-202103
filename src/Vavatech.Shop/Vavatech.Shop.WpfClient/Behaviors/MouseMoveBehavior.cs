using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Vavatech.Shop.WpfClient.Behaviors
{
    public class MouseMoveBehavior : Behavior<Selector>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.MouseMove += AssociatedObject_MouseMove;
        }

        private void AssociatedObject_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Selector selector = sender as Selector;

                DragDrop.DoDragDrop(selector, selector.SelectedItem, DragDropEffects.Move);
            }
        }
    }
}
