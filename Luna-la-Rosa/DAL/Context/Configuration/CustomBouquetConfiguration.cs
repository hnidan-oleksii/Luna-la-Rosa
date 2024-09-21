using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configuration;

public class CustomBouquetConfiguration : IEntityTypeConfiguration<CustomBouquet>
{
    public void Configure(EntityTypeBuilder<CustomBouquet> builder)
    {
        builder.HasKey(cb => cb.Id);

        builder.Property(cb => cb.TotalPrice)
            .HasColumnType("decimal(10,2)");

        builder.Property(cb => cb.Ribbon)
            .HasMaxLength(255);

        builder.Property(cb => cb.Wrapping)
            .HasMaxLength(255);

        builder.Property(cb => cb.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        // One-to-Many with CustomBouquetFlower
        builder.HasMany(cb => cb.CustomBouquetFlowers)
            .WithOne(cbf => cbf.CustomBouquet)
            .HasForeignKey(cbf => cbf.CustomBouquetId);
    }
}
