using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(e => e.OrderId).HasColumnName("OrderId");

            builder.Property(e => e.CustomerId)
                .HasColumnName("CustomerId")
                .HasMaxLength(5);

            builder.Property(e => e.OrderDate).HasColumnType("datetime");


            builder.Property(e => e.ShipAddress).HasMaxLength(60);


            builder.Property(e => e.ShipName).HasMaxLength(40);
        }
    }
}
