using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Store.Application.UnitTests.Common
{
    public class StoreContextFactory
    {
        public static StoreDbContext Create()
        {
            var options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new StoreDbContext(options);

            context.Database.EnsureCreated();

            context.Customers.AddRange(new[] {
                new Customer { CustomerId = "12345", CustomerName = "Hossein Edraki" },
                new Customer { CustomerId = "67890", CustomerName = "Vahid Tajari" }
            });

            context.Orders.Add(new Order
            {
                CustomerId = "67890"
            });

            context.SaveChanges();

            return context;
        }
    }
}