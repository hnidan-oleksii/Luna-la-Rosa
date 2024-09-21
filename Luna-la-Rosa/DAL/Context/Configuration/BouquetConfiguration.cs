using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configuration;

public class BouquetConfiguration : IEntityTypeConfiguration<Bouquet>
{
    public void Configure(EntityTypeBuilder<Bouquet> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Price)
            .HasColumnType("decimal(10,2)")
            .IsRequired();

        builder.Property(b => b.MainColor)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(b => b.Size)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(b => b.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(b => b.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        // Index on MainColor
        builder.HasIndex(b => b.MainColor);

        // One-to-Many with BouquetFlower
        builder.HasMany(b => b.BouquetFlowers)
            .WithOne(bf => bf.Bouquet)
            .HasForeignKey(bf => bf.BouquetId);

        // One-to-Many with BouquetCategoryAssociation
        builder.HasMany(b => b.BouquetCategoryAssociations)
            .WithOne(bca => bca.Bouquet)
            .HasForeignKey(bca => bca.BouquetId);
    }
}
