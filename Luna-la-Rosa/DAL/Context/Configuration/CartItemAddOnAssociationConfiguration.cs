using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configuration;

public class CartItemAddOnAssociationConfiguration : IEntityTypeConfiguration<CartItemAddOnAssociation>
{
    public void Configure(EntityTypeBuilder<CartItemAddOnAssociation> builder)
    {
        builder.ToTable("Cart_Items_Add_Ons_Associations");
        builder.HasKey(ciaa => new { ciaa.CartItemId, ciaa.AddOnId });

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