using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Model
{
    public class HistoryService : IHistoryService
    {
        private readonly List<OrderItem> historyList = new List<OrderItem>();

        public void addHistory(List<OrderItem> orderItems)
        {
            historyList.AddRange(orderItems);
        }

        public List<OrderItem> getHistory()
        {
            return historyList;
        }
    }
}
