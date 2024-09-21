using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configuration;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.HasKey(ci => ci.Id);

        builder.Property(ci => ci.Quantity).IsRequired();

        // Relationships
        builder.HasOne(ci => ci.Cart)
            .WithMany(sc => sc.CartItems)
            .HasForeignKey(ci => ci.CartId);

        builder.HasOne(ci => ci.Bouquet)
            .WithMany()
            .HasForeignKey(ci => ci.BouquetId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ci => ci.CustomBouquet)
            .WithMany()
            .HasForeignKey(ci => ci.CustomBouquetId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
