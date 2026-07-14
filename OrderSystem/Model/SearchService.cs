using OrderSystem.Model.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Model
{
    public class SearchService
    {
        private readonly IProductRepository _productRepository;
        public SearchService(IProductRepository productRepository )
        {
            _productRepository = productRepository;
        }
        public List<Product> Search(string keyword)
        {
            var allProducts = _productRepository.getAll();
            return allProducts.Where(p => p.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
        }

    }
}
