using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(u => u.PasswordHash)
            .IsRequired();

        builder.Property(u => u.Role)
            .HasDefaultValue("User")
            .HasMaxLength(50);

        builder.Property(u => u.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(u => u.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        // One-to-One with ShoppingCart
        builder.HasOne(u => u.ShoppingCart)
            .WithOne(s => s.User)
            .HasForeignKey<ShoppingCart>(s => s.UserId);

        // One-to-Many with Orders
        builder.HasMany(u => u.Orders)
            .WithOne(o => o.User)
            .OnDelete(DeleteBehavior.SetNull);

        // One-to-Many with CustomBouquets
        builder.HasMany(u => u.CustomBouquets)
            .WithOne(cb => cb.User)
            .OnDelete(DeleteBehavior.SetNull);
    }
}