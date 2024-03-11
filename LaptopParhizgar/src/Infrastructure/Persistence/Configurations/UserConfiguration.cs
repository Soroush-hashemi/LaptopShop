using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;
internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users", "dbo");
        builder.HasIndex(b => b.Email).IsUnique();
        builder.Property(b => b.Email)
            .IsRequired(false)
            .HasMaxLength(256);
        builder.Property(b => b.CreationDate).IsRequired();

        builder.OwnsOne(c => c.PhoneNumber, config =>
        {
            config.Property(b => b.Value)
                .HasColumnName("PhoneNumber")
                .IsRequired().HasMaxLength(11);
        });

        builder.Property(b => b.UserName)
            .IsRequired(false)
           .HasMaxLength(80);
        builder.Property(b => b.FullName)
            .IsRequired(false)
            .HasMaxLength(80);
        builder.Property(b => b.Password)
            .IsRequired()
            .HasMaxLength(80);
    }
}