using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;
public class ProductCommentConfiguration : IEntityTypeConfiguration<ProductComment>
{
    public void Configure(EntityTypeBuilder<ProductComment> builder)
    {
        builder.ToTable("ProductComment", "dbo");

        builder.Property(b => b.Text).IsRequired();
        builder.Property(b => b.ProductId).IsRequired();
        builder.Property(b => b.UserId).IsRequired();
    }
}