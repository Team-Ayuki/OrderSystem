using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Model.Table
{
    public class Product
    {
        public int Id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public string imgFilePath { get; set; }
        public string bigCategory { get; set; }
        public string midCategory { get; set; }
        public ICollection<Order> Orders { get; set; }
        public Product(string name, decimal price, string imgFilePath, string bigCategory, string midCategory)
        {
            this.name = name;
            this.price = price;
            this.imgFilePath = imgFilePath;
            this.bigCategory = bigCategory;
            this.midCategory = midCategory;
        }
        public Product()
        {

        }
    }
}
