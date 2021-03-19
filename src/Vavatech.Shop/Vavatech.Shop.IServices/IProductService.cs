using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.IServices
{
    public interface IProductService : IEntityService<Product>
    {
        Task RecalculateAsync(IEnumerable<Product> products, CancellationToken cancellationToken = default, IProgress<int> progress = null);
    }
}
