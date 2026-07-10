using OrderSystem.Model.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Model
{
    public class ProductRepository : IProductRepository
    {
        string _dbpath;
        public List<Product> getAll()
        {
            List<Product> products = new List<Product>();
            using (var db = new SushiDBContext())
            {
                products = db.Products.ToList();
            }

            return products;
        }
        public ProductRepository(string dbpath) 
        {
            _dbpath = dbpath ?? string.Empty;
        }
    }
}
