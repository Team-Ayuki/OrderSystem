using OrderSystem.Model.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Model
{
    public class OrderService : IOrderService
    {
        private IOrderCart orderCart;
        private IHistoryService historyService;
        public bool addProduct(Product product)
        {
            return orderCart.addCart(product);
        }

        public OrderItem[] getOrderCart()
        {
            return orderCart.getCart();
        }

        public bool Order()
        {
            List<OrderItem> orderItems = orderCart.getCart().ToList();
            
            historyService.addHistory(orderItems);
            

            if (orderItems.Count > 0)
            {
                orderCart.Clear();
            }
            
            return orderItems.Count > 0;
        }
        public bool reduceProduct(Product product)
        {
            return orderCart.reduceCart(product);
        }
        public bool removeOrderItem(OrderItem orderItem)
        {
            return orderCart.removeCart(orderItem);
        }

        public OrderService(IOrderCart orderCart, IHistoryService historyService)
        {
            this.orderCart = orderCart;
            this.historyService = historyService;
        }
    }
}
