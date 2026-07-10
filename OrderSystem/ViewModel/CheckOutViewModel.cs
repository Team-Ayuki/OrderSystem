using OrderSystem.Common;
using OrderSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.ViewModel
{
    class CheckOutViewModel : ViewModelBase, IPageViewModel
    {
        IHistoryService _historyService;
        ICheckOutService _checkOutService;

        private string _title = "CheckOut";
        public string Title
        {
            get => _title;
            set => SetField(ref _title, value);
        }

        public CheckOutViewModel(ICheckOutService checkOutService, IHistoryService historyService)
        {
            // Initialize any necessary properties or commands here
            _checkOutService = checkOutService;
            _historyService = historyService;   
        }
    }
}
