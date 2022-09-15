using Shop.WebStoreDataContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.WebStoreDataContracts.Interfaces
{
    public interface IStorePartnerstService
    {
        public Task<IList<Product>> GetProductsAsync(ProductFilter filter, CancellationToken cancellationToken = default);
    }
}
