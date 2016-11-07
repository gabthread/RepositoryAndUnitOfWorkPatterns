using System.Data.Entity;
using System.Linq;
using RepositoryAndUnitOfWorkPatterns.Domain;
using RepositoryAndUnitOfWorkPatterns.EntityFramework;
using RepositoryAndUnitOfWorkPatterns.Repositories.Interfaces;

namespace RepositoryAndUnitOfWorkPatterns.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public AppContext AppContext
        {
            get { return Context as AppContext; }
        }
        public CustomerRepository(AppContext context) : base(context)
        {
            
        }
        
        public Customer GetCustomerWithOrders(int idCustomer)
        {
            return AppContext.Customers.Include(x => x.Orders).SingleOrDefault(x => x.Id == idCustomer);
        }
    }
}
