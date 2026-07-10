using OrderSystem.Model.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Model
{
    public interface IOrderService
    {
        public bool Order();
        public bool addProduct(Product product);
        public bool reduceProduct(Product product);
        public OrderItem[] getOrderCart();
    }
}
