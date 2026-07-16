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

        }
        private void UpdateViewProducts()
        {
            if (currentProducts.Count > pagecount * 6)
            {
                ViewProducts = new ObservableCollection<Product>(currentProducts.GetRange((pagecount - 1) * 6, 6));
            }
            else
            {
                
                ViewProducts = new ObservableCollection<Product>(currentProducts.GetRange((pagecount - 1) * 6, currentProducts.Count));
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
    }
}
