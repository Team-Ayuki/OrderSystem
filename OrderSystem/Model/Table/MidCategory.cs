using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Model.Table
{
    public class MidCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BigCategoryId { get; set; }
        public BigCategory BigCategory { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
