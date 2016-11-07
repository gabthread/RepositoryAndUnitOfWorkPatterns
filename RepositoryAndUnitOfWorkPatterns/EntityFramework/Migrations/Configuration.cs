using System.Collections.Generic;
using RepositoryAndUnitOfWorkPatterns.Domain;

namespace RepositoryAndUnitOfWorkPatterns.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RepositoryAndUnitOfWorkPatterns.EntityFramework.AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"EntityFramework\Migrations";
        }

        protected override void Seed(RepositoryAndUnitOfWorkPatterns.EntityFramework.AppContext context)
        {

            var products = new List<Product>
            {
                new Product() {Id = 1, Description = "Pencil", Price = 2m},
                new Product() {Id = 2, Description = "Chair", Price = 50m},
            };

            foreach (var product in products)
            {
                context.Products.AddOrUpdate(x=> x.Id,product);
            }

            var orderLines = new List<OrderLine>
            {
                new OrderLine() {Id = 1, ProductId = products[0].Id, Quantity = 1,OrderId = 1},
                new OrderLine() {Id = 2, ProductId = products[1].Id, Quantity = 5, OrderId = 2}
            };

            foreach (var orderLine in orderLines)
            {
                context.OrderLines.AddOrUpdate(x=> x.Id,orderLine);
            }

            var orders = new List<Order>
            {
                new Order()
                {
                    Id = 1,
                    Date = DateTime.Now.AddDays(-2),
                    IsPrepaid = false,
                    CustomerId = 1,
                    OrderLines = orderLines.Where(x=> x.OrderId == 1).ToList()
                },
                new Order()
                {
                    Id = 2,
                    Date = DateTime.Now,
                    IsPrepaid = true,
                    CustomerId = 2,
                    OrderLines = orderLines.Where(x=> x.OrderId == 2).ToList()
                }
            };

            foreach (var order in orders)
            {
                context.Orders.AddOrUpdate(x=> x.Id,order);
            }

            var customers = new List<Customer>
            {
                new Customer()
                {
                    Id = 1,
                    Name = "Peter",
                    LastName = "Brown",
                    Address = "Dublin",
                    Orders = orders.Where(x => x.CustomerId == 1).ToList()
                },
                new Customer()
                {
                    Id = 2,
                    Name = "Gabriel",
                    LastName = "Gonzalez",
                    Address = "Spain",
                    Orders = orders.Where(x => x.CustomerId == 2).ToList()
                }
            };

            foreach (var customer in customers)
            {
                context.Customers.AddOrUpdate(x => x.Id, customer);
            }
        }
    }
}
