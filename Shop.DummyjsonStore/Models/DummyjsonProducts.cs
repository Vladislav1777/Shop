using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DummyjsonStore.Models
{
    [Serializable]
    public class DummyjsonProducts
    {
        [JsonProperty("products")] public List<DummyjsonProduct> Products { get; set; }
    }
}
