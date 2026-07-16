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
        private Product _product;
        private int _count = 0;

        public int Count 
        { 
            get { return _count; } 
            set { _count = value; }
        }
        public Product product
        {
            get { return _product; }
            set { _product = value; }
        }

        public OrderItem(Product product, int count = 0)
        {
            this._product = product;
            this.Count = count;
        }
        public Product getProduct()
        {
            return _product;
        }

        public bool CountPlus()
        {
            if (Count < 4)
            {
                Count++;
                return true;
            }
            else
            {
                return false;
            }
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
