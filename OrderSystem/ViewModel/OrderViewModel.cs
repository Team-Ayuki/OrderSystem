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
using System.Windows.Input;

namespace OrderSystem.ViewModel
{
    public class OrderViewModel : ViewModelBase, IPageViewModel
    {
        IOrderService orderService;
        IProductRepository productRepository;
        ISearchService searchService;

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

        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get => _selectedProduct;
            set => SetField(ref _selectedProduct, value);
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

        public OrderViewModel(IOrderService orderService, IProductRepository productRepository, ISearchService searchService)
        {
            this.orderService = orderService;
            this.productRepository = productRepository;
            this.searchService = searchService;
            BigCategories = searchService.getAllBigCategory();
            // Initialize any necessary properties or commands here
            allproducts = productRepository.getAll().ToList();
            MidCategoryCommand = new RelayCommand<MidCategory>(m => MidCategoryExecute(m));
            BigCategoryCommand = new RelayCommand<BigCategory>(b => BigCategoryExecute(b));
            RightCommand = new RelayCommand<object>(o => RightButtonExecute());
            LeftCommand = new RelayCommand<object>(o => LeftButtonExecute());
            ProductCommand = new RelayCommand<Product>(ProductButtonExecute);   
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
            SelectedProduct = product;
            //OrderServiceに商品追加の処理
            orderService.addProduct(product);
            orderCart = new ObservableCollection<OrderItem>(orderService.getOrderCart());
        }
    }
}
