using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Model
{
    public class CheckOutService : ICheckOutService
    {
        IBillHistoryService billHistoryService;
        public CheckOutService(IBillHistoryService billHistoryService) 
        {
            this.billHistoryService = billHistoryService;
        }

        public int checkOut(List<OrderItem> orderList)
        {
            return billHistoryService.addHistory(orderList);
        }
    }
}
