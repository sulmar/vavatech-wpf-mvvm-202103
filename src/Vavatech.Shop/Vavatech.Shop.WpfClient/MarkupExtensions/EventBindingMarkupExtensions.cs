using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.WpfClient.MarkupExtensions
{
    public class MouseMoveMarkupExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new MouseEventHandler(OnMouseEventHandler);
        }

        private void OnMouseEventHandler(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Selector selector = sender as Selector;  

                DragDrop.DoDragDrop(selector, selector.SelectedItem, DragDropEffects.Move);
            }
        }
    }
}
