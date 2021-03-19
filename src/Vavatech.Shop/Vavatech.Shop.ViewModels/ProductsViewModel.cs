using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;
using Vavatech.Shop.ViewModels.Common;

namespace Vavatech.Shop.ViewModels
{
    public class ProductsViewModel : EntitiesViewModel<Product>
    {
        public IEnumerable<string> Colors { get; set; }

        public BindingList<Product> Products => Entities;

        private readonly IProductService productService;

        public ICommand RecalculateCommand { get; private set; }

        public ProductsViewModel(IProductService productService) : base(productService)
        {
            this.productService = productService;

            RecalculateCommand = new DelegateCommand(async ()=>await RecalculateAsync());
        }

        protected override void Load()
        {
            base.Load();

            Colors = Products.Select(p => p.Color).Distinct().ToList();
        }


        private async Task RecalculateAsync()
        {
            await productService.RecalculateAsync(Products);
        }
    }
}
