using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace MetalDesignWpfClient.AttachedProperty
{
    public class Mask : DependencyObject
    {
        public static string GetFormat(DependencyObject d)
        {
            return (string)d.GetValue(FormatProperty);
        }

        public static void SetFormat(DependencyObject d, string value)
        {
            d.SetValue(FormatProperty, value);
        }

        // Using a DependencyProperty as the backing store for Regex.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FormatProperty =
            DependencyProperty.RegisterAttached("Format", typeof(string), typeof(Mask), new PropertyMetadata(ValidateByRegex));

        private static void ValidateByRegex(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBox textBox)
            {
                textBox.TextChanged += (sender, args) =>
                {
                    TextBox textBox1 = sender as TextBox;

                    string format = e.NewValue.ToString();

                    if ( !Regex.IsMatch(textBox1.Text, format))
                    {
                        args.Handled = true;
                    }
                };
            }
        }
    }
}
