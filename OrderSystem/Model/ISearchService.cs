using OrderSystem.Model.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Model
{
    public interface ISearchService
    {
        public List<MidCategory> searchMidCategory(BigCategory bigCategory);
        public List<Product> searchProduct(MidCategory midCategory);
        public List<BigCategory> getAllBigCategory();
    }
}
