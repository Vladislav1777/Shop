using Newtonsoft.Json;
using Shop.WebStoreDataContracts.Models;
using Shop.DummyjsonStore.Models;
using Shop.WebStoreDataContracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NLog;

namespace Shop.DummyjsonStore
{
    public class DummyjsonStoreService : IStorePartnerstService
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        private string url = ServiceConfiguration.configuration["dummyjsonUrl"];

        public async Task<IList<Product>> GetProductsAsync(ProductFilter filter, CancellationToken cancellationToken)
        {
            string productsjson = null;

            try
            {
                HttpClient client = new HttpClient();      
                using (HttpResponseMessage response = await client.GetAsync(url))
                    if (response.IsSuccessStatusCode)
                    {
                        productsjson = await response.Content.ReadAsStringAsync();
                    }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            var products = RespJsonToModel(productsjson).Products;
            var resultproducts =  products.Where(p => 
                (string.IsNullOrEmpty(filter.Brand) || p.Brand.Contains(filter.Brand)) &&
                (string.IsNullOrEmpty(filter.Title) || p.Brand.Contains(filter.Title)) &&
                (string.IsNullOrEmpty(filter.Description) || p.Brand.Contains(filter.Description)));

            var result = Mappers.Mapper.Map<IList<Product>>(resultproducts);

            return result;
        }

        private DummyjsonProducts RespJsonToModel(string json)
        {
            DummyjsonProducts products;

            products = JsonConvert.DeserializeObject<DummyjsonProducts>(json, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            return products;
        }
    }
}
