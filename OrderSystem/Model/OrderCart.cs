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
        List<OrderItem> OderCartin = new List<OrderItem>();
       

        public void addCart(Product product)
        {
            int count = 1;

            OrderItem orderItem = new OrderItem(count,product);
            OderCartin.Add(orderItem);
            


        }

        public void Clear()
        {
            OderCartin.Clear();

        }

        public OrderItem[] getCart()
        {
            
            return OderCartin.ToArray();

        }

        public void reduceCart(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
