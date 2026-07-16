using OrderSystem.Common;
using OrderSystem.Model;
using OrderSystem.Model.Table;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace OrderSystem.ViewModel
{
    class HistoryViewModel : ViewModelBase,IPageViewModel
    {
        IHistoryService _historyService;

        INavigationService _navigationService;

        private string _title = "History";
        public string Title
        {
            get => _title;
            set => SetField(ref _title, value);
        }

        private List<OrderItem> _orderHistory;
        public List<OrderItem> OrderHistory
        {
            get => _orderHistory;
            set => SetField(ref _orderHistory, value);
        }
        private decimal _totalAmount = 0;
        public decimal TotalAmount
        {
            get => _totalAmount;
            set => SetField(ref _totalAmount, value);
        }
        public ICommand BackCommand { get; set; }

        public HistoryViewModel(IHistoryService historyService, INavigationService navigationService)
        {
            _historyService = historyService;
            _navigationService = navigationService;
            // Initialize any necessary properties or commands here
            OrderHistory = historyService.getHistory();
            TotalAmount = CalcTotalAmount();
            BackCommand = new RelayCommand<object>(o => BackButtonExecute());

        }

        private decimal CalcTotalAmount()
        {
            decimal totalamount = 0;
            foreach (var item in OrderHistory)
            {
                totalamount += item.product.price * item.Count;
            }
            return totalamount;
        }

        private void BackButtonExecute()
        {
            _navigationService.NavigateTo("Order");
        }
    }
}
