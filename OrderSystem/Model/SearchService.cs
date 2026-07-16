using OrderSystem.Model.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Model
{
    public class SearchService : ISearchService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        List<Product> products = new();
        public SearchService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            products = _productRepository.getAll();
        }
        public List<BigCategory> getAllBigCategory()
        {
            return _categoryRepository.getAllBigCategory();
        }
        public List<MidCategory> searchMidCategory(BigCategory bigCategory)
        {
            return _categoryRepository.searchMidCategory(bigCategory);
        }
        public List<Product> searchProduct(MidCategory midCategory)
        {
            return products.Where(x => x.midCategoryId == midCategory.Id).ToList();

        }
    }
}
