using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryAndUnitOfWorkPatterns.Domain;

namespace RepositoryAndUnitOfWorkPatterns.EntityFramework.EntityConfigurations
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            Property(x => x.Name).HasMaxLength(200);
            Property(x => x.LastName).HasMaxLength(200);
            Property(x => x.Address).HasMaxLength(400);
        }
    }
}
