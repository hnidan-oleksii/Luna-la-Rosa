using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configuration;

public class OrderAddOnConfiguration : IEntityTypeConfiguration<OrderAddOn>
{
    public void Configure(EntityTypeBuilder<OrderAddOn> builder)
    {
        builder.HasKey(oa => new { oa.OrderBouquetId, oa.AddOnId });

        // Relationships
        builder.HasOne(oa => oa.OrderBouquet)
            .WithMany(ob => ob.OrderAddOns)
            .HasForeignKey(oa => oa.OrderBouquetId);

        builder.HasOne(oa => oa.AddOn)
            .WithMany(a => a.OrderAddOns)
            .HasForeignKey(oa => oa.AddOnId);
    }
}
