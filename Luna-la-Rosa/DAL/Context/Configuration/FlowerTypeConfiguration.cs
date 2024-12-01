using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configuration;

public class FlowerTypeConfiguration : IEntityTypeConfiguration<FlowerType>
{
    public void Configure(EntityTypeBuilder<FlowerType> builder)
    {
        builder.HasKey(ft => ft.Id);
        builder.Property(ft => ft.Name).IsRequired().HasMaxLength(50);

        builder.HasMany(ft => ft.Flower)
            .WithOne(f => f.Type)
            .HasForeignKey(f => f.TypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}