using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RepositoryAndUnitOfWorkPatterns.Domain;

namespace RepositoryAndUnitOfWorkPatterns.EntityFramework.EntityConfigurations
{
    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            HasRequired(c => c.Customer)
                .WithMany(a => a.Orders)
                .HasForeignKey(c => c.CustomerId)
                .WillCascadeOnDelete(false);
        }
    }
}
