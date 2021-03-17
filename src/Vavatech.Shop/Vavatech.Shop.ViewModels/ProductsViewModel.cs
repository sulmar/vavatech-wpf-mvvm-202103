using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.ViewModels
{
    public class ProductsViewModel : EntitiesViewModel<Product>
    {
        public IEnumerable<string> Colors { get; set; }

        public BindingList<Product> Products => Entities;

        public ProductsViewModel(IProductService productService) : base(productService)
        {
        }

        protected override void Load()
        {
            base.Load();

            Colors = Products.Select(p => p.Color).Distinct().ToList();
        }
    }
}
