using Domain.Addresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;
public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Address", "dbo");

        builder.Property(b => b.UserId).IsRequired();
        builder.Property(b => b.NameOfRecipient).IsRequired();
        builder.Property(b => b.Province).IsRequired();
        builder.Property(b => b.City).IsRequired();
        builder.Property(b => b.PostalCode).IsRequired();
        builder.Property(b => b.AddressDetail).IsRequired();

        builder.OwnsOne(c => c.PhoneNumberForAddress, config =>
        {
            config.Property(b => b.Value)
                .HasColumnName("PhoneNumber")
                .IsRequired().HasMaxLength(11);
        });

    }
}