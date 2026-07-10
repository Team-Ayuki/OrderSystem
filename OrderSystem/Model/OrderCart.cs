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
        OrderItem[] OderCart = new OrderItem[4];
        public void addCart(Product product)
        {
           int ID = product.Id;
            string name = product.name;
            decimal price = product.price;
            string imgFilePath = product.imgFilePath;
            string bigCategory = product.bigCategory;
            string midCategory = product.midCategory;
            OrderItem orderItem = new OrderItem(ID,name, price, imgFilePath, bigCategory, midCategory);
            OderCartin.Add(orderItem);
        }

        public void Clear()
        {
            OderCartin.Clear();

        }

        public OrderItem[] getCart()
        {
            for (int i = 0; i < OderCartin.Count; i++)
            {
                OderCart[i] = OderCartin[i];
            }
            return OderCart;

        }

        public void reduceCart(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
