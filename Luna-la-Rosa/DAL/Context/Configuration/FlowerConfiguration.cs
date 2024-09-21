using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configuration;

public class FlowerConfiguration : IEntityTypeConfiguration<Flower>
{
    public void Configure(EntityTypeBuilder<Flower> builder)
    {
        builder.HasKey(f => f.Id);

        builder.Property(f => f.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(f => f.Type)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(f => f.Color)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(f => f.Price)
            .HasColumnType("decimal(10,2)")
            .IsRequired();

        builder.Property(f => f.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(f => f.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        // Index on Color
        builder.HasIndex(f => f.Color);

        // Many-to-Many with Bouquets
        builder.HasMany(f => f.BouquetFlowers)
            .WithOne(bf => bf.Flower)
            .HasForeignKey(bf => bf.FlowerId);

        // Many-to-Many with CustomBouquets
        builder.HasMany(f => f.CustomBouquetFlowers)
            .WithOne(cbf => cbf.Flower)
            .HasForeignKey(cbf => cbf.FlowerId);
    }
}
