using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configuration;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.HasKey(ci => ci.Id);
        builder.Property(ci => ci.Id).UseIdentityColumn();
        builder.Property(ci => ci.Quantity).IsRequired();

        builder.HasOne(ci => ci.ShoppingCart)
            .WithMany(sc => sc.CartItems)
            .HasForeignKey(ci => ci.CartId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ci => ci.Bouquet)
            .WithMany(b => b.CartItems)
            .HasForeignKey(ci => ci.BouquetId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ci => ci.CustomBouquet)
            .WithMany(cb => cb.CartItems)
            .HasForeignKey(ci => ci.CustomBouquetId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}