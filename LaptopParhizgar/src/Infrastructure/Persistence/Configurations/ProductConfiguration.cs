using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products", "dbo");
        builder.HasIndex(b => b.Slug).IsUnique();
        builder.Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(b => b.Description)
            .IsRequired();
        builder.Property(b => b.CreationDate).IsRequired();
        builder.Property(b => b.Price).IsRequired();
        builder.Property(b => b.Slug)
            .IsRequired().IsUnicode(false);
        builder.Property(b => b.ImageName).IsRequired();
        builder.Property(b => b.ImageNameSecond).IsRequired();

        builder.OwnsOne(b => b.SeoData, config =>
        {
            config.Property(b => b.MetaDescription)
                .HasMaxLength(500)
                .HasColumnName("MetaDescription");

            config.Property(b => b.MetaTitle)
                .HasMaxLength(500)
                .HasColumnName("MetaTitle");

            config.Property(b => b.MetaKeyWords)
                .HasMaxLength(500)
                .HasColumnName("MetaKeyWords");

            config.Property(b => b.IndexPage)
                .HasColumnName("IndexPage");

            config.Property(b => b.Canonical)
                .HasMaxLength(500)
                .HasColumnName("Canonical");

            config.Property(b => b.Schema)
                .HasColumnName("Schema");
        });

    }
}