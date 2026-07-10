using OrderSystem.Common;
using OrderSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.ViewModel
{
    public class OrderViewModel: ViewModelBase,IPageViewModel
    {
        IOrderService orderService;
        private string _title = "CheckOut";
        public string Title
        {
            get => _title;
            set => SetField(ref _title, value);
        }

        public OrderViewModel(IOrderService orderService)
        {
            this.orderService = orderService;
            // Initialize any necessary properties or commands here
        }
    }
}
