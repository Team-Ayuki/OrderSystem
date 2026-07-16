using OrderSystem.Common;
using OrderSystem.Model;
using OrderSystem.Model.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OrderSystem.ViewModel
{
    class CheckOutViewModel : ViewModelBase, IPageViewModel
    {
        IHistoryService _historyService;

        INavigationService _navigationService;
        ICheckOutService _checkOutService;

        private string _title = "CheckOut";
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

        public ICommand CheckOutCommand { get; set; }
        public ICommand BackCommand { get; set; }

        public CheckOutViewModel(ICheckOutService checkOutService, IHistoryService historyService, INavigationService navigationService)
        {
            // Initialize any necessary properties or commands here
            _checkOutService = checkOutService;
            _historyService = historyService;   
            _navigationService = navigationService;

            OrderHistory = historyService.getHistory();
            TotalAmount = CalcTotalAmount();

            CheckOutCommand = new RelayCommand<object>(o => CheckOutButtonExecute());
            BackCommand = new RelayCommand<object>(o => BackButtonExecute());
        }

        private void CheckOutButtonExecute()
        {
            int billId = _checkOutService.checkOut(OrderHistory);
            MessageBoxResult result = MessageBox.Show($"会計が完了しました。会計ID:{billId}");
            _historyService.Clear();
            _navigationService.NavigateTo("Start");
        }
        private decimal CalcTotalAmount()
        {
            decimal totalamount = 0;
            foreach(var item in OrderHistory)
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
