using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configuration;

public class CustomBouquetFlowerConfiguration : IEntityTypeConfiguration<CustomBouquetFlower>
{
    public void Configure(EntityTypeBuilder<CustomBouquetFlower> builder)
    {
        builder.HasKey(cbf => new { cbf.CustomBouquetId, cbf.FlowerId });

        builder.Property(cbf => cbf.Quantity).IsRequired();

        // Relationships
        builder.HasOne(cbf => cbf.CustomBouquet)
            .WithMany(cb => cb.CustomBouquetFlowers)
            .HasForeignKey(cbf => cbf.CustomBouquetId);

        builder.HasOne(cbf => cbf.Flower)
            .WithMany(f => f.CustomBouquetFlowers)
            .HasForeignKey(cbf => cbf.FlowerId);
    }
}
