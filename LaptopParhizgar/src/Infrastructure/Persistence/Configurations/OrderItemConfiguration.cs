using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;
public class OrderItemConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.ToTable("OrderDetail", "dbo");

        builder.Property(b => b.OrderId).IsRequired();
        builder.Property(b => b.ProductId).IsRequired();
        builder.Property(b => b.Price).IsRequired();
        builder.Property(b => b.Count).IsRequired();
    }
}