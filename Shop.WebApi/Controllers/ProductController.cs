using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shop.WebStoreDataContracts.Models;
using Shop.WebStoreDataContracts.Interfaces;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;

namespace Shop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors()]
    public class ProductController : ControllerBase
    {
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        
        public async Task<ActionResult<IList<Product>>> Get(ProductFilter filter)
        {            
            var vm = await _productService.GetProductsAsync(filter);
            return Ok(vm);
        }
    }
}
