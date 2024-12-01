using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configuration;

public class OrderBouquetConfiguration : IEntityTypeConfiguration<OrderBouquet>
{
    public void Configure(EntityTypeBuilder<OrderBouquet> builder)
    {
        builder.HasKey(ob => ob.Id);
        builder.Property(ob => ob.Quantity).IsRequired();
        builder.Property(ob => ob.Price).HasColumnType("NUMERIC(10, 2)");

        builder.HasOne(ob => ob.Order)
            .WithMany(o => o.OrderBouquets)
            .HasForeignKey(ob => ob.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ob => ob.Bouquet)
            .WithMany(b => b.OrderBouquets)
            .HasForeignKey(ob => ob.BouquetId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ob => ob.CustomBouquet)
            .WithMany(cb => cb.OrderBouquets)
            .HasForeignKey(ob => ob.CustomBouquetId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}