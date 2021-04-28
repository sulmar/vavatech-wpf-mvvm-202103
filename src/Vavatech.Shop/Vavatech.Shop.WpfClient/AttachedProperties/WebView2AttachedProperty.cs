using Microsoft.Web.WebView2.Wpf;
using System;
using System.Windows;

namespace Vavatech.Shop.WpfClient.AttachedProperties
{
    public static class WebView2AttachedProperty
    {
        public static readonly DependencyProperty BindableSourceProperty =
            DependencyProperty.RegisterAttached("BindableSource",
                typeof(string), typeof(WebView2AttachedProperty), new PropertyMetadata(null, BindableSourcePropertyChanged));

        private static void BindableSourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var webBrowser = (WebView2)d;

            webBrowser.Source = new Uri((string)e.NewValue);
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
