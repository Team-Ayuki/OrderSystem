using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Model
{
    public interface IBillHistoryService
    {
        public bool addHistory(List<OrderItem> orderList);
    }
}
