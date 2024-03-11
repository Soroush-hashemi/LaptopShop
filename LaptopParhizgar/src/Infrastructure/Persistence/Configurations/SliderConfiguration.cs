using Domain.Sliders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;
internal class SliderConfiguration : IEntityTypeConfiguration<Slider>
{
    public void Configure(EntityTypeBuilder<Slider> builder)
    {
        builder.Property(b => b.ImageName)
            .HasMaxLength(3000).IsRequired();
        builder.Property(b => b.Link)
            .HasMaxLength(500);
    }
}