using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configuration;

public class BouquetAddOnConfiguration : IEntityTypeConfiguration<BouquetAddOn>
{
    public void Configure(EntityTypeBuilder<BouquetAddOn> builder)
    {
        builder.HasKey(ba => new { ba.BouquetId, ba.AddOnId });

        builder.HasOne(ba => ba.Bouquet)
               .WithMany(b => b.BouquetAddOns)
               .HasForeignKey(ba => ba.BouquetId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ba => ba.AddOn)
               .WithMany(ao => ao.BouquetAddOns)
               .HasForeignKey(ba => ba.AddOnId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
