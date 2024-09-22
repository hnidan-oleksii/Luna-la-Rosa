using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configuration;

public class RibbonWrappingConfiguration : IEntityTypeConfiguration<RibbonWrapping>
{
    public void Configure(EntityTypeBuilder<RibbonWrapping> builder)
    {
        builder.ToTable("Ribbons_Wrappings");
        builder.HasKey(rw => rw.Id);
        builder.Property(rw => rw.Id).UseIdentityColumn();
        builder.Property(rw => rw.Name).IsRequired().HasMaxLength(255);
        builder.Property(rw => rw.Photo).HasColumnType("BYTEA");
        builder.Property(rw => rw.Price).IsRequired().HasColumnType("NUMERIC(10, 2)");
        builder.Property(rw => rw.Type).IsRequired().HasMaxLength(10);
        builder.Property(rw => rw.AvailableQuantity).HasDefaultValue(0);
        builder.Property(rw => rw.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
    }
}