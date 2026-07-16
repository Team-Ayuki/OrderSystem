using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Model
{
    public interface IBillHistoryService
    {
        public int addHistory(List<OrderItem> orderList);
    }
}
