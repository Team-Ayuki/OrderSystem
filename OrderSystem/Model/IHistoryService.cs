using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Model
{
    public interface IHistoryService
    {
        public List<OrderItem> getHistory();
        public void addHistory(OrderItem orderItem);
    }
}
