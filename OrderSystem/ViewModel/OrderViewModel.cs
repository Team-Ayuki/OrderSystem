using OrderSystem.Common;
using OrderSystem.Model;
using OrderSystem.Model.Table;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OrderSystem.ViewModel
{
    public class OrderViewModel : ViewModelBase, IPageViewModel
    {
        IOrderService orderService;
        IProductRepository productRepository;
        ISearchService searchService;
        INavigationService navigationService;

        private int pagecount = 1;
        

        private List<Product> allproducts = new List<Product>();
        private ObservableCollection<Product> _viewProducts = new ObservableCollection<Product>();
        public ObservableCollection<Product> ViewProducts
        {
            get => _viewProducts;
            set => SetField(ref _viewProducts, value);
        }
        private List<BigCategory> _bigCategories = new List<BigCategory>();
        public List<BigCategory> BigCategories 
        { 
            get => _bigCategories; 
            set => SetField(ref _bigCategories, value); 
        } 

        private ObservableCollection<MidCategory> _midCategories = new ObservableCollection<MidCategory>();
        public ObservableCollection<MidCategory> MidCategories
        {
            get => _midCategories;
            set => SetField(ref _midCategories, value);
        }

        private OrderItem _selectedItem;
        public OrderItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (value != null)
                {
                    SetField(ref _selectedItem, value);
                    SelectedProductCount = value.Count;
                    SelectedProductFilePath = value.product.imgFilePath;
                }
                else
                {
                    SelectedProductCount = 0;
                    SelectedProductFilePath = string.Empty;
                }

            }
        }

        private string _selectedProductFilePath = string.Empty;
        public string SelectedProductFilePath
        {
            get => _selectedProductFilePath;
            set => SetField(ref _selectedProductFilePath, value);
        }
        private int _selectedProductCount = 0;
        public int SelectedProductCount
        {
            get => _selectedProductCount;
            set => SetField(ref _selectedProductCount, value);
        }

        private ObservableCollection<OrderItem> _orderCart = new ObservableCollection<OrderItem>();
        public ObservableCollection<OrderItem> orderCart
        {
            get => _orderCart;
            set => SetField(ref _orderCart, value);
        }

        private string _title = "Order";
        public string Title
        {
            get => _title;
            set => SetField(ref _title, value);
        }
        private List<Product> currentProducts = new();
        public ICommand MidCategoryCommand { get; set; }
        public ICommand BigCategoryCommand { get; set; }
        public ICommand ProductCommand { get; set; }
        public ICommand RightCommand { get; set; }
        public ICommand LeftCommand { get; set; }
        public ICommand PlusCommand { get; set; }
        public ICommand MinusCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand OrderCommand { get; set;}
        public ICommand CheckOutCommand { get; set; }
        public ICommand HistoryCommand { get; set; }
        public ICommand TopCommand { get; set; }

        public OrderViewModel(IOrderService orderService, IProductRepository productRepository, ISearchService searchService, INavigationService navigationService)
        {
            this.orderService = orderService;
            this.productRepository = productRepository;
            this.searchService = searchService;
            this.navigationService = navigationService;
            BigCategories = searchService.getAllBigCategory();
            // Initialize any necessary properties or commands here
            allproducts = productRepository.getAll().ToList();
            MidCategoryCommand = new RelayCommand<MidCategory>(m => MidCategoryExecute(m));
            BigCategoryCommand = new RelayCommand<BigCategory>(b => BigCategoryExecute(b));
            RightCommand = new RelayCommand<object>(o => RightButtonExecute());
            LeftCommand = new RelayCommand<object>(o => LeftButtonExecute());
            ProductCommand = new RelayCommand<Product>(ProductButtonExecute);
            PlusCommand = new RelayCommand<OrderItem>(PlusButtonExecute);
            MinusCommand = new RelayCommand<OrderItem>(MinusButtonExecute);
            DeleteCommand = new RelayCommand<OrderItem>(DeleteButtonExecute);
            OrderCommand = new RelayCommand<object>(o =>  OrderButtonExecute());
            CheckOutCommand = new RelayCommand<object>(o => CheckOutButtonExecute());
            HistoryCommand = new RelayCommand<object>(o =>  HistoryButtonExecute());
            TopCommand = new RelayCommand<object>(o =>  TopButtonExecute());

            UpdateOrderCart();

            orderCart.CollectionChanged += (s, e) => UpdateOrderCart();
        }
        private void UpdateViewProducts()
        {
            int startIndex = (pagecount - 1) * 6;
            int remaining = currentProducts.Count - startIndex;
            int takeCount = Math.Min(6, remaining);
            if (takeCount <= 0)
            {
                ViewProducts = new ObservableCollection<Product>();
            }
            else
            {
                
                ViewProducts = new ObservableCollection<Product>(currentProducts.GetRange(startIndex, takeCount));
            }
        }

        private void UpdateOrderCart()
        {
            orderCart = new ObservableCollection<OrderItem>(orderService.getOrderCart());
        }
        
        private void MidCategoryExecute(MidCategory midcategory)
        {
            pagecount = 1;
            currentProducts = searchService.searchProduct(midcategory).ToList();
            UpdateViewProducts();
        }
        private void BigCategoryExecute(BigCategory bigCategory)
        {
            MidCategories = new ObservableCollection<MidCategory>(bigCategory.MidCategories.ToList());
        }

        private void LeftButtonExecute()
        {
            if (pagecount > 1)
            {
                pagecount--;
                UpdateViewProducts();
            }

        }
        private void RightButtonExecute()
        {
            if (currentProducts.Count - 6 > 6 * (pagecount - 1))
            {
                pagecount++;
                UpdateViewProducts();
            }
        }
        private void ProductButtonExecute(Product product)
        {
            //OrderServiceに商品追加の処理
            if (orderService.addProduct(product))
            {
                UpdateOrderCart();
                SelectedItem = orderCart.First(x => x.product.Id == product.Id);
            }
        }

        private void PlusButtonExecute(OrderItem orderItem)
        {
            orderItem.CountPlus();
            SelectedProductCount = orderItem.Count;
            UpdateOrderCart();
        }
        private void MinusButtonExecute(OrderItem orderItem)
        {
            orderItem.CountMinus();
            SelectedProductCount = orderItem.Count;
            UpdateOrderCart();
        }
        private void DeleteButtonExecute(OrderItem orderItem)
        {
            orderService.removeOrderItem(orderItem);
            UpdateOrderCart();
            SelectedProductCount = 0;
        }
        private void OrderButtonExecute()
        {
            if (orderService.Order())
            {
                UpdateOrderCart();
                SelectedProductCount = 0;
                MessageBox.Show("注文しました。");
            }
        }
        private void CheckOutButtonExecute()
        {
            navigationService.NavigateTo("CheckOut");
        }
        private void HistoryButtonExecute()
        {
            navigationService.NavigateTo("History");
        }
        private void TopButtonExecute()
        {
            navigationService.NavigateTo("Start");
        }
    }
}
