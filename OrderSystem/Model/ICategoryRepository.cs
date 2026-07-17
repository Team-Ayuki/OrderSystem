using OrderSystem.Model.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Model
{
    public interface ICategoryRepository
    {
        public List<BigCategory> getAllBigCategory();
        public List<MidCategory> searchMidCategory(BigCategory bigCategory);
    }
}
