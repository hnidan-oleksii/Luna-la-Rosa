using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configuration;

public class CustomBouquetConfiguration : IEntityTypeConfiguration<CustomBouquet>
{
    public void Configure(EntityTypeBuilder<CustomBouquet> builder)
    {
        builder.HasKey(cb => cb.Id);
        builder.Property(cb => cb.Id).UseIdentityColumn();
        builder.Property(cb => cb.TotalPrice).HasColumnType("NUMERIC(10, 2)");
        builder.Property(cb => cb.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(cb => cb.User)
            .WithMany(u => u.CustomBouquets)
            .HasForeignKey(cb => cb.UserId)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.HasMany(cb => cb.CartItems)
            .WithOne(ci => ci.CustomBouquet)
            .HasForeignKey(ci => ci.CustomBouquetId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(cb => cb.OrderBouquets)
            .WithOne(ob => ob.CustomBouquet)
            .HasForeignKey(ob => ob.CustomBouquetId)
            .OnDelete(DeleteBehavior.Restrict); 
    }
}