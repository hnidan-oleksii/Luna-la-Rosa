using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configuration;

public class BouquetCategoryConfiguration : IEntityTypeConfiguration<BouquetCategory>
{
    public void Configure(EntityTypeBuilder<BouquetCategory> builder)
    {
        builder.ToTable("Bouquet_Categories");
        builder.HasKey(bc => bc.Id);
        builder.Property(bc => bc.Id).UseIdentityColumn();
        builder.Property(bc => bc.CategoryName).IsRequired().HasMaxLength(255);
    }
}