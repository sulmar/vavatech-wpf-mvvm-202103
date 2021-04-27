using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MetalDesignWpfClient.AttachedProperty
{

    public class MyAssist
    {
        public int Minimum { get; set; }
        public int Maximum { get; set; }        
    }

    public class NumericRange  : DependencyObject
    {
        public static readonly DependencyProperty IsNumericRangeProperty = DependencyProperty.RegisterAttached("IsNumericRange",
           typeof(MyAssist),
           typeof(Numeric),
           new PropertyMetadata(ValidateRange));

        private static void ValidateRange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBox textBox)
            {
                textBox.PreviewTextInput += (sender, args) =>
                {
                    if (!char.IsNumber(args.Text[0]))
                    {
                        args.Handled = true;
                    }
                };
            }
        }

        public static MyAssist GetIsNumeric(DependencyObject d)
        {
            return (MyAssist)d.GetValue(IsNumericRangeProperty);
        }

        public static void SetIsNumeric(DependencyObject d, MyAssist value)
        {
            d.SetValue(IsNumericRangeProperty, value);
        }
    }


    public class Numeric : DependencyObject
    {
        public static readonly DependencyProperty IsNumericProperty = DependencyProperty.RegisterAttached("IsNumeric",
            typeof(bool),
            typeof(Numeric),
            new PropertyMetadata(AllowOnlyNumeric));

        private static void AllowOnlyNumeric(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBox textBox)
            {
                textBox.PreviewTextInput += (sender, args) =>
                {
                    if (!char.IsNumber(args.Text[0]))
                    {
                        args.Handled = true;
                    }
                };
            }
        }

        public static bool GetIsNumeric(DependencyObject d)
        {
            return (bool)d.GetValue(IsNumericProperty);
        }

        public static void SetIsNumeric(DependencyObject d, bool value)
        {
            d.SetValue(IsNumericProperty, value);
        }

    }
}
