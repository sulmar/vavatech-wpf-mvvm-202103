using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.WpfClient.DataTemplateSelectors
{
    public class ItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ProductDataTemplate { get; set; }
        public DataTemplate ServiceDataTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is Product)
            {
                return ProductDataTemplate;
            }

            if (item is Service)
            {
                return ServiceDataTemplate;
            }

            throw new NotSupportedException();
        }
    }
}
