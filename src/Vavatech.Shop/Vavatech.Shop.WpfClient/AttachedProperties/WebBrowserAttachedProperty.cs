using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Vavatech.Shop.WpfClient.AttachedProperties
{
    public static class WebBrowserAttachedProperty
    {
        public static readonly DependencyProperty BindableSourceProperty =
            DependencyProperty.RegisterAttached("BindableSource",
                typeof(string), typeof(WebBrowserAttachedProperty), new PropertyMetadata(null, BindableSourcePropertyChanged));

        private static void BindableSourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var webBrowser = (WebBrowser)d;

            webBrowser.Source = new Uri( (string) e.NewValue);
        }

        public static string GetBindableSource(DependencyObject obj)
        {
            return (string)obj.GetValue(BindableSourceProperty);
        }

        public static void SetBindableSource(DependencyObject obj, string value)
        {
            obj.SetValue(BindableSourceProperty, value);
        }
    }
}
