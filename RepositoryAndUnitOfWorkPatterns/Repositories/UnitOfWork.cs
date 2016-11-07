using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryAndUnitOfWorkPatterns.EntityFramework;
using RepositoryAndUnitOfWorkPatterns.Repositories.Interfaces;

namespace RepositoryAndUnitOfWorkPatterns.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICustomerRepository Customers { get; private set;}
        public IOrderRepository Orders { get; private set; }

        private readonly AppContext _context;

        public UnitOfWork(AppContext context)
        {
            _context = context;
            Customers = new CustomerRepository(_context);
            Orders = new OrderRepository(_context);
        }
        
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
