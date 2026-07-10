using OrderSystem.Model.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Model
{
    public class OrderService : IOrderService
    {
        private IOrderCart orderCart;
        public bool addProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public OrderItem[] getOrderCart()
        {
            throw new NotImplementedException();
        }

        public bool Order()
        {
            throw new NotImplementedException();
        }

        public bool reduceProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public OrderService(IOrderCart orderCart)
        {
            this.orderCart = orderCart;
        }
    }
}
