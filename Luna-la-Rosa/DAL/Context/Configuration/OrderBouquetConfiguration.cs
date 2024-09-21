using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configuration;

public class OrderBouquetConfiguration : IEntityTypeConfiguration<OrderBouquet>
{
    public void Configure(EntityTypeBuilder<OrderBouquet> builder)
    {
        builder.HasKey(ob => ob.Id);

        builder.Property(ob => ob.Price)
            .HasColumnType("decimal(10,2)")
            .IsRequired();

        builder.Property(ob => ob.Quantity).IsRequired();

        // Relationships
        builder.HasOne(ob => ob.Order)
            .WithMany(o => o.OrderBouquets)
            .HasForeignKey(ob => ob.OrderId);

        builder.HasOne(ob => ob.Bouquet)
            .WithMany()
            .HasForeignKey(ob => ob.BouquetId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(ob => ob.CustomBouquet)
            .WithMany()
            .HasForeignKey(ob => ob.CustomBouquetId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
