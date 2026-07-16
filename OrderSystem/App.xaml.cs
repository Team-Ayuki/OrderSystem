using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrderSystem.Model;
using OrderSystem.View;
using OrderSystem.ViewModel;
using System;
using System.Configuration;
using System.Data;
using System.Windows;

namespace OrderSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {

        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var productRepository = new ProductRepository("db path");
            var categoryRepository = new CategoryRepository();
            
            var checkOutService = new CheckOutService();
            var historyService = new HistoryService();
            var searchService = new SearchService(productRepository,categoryRepository);
            var orderService = new OrderService(new OrderCart(), historyService);

            var nav = new NavigationService();
            nav.Register("Order", () => new OrderViewModel(orderService,productRepository,searchService));
            nav.Register("CheckOut", () => new CheckOutViewModel(checkOutService, historyService));
            nav.Register("History", () => new HistoryViewModel(historyService));

            var mainViewModel = new MainViewModel(nav);

            var mainWindow = new MainWindow { DataContext = mainViewModel };
            mainWindow.Show();
        }
    }
}
