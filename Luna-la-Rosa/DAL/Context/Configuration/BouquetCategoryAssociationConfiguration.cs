using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configuration;

public class BouquetCategoryAssociationConfiguration : IEntityTypeConfiguration<BouquetCategoryAssociation>
{
    public void Configure(EntityTypeBuilder<BouquetCategoryAssociation> builder)
    {
        builder.HasKey(bca => new { bca.BouquetId, bca.CategoryId });

        // Relationships
        builder.HasOne(bca => bca.Bouquet)
            .WithMany(b => b.BouquetCategoryAssociations)
            .HasForeignKey(bca => bca.BouquetId);

        builder.HasOne(bca => bca.Category)
            .WithMany(c => c.BouquetCategoryAssociations)
            .HasForeignKey(bca => bca.CategoryId);
    }
}
