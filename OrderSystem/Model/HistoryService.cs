using OrderSystem.Model.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Model
{
    public class HistoryService : IHistoryService
    {
        private List<OrderItem> OrderList = new();
        public void addHistory(List<OrderItem> orderItems)
        {
            foreach (OrderItem orderItem in orderItems)
            {
                if (!OrderList.Contains(orderItem))
                {
                    OrderList.Add(orderItem);
                }
                else
                {
                    var currentItem = OrderList.FirstOrDefault(x => x.product == orderItem.product);
                    if (currentItem != null)
                    {
                        currentItem.Count += orderItem.Count;
                    }
                }
            }
        }

        public List<OrderItem> getHistory()
        {
            return OrderList;
        }
        public void Clear()
        {
            OrderList.Clear();
        }
    }
}
