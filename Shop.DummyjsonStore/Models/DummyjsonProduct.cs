using System;
using System.Collections.Generic;

namespace Shop.DummyjsonStore.Models
{
    [Serializable]
    public class DummyjsonProduct
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public float Rating { get; set; }
        public int Stock { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string Thumbnail { get; set; }
        public IList<string> Images { get; set; }       
    }
}
