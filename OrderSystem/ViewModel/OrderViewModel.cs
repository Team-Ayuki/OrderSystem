using OrderSystem.Common;
using OrderSystem.Model;
using OrderSystem.Model.Table;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.ViewModel
{
    public class OrderViewModel : ViewModelBase, IPageViewModel
    {
        IOrderService orderService;
        IProductRepository productRepository;
        private string _title = "Order";

        private List<Product> allproducts = new List<Product>();
        private ObservableCollection<Product> _viewProducts = new ObservableCollection<Product>();
        public ObservableCollection<Product> ViewProducts
        {
            get => _viewProducts;
            set => SetField(ref _viewProducts, value);
        }

        public string Title
        {
            get => _title;
            set => SetField(ref _title, value);
        }

        public OrderViewModel(IOrderService orderService, IProductRepository productRepository)
        {
            this.orderService = orderService;
            this.productRepository = productRepository;
            // Initialize any necessary properties or commands here
            allproducts = productRepository.getAll().ToList();

        }

        private void UpdateViewProducts(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                ViewProducts = new ObservableCollection<Product>(allproducts);
            }
            else
            {
                var filteredProducts = allproducts.Where(p => p.name.Contains(searchText, StringComparison.OrdinalIgnoreCase)).ToList();
                ViewProducts = new ObservableCollection<Product>(filteredProducts);
            }
        }
        private void SearchProducts(string searchText)
        {
            UpdateViewProducts(searchText);
        }
    }
}
