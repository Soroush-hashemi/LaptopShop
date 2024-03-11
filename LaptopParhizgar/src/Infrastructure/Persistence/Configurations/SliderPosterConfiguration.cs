using Domain.Sliders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;
public class SliderPosterConfiguration : IEntityTypeConfiguration<SliderPosters>
{
    public void Configure(EntityTypeBuilder<SliderPosters> builder)
    {
        builder.Property(b => b.ImageName)
            .HasMaxLength(120).IsRequired();

        builder.Property(b => b.Link)
            .HasMaxLength(500).IsRequired();
    }
}