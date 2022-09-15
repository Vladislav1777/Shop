using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
using Shop.WebStoreDataContracts.Interfaces;
using Shop.WebStoreDataContracts.Models;

namespace DummyStoreApi
{
    public class DummyStoreService : IStorePartnerstService
    {

        public async Task<IList<Product>> GetProductsAsync(ProductFilter filter, CancellationToken cancellationToken = default)
        {
            IList<Product> products = new List<Product> { new Product { Id = 123, Price = 3, Brand = "chacha", Title = "Bla BLa" } };
            return products;
        }
    }
}
