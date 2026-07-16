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
        List<OrderItem> OrderCartin = new List<OrderItem>();
       

        public bool addCart(Product product)
        {
            //int ID = product.Id;
            bool itemAddflag = false;
          
            //OrderItem orderItem = new OrderItem(ID,product);
            //OrderCartin.Add(orderItem);

            foreach(OrderItem item in OrderCartin)
            {
                if (item.getProduct().Id == product.Id)
                {
                    itemAddflag = item.CountPlus();
                }
            }
            if (!itemAddflag && OrderCartin.Count < 4)
            {
                OrderCartin.Add(new OrderItem(1, product));
                itemAddflag = true;
            }
            return itemAddflag;
        }

        public void Clear()
        {
            OrderCartin.Clear();

        }

        public OrderItem[] getCart()
        {
            
            return OrderCartin.ToArray();

        }

        public bool reduceCart(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
