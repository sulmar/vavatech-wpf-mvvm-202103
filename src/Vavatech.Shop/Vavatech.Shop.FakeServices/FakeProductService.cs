using Bogus;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.FakeServices
{

    public class FakeProductService : FakeEntityService<Product>, IProductService
    {
        public FakeProductService(Faker<Product> faker) : base(faker)
        {
        }

        public async Task RecalculateAsync(IEnumerable<Product> products, CancellationToken cancellationToken = default, IProgress<int> progress = null)
        {
            foreach(Product product in products)
            {
                // cancellationToken.ThrowIfCancellationRequested();

                if (cancellationToken.IsCancellationRequested)
                {
                    break;
                }

                product.UnitPrice += 10;

                Trace.WriteLine($"Recalculating {product.Name}...");

                await Task.Delay(TimeSpan.FromSeconds(1));

                Trace.WriteLine($"Recalculated {product.Name}.");

                progress?.Report(product.Id);
            }
        }
    }
}
