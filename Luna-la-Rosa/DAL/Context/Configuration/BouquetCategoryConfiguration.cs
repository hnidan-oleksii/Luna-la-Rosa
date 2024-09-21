using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configuration;

public class BouquetCategoryConfiguration : IEntityTypeConfiguration<BouquetCategory>
{
    public void Configure(EntityTypeBuilder<BouquetCategory> builder)
    {
        builder.HasKey(bc => bc.Id);

        builder.Property(bc => bc.CategoryName)
            .IsRequired()
            .HasMaxLength(255);

        // One-to-Many with BouquetCategoryAssociation
        builder.HasMany(bc => bc.BouquetCategoryAssociations)
            .WithOne(bca => bca.Category)
            .HasForeignKey(bca => bca.CategoryId);
    }
}
