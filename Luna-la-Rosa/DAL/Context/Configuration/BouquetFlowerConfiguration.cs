using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configuration;

public class BouquetFlowerConfiguration : IEntityTypeConfiguration<BouquetFlower>
{
    public void Configure(EntityTypeBuilder<BouquetFlower> builder)
    {
        builder.HasKey(bf => new { bf.BouquetId, bf.FlowerId });
        builder.Property(bf => bf.Quantity).IsRequired();

        builder.HasOne(bf => bf.Bouquet)
            .WithMany(b => b.BouquetFlowers)
            .HasForeignKey(bf => bf.BouquetId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(bf => bf.Flower)
            .WithMany(f => f.BouquetFlowers)
            .HasForeignKey(bf => bf.FlowerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}