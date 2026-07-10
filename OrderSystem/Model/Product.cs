using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Model
{
    public class Product
    {
        public string name { get; private set; }
        public decimal price { get; private set; }
        public string imgFilePath { get; private set; }
        public string bigCategory { get; private set; }
        public string midCategory { get; private set; }
        public Product(string name, decimal price, string imgFilePath, string bigCategory, string midCategory)
        {
            this.name = name;
            this.price = price;
            this.imgFilePath = imgFilePath;
            this.bigCategory = bigCategory;
            this.midCategory = midCategory;
        }
    }
}
