using Microsoft.EntityFrameworkCore;
using OrderSystem.Model.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Model
{
    public class SushiDBContext : DbContext
    {
        public SushiDBContext(DbContextOptions<SushiDBContext> options)
        : base(options)
        {

        }
        public SushiDBContext()
        {

        }
        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Bill> Bills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;
          Database=SushiDB;
          Trusted_Connection=True;");
        }
    }
}
