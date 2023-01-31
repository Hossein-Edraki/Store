using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application
{
    public interface IStoreDbContext
    {
        DbSet<OrderDetail> OrderDetails { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Customer> Customers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}