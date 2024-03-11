using Domain.Carts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;
public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.ToTable("CartItem", "dbo");

        builder.Property(b => b.CartId).IsRequired();
        builder.Property(b => b.ProductId).IsRequired();
        builder.Property(b => b.Count).IsRequired();
        builder.Property(b => b.Price).IsRequired();
    }
}