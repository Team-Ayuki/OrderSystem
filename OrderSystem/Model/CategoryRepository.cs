using OrderSystem.Migrations;
using OrderSystem.Model.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Model
{
    public class CategoryRepository : ICategoryRepository
    {
        List<MidCategory> midCategories = new List<MidCategory>();
        List<BigCategory> bigCategories = new List<BigCategory>();
        public CategoryRepository() 
        {
            using (SushiDBContext context = new())
            {
                
                midCategories = context.MidCategory.ToList();
                bigCategories = context.BigCategory.ToList();
            }

        }
        public List<MidCategory> searchMidCategory(BigCategory bigCategory)
        {
            return midCategories.Where(x => x.BigCategoryId == bigCategory.Id).ToList();
        }
        public List<BigCategory> getAllBigCategory()
        {
            return bigCategories;
        }
    }
}
