using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configuration;

public class BouquetConfiguration : IEntityTypeConfiguration<Bouquet>
{
    public void Configure(EntityTypeBuilder<Bouquet> builder)
    {
        builder.ToTable(t => 
            t.HasCheckConstraint("CK_Bouquet_Size", "size IN ('Small', 'Medium', 'Large')"));
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).UseIdentityColumn();
        builder.Property(b => b.Name).IsRequired().HasMaxLength(30);
        builder.Property(b => b.Price).IsRequired().HasColumnType("NUMERIC(10, 2)");
        builder.Property(b => b.MainColor).IsRequired().HasMaxLength(50);
        builder.Property(b => b.Size).IsRequired().HasMaxLength(50);
        builder.Property(b => b.Image1).HasColumnType("BYTEA");
        builder.Property(b => b.Image2).HasColumnType("BYTEA");
        builder.Property(b => b.Image3).HasColumnType("BYTEA");
        builder.Property(b => b.Description).HasMaxLength(30);
        builder.Property(b => b.PopularityScore).HasDefaultValue(0);
        builder.Property(b => b.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        builder.Property(b => b.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasIndex(b => b.MainColor);
        builder.HasIndex(b => b.Size);

        builder.HasMany(b => b.CartItems)
            .WithOne(ci => ci.Bouquet)
            .HasForeignKey(ci => ci.BouquetId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(b => b.OrderBouquets)
            .WithOne(ob => ob.Bouquet)
            .HasForeignKey(ob => ob.BouquetId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}