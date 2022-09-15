using Shop.WebStoreDataContracts.Models;
using Shop.WebStoreDataContracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NLog;

namespace Shop.Application
{
    public class ProductService : IProductService
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        private IEnumerable<IStorePartnerstService> _storesPartnerstServices;

        public ProductService(IEnumerable<IStorePartnerstService> storesPartnerstServices)
        {
            _storesPartnerstServices = storesPartnerstServices;
        }

        public async Task<IList<Product>> GetProductsAsync(ProductFilter filter, CancellationToken cancellationToken)
        {
            List<Product> products = new List<Product>();
            var tasks = new List<Task<IList<Product>>>();
            foreach (var service in _storesPartnerstServices)
            {
                tasks.Add(service.GetProductsAsync(filter, cancellationToken));
            }

            await Task.WhenAll(tasks);

            foreach (var task in tasks)
            {
                try
                {
                    var results = await task;
                    products.AddRange(results);
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }
            }

            return products;
        }
    }
}
