using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Model
{
    interface ICategoryRepository
    {
        public List<Category> getAllCategory();
    }
}
