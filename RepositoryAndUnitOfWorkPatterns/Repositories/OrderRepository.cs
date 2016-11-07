using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryAndUnitOfWorkPatterns.Domain;
using RepositoryAndUnitOfWorkPatterns.EntityFramework;
using RepositoryAndUnitOfWorkPatterns.Repositories.Interfaces;

namespace RepositoryAndUnitOfWorkPatterns.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public AppContext AppContext
        {
            get { return Context as AppContext; }
        }

        public OrderRepository(AppContext context) : base(context)
        {

        }

        public IEnumerable<Order> GetOrdersWithLines(int idOrder)
        {
            return AppContext.Orders.Include(x => x.OrderLines).Where(x => x.Id == idOrder).ToList();
        }
    }
}
