using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configuration;

public class BouquetCategoryAssociationConfiguration : IEntityTypeConfiguration<BouquetCategoryBouquet>
{
    public void Configure(EntityTypeBuilder<BouquetCategoryBouquet> builder)
    {
        builder.HasKey(bca => new { bca.BouquetId, bca.CategoryId });

        builder.HasOne(bca => bca.Bouquet)
            .WithMany(b => b.BouquetCategories)
            .HasForeignKey(bca => bca.BouquetId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(bca => bca.Category)
            .WithMany(bc => bc.Bouquets)
            .HasForeignKey(bca => bca.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}