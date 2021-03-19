using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
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
        private int currentId;

        public ICommand RecalculateCommand { get; private set; }
        public ICommand CancelRecalculateCommand { get; private set; }

        public ProductsViewModel(IProductService productService) : base(productService)
        {
            this.productService = productService;

            RecalculateCommand = new DelegateCommand(async () => await RecalculateAsync());
            CancelRecalculateCommand = new DelegateCommand(CancelRecalculate);
        }

        protected override void Load()
        {
            base.Load();

            Colors = Products.Select(p => p.Color).Distinct().ToList();
        }

        public int CurrentId
        {
            get => currentId; set
            {
                currentId = value;
                OnPropertyChanged();
            }
        }


        CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));

        private async Task RecalculateAsync()
        {
            IProgress<int> progress = new Progress<int>(id => CurrentId = id);

            CancellationToken cancellationToken = cts.Token;

            await productService.RecalculateAsync(Products, cancellationToken, progress);
          
        }

        private void CancelRecalculate()
        {
            // cts.Cancel();

            cts.CancelAfter(TimeSpan.FromSeconds(5));
        }
    }
}
