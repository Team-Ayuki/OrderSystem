using OrderSystem.Model.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Model
{
    public class OrderCart : IOrderCart
    {
        public void addCart(Product product)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public OrderItem[] getCart()
        {
            throw new NotImplementedException();
        }

        public void reduceCart(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
