using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrderSystem.Model;
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
        private readonly ServiceProvider _serviceProvider;
        public App()
        {
            var services = new ServiceCollection();

            services.AddDbContext<SushiDBContext>(options =>
            options.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;
                Database=SushiDB;
                Trusted_Connection=True;"));

            _serviceProvider = services.BuildServiceProvider();
        }
    }

}
