using System;

namespace RepositoryAndUnitOfWorkPatterns.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get;}
        IOrderRepository Orders { get;}
        int Complete();
    }
}
