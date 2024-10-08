using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configuration;

public class OrderAddOnConfiguration : IEntityTypeConfiguration<OrderAddOn>
{
    public void Configure(EntityTypeBuilder<OrderAddOn> builder)
    {
        builder.HasKey(oao => new { oao.OrderBouquetId, oao.AddOnId });
        builder.Property(oao => oao.CardNote).HasMaxLength(250);

        builder.HasOne(oao => oao.OrderBouquet)
            .WithMany(ob => ob.AddOns)
            .HasForeignKey(oao => oao.OrderBouquetId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(oao => oao.AddOn)
            .WithMany(ao => ao.OrderBouquets)
            .HasForeignKey(oao => oao.AddOnId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}