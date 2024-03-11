using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;
public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Order", "dbo");

        builder.Property(b => b.UserId).IsRequired();
        builder.Property(b => b.RequestPayId).IsRequired();
        builder.Property(b => b.AddressId).IsRequired();
        builder.Property(b => b.OrderState).IsRequired();
    }
}