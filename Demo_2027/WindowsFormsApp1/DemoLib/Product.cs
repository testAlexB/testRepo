using System.Collections.Generic;

namespace DemoLib
{
    public class Product
    {
        public string Category { get; set; }

        public int Count { get; set; }

        public List<string> Parts {  get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; }

        public string Supplier { get; set; }

        public string ImagePath { get; set; }

    }
}
