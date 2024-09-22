using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configuration;

public class BouquetCategoryAssociationConfiguration : IEntityTypeConfiguration<BouquetCategoryAssociation>
{
    public void Configure(EntityTypeBuilder<BouquetCategoryAssociation> builder)
    {
        builder.ToTable("Bouquet_Category_Associations");
        builder.HasKey(bca => new { bca.BouquetId, bca.CategoryId });

        builder.HasOne(bca => bca.Bouquet)
            .WithMany(b => b.BouquetCategories)
            .HasForeignKey(bca => bca.BouquetId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(bca => bca.Category)
            .WithMany(bc => bc.BouquetAssociations)
            .HasForeignKey(bca => bca.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}