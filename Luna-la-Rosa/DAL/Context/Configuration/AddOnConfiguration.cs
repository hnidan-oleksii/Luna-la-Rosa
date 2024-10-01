using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configuration;

public class AddOnConfiguration : IEntityTypeConfiguration<AddOn>
{
    public void Configure(EntityTypeBuilder<AddOn> builder)
    {
        builder.ToTable(t => 
            t.HasCheckConstraint("CK_AddOn_Type", "type IN ('Balloons', 'Card', 'Sweets', 'Wrapping', 'Ribbon')"));
        builder.HasKey(ao => ao.Id);
        builder.Property(ao => ao.Id).UseIdentityColumn();
        builder.Property(ao => ao.Type).IsRequired().HasMaxLength(50);
        builder.Property(ao => ao.Name).IsRequired().HasMaxLength(255);
        builder.Property(ao => ao.Price).IsRequired().HasColumnType("NUMERIC(10, 2)");
        builder.Property(ao => ao.Image).HasColumnType("BYTEA");
        builder.Property(ao => ao.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasMany(ao => ao.CartItems)
            .WithOne(ca => ca.AddOn)
            .HasForeignKey(ca => ca.AddOnId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(ao => ao.OrderBouquets)
            .WithOne(oa => oa.AddOn)
            .HasForeignKey(oa => oa.AddOnId)
            .OnDelete(DeleteBehavior.Restrict);

		builder.HasMany(ao => ao.BouquetAddOns)
			.WithOne(ba => ba.AddOn)
			.HasForeignKey(ba => ba.AddOnId)
			.OnDelete(DeleteBehavior.Restrict);
    } 
}
