using OrderSystem.Model.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Model
{
    public class OrderItem
    {
        private Product product;
        private int Count = 0;

        public OrderItem(int iD, Product product, int count = 0)
        {
            this.product = product;
            this.Count = count;
        }
        public Product getProduct()
        {
            return product;
        }

        public bool CountPlus()
        {
            Count++;
            return true;
        }

        public bool CountMinus()
        {   
            if (Count > 0)
                {
                    Count--;
                    return true;
                }
                else
                {
                    return false;
            }
            
        }
    }
}
