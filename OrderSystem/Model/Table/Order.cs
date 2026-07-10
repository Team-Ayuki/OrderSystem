using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Model.Table
{
    public class Order
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public Bill bill { get; set; }

        public int ProductId { get; set; }
        public Product product { get; set; }

    }
}
