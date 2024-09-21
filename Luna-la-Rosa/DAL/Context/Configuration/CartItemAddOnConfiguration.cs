using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configuration;

public class CartItemAddOnConfiguration : IEntityTypeConfiguration<CartItemAddOn>
{
    public void Configure(EntityTypeBuilder<CartItemAddOn> builder)
    {
        builder.HasKey(ciaa => new { ciaa.CartItemId, ciaa.AddOnId });
        builder.Property(ciaa => ciaa.CardNote).HasMaxLength(250);

        builder.HasOne(ciaa => ciaa.CartItem)
            .WithMany(ci => ci.AddOns)
            .HasForeignKey(ciaa => ciaa.CartItemId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ciaa => ciaa.AddOn)
            .WithMany(ao => ao.CartItems)
            .HasForeignKey(ciaa => ciaa.AddOnId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}