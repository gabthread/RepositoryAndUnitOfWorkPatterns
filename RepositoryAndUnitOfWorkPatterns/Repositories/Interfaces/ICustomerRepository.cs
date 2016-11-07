using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryAndUnitOfWorkPatterns.Domain;

namespace RepositoryAndUnitOfWorkPatterns.Repositories.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetCustomerWithOrders(int idCustomer);
    }
}
