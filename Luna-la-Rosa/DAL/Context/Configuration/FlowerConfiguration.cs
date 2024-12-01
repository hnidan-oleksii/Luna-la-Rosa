using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configuration;

public class FlowerConfiguration : IEntityTypeConfiguration<Flower>
{
    public void Configure(EntityTypeBuilder<Flower> builder)
    {
        builder.HasKey(f => f.Id);
        builder.Property(f => f.Name).IsRequired().HasMaxLength(255);
        builder.Property(f => f.Color).IsRequired().HasMaxLength(50);
        builder.Property(f => f.Price).IsRequired().HasColumnType("NUMERIC(10, 2)");
        builder.Property(f => f.AvailableQuantity).HasDefaultValue(0);
        builder.Property(f => f.Image).HasColumnType("BYTEA");
        builder.Property(f => f.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        builder.Property(f => f.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasIndex(f => f.Color);

        builder.HasMany(f => f.BouquetFlowers)
            .WithOne(bf => bf.Flower)
            .HasForeignKey(bf => bf.FlowerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(f => f.CustomBouquetFlowers)
            .WithOne(cbf => cbf.Flower)
            .HasForeignKey(cbf => cbf.FlowerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}