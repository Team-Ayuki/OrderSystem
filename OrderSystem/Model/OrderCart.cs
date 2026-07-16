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
       

        public void addCart(Product product)
        {
            
            bool itemAddflag = false;
          
            

            foreach(OrderItem item in OrderCartin)
            {
                if (item.getProduct() == product)
                {
                    itemAddflag = item.CountPlus();
                }
            }
            if (!itemAddflag && OrderCartin.Count < 4)
            {
                OrderCartin.Add(new OrderItem(1, product));
                itemAddflag = true;
            }

        }

        public void Clear()
        {
            OrderCartin.Clear();

        }


        public OrderItem[] getCart()
        {
            
            return OrderCartin.ToArray();

        }

        public void reduceCart(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
