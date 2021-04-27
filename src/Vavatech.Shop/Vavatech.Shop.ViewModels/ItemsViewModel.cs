using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private readonly IProductService productService;
        private readonly IServiceService serviceService;

        public ItemsViewModel(IProductService productService, IServiceService serviceService)
        {
            this.productService = productService;
            this.serviceService = serviceService;

            Load();
        }

        private void Load()
        {
            var products = productService.Get();
            var services = serviceService.Get();

            Items = products.OfType<Item>().Union(services);
        }

        public IEnumerable<Item> Items { get; set; }


    }
}
