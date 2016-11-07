using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryAndUnitOfWorkPatterns.EntityFramework;
using RepositoryAndUnitOfWorkPatterns.Repositories;

namespace RepositoryAndUnitOfWorkPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var unitOfWork = new UnitOfWork(new AppContext()))
            {
                // Example1
                var customer1 = unitOfWork.Customers.Get(1);

                // Example2
                var orders = unitOfWork.Orders.GetOrdersWithLines(1);

                // Example3
                var customer = unitOfWork.Customers.GetCustomerWithOrders(1);
                if (customer != null)
                {
                    unitOfWork.Orders.RemoveRange(customer.Orders);
                    unitOfWork.Customers.Remove(customer);
                    unitOfWork.Complete();                    
                }
                
            }
        }
    }
}
