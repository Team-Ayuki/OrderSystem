using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Model
{
    public interface IOrderCart
    {
        public void addCart(Product product);
        public void reduceCart(Product product);
        public OrderItem[] getCart();
        public void Clear();

    }
}
