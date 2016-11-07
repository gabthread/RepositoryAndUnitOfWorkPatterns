using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryAndUnitOfWorkPatterns.Domain;
using RepositoryAndUnitOfWorkPatterns.EntityFramework.EntityConfigurations;

namespace RepositoryAndUnitOfWorkPatterns.EntityFramework
{
    public class AppContext : DbContext
    {
        public AppContext(): base("appConnectionString")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Customer> Customers  { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderLine> OrderLines { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
        }
    }
}
