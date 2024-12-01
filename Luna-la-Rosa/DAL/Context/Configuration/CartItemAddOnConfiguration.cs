using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configuration;

public class CartItemAddOnConfiguration : IEntityTypeConfiguration<CartItemAddOn>
{
    public void Configure(EntityTypeBuilder<CartItemAddOn> builder)
    {
        builder.HasKey(ciao => new { ciao.CartItemId, ciao.AddOnId });
        builder.Property(ciao => ciao.CardNote).HasMaxLength(250);

        builder.HasOne(ciao => ciao.CartItem)
            .WithMany(ci => ci.AddOns)
            .HasForeignKey(ciao => ciao.CartItemId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ciao => ciao.AddOn)
            .WithMany(ao => ao.CartItems)
            .HasForeignKey(ciao => ciao.AddOnId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}