using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(e => e.CustomerId)
                .HasColumnName("CustomerId")
                .HasMaxLength(5)
                .ValueGeneratedNever();

            builder.Property(e => e.Address).HasMaxLength(60);

            builder.Property(e => e.CustomerName)
                .IsRequired()
                .HasMaxLength(40);


            builder.Property(e => e.Phone).HasMaxLength(24);
        }
    }
}
