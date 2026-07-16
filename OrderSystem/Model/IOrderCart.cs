using OrderSystem.Model.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Model
{
    public interface IOrderCart
    {
        public bool addCart(Product product);
        public bool reduceCart(Product product);
        public bool removeCart(OrderItem orderItem);
        public OrderItem[] getCart();
        public void Clear();

    }
}
