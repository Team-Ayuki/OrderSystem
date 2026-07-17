using OrderSystem.Model.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Model
{
    public class BillHistoryService : IBillHistoryService
    {
        public int addHistory(List<OrderItem> orderList)
        {
            using (SushiDBContext context = new())
            {
                DateTime now = DateTime.Now;
                Bill currentBill = new Bill()
                {
                    Date = now,
                    Orders = MakeOrders(orderList)
                };
                context.Bills.Add(currentBill);
                context.SaveChanges();
                return context.Bills.FirstOrDefault(x=>x.Date == now).Id;
            }
        }

        private List<Order> MakeOrders(List<OrderItem> orderItems)
        {
            List<Order> orders = new List<Order>();
            foreach (OrderItem item in orderItems)
            {
                for (int i = 0; i < item.Count; i++)
                {
                    orders.Add(new Order()
                    {
                        ProductId = item.product.Id
                    });
                }
            }

            return orders;
        }
    }
}
