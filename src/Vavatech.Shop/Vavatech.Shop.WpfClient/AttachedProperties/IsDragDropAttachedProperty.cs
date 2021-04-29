using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Vavatech.Shop.WpfClient.AttachedProperties
{
    public class IsDragDropAttachedProperty
    {
        public static readonly DependencyProperty IsDragDropProperty =
            DependencyProperty.RegisterAttached("IsDragDrop",
                typeof(bool), typeof(Selector), new PropertyMetadata(false, IsDragDropPropertyChanged));

        private static void IsDragDropPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var selector = (Selector)d;

            if ((bool)e.NewValue)
            {
                selector.MouseMove += Selector_MouseMove;
            }
            else
            {
                selector.MouseMove -= Selector_MouseMove;
            }
        }

        private static void Selector_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Selector selector = sender as Selector;

                DragDrop.DoDragDrop(selector, selector.SelectedItem, DragDropEffects.Move);
            }
        }

        public static bool GetIsDragDrop(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsDragDropProperty);
        }

        public static void SetIsDragDrop(DependencyObject obj, bool value)
        {
            obj.SetValue(IsDragDropProperty, value);
        }
    }
}
