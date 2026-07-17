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
            
            bool itemAddflag = false;
          
            

            foreach(OrderItem item in OrderCartin)
            {
                if (item.getProduct().Id == product.Id)
                {
                    itemAddflag = item.CountPlus();

                    if (itemAddflag) break;
                }
            }

            if (!itemAddflag && OrderCartin.Count < 4)
            {
                OrderCartin.Add(new OrderItem(product,1));
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
            bool itemReduceflag = false;

            foreach(var item in OrderCartin)
            {
                if (item.getProduct().Id == product.Id)
                {
                    itemReduceflag = item.CountMinus();
                    if (!itemReduceflag)
                    {
                        OrderCartin.Remove(OrderCartin.First(x => x.getProduct().Id == product.Id));
                        itemReduceflag = true;
                    }
                }
            }
            return itemReduceflag;
        }
        public bool removeCart(OrderItem orderItem)
        {
            return OrderCartin.Remove(orderItem);
        }
    }
}
