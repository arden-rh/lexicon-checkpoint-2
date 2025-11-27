using System;
using System.Collections.Generic;
using System.Text;

namespace Checkpoint2
{
    public class Product(string category, string name, decimal price)
    {

        public string Category { get; set; } = category;
        public string Name { get; set; } = name;
        public decimal Price { get; set; } = price;

    }
}
