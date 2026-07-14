using OrderSystem.Migrations;
using OrderSystem.Model.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Model
{
    public class CategoryRepository
    {
        List<MidCategory> midCategories = new List<MidCategory>();
        List<BigCategory> bigCategories = new List<BigCategory>();
        public CategoryRepository() 
        {
            using (SushiDBContext context = new())
            {
                midCategories = context.MidCategories.ToList();
                bigCategories = context.BigCategories.ToList();
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
