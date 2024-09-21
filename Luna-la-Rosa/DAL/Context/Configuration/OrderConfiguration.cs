using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id).UseIdentityColumn();
        builder.Property(o => o.Status).IsRequired().HasMaxLength(50);
        builder.Property(o => o.DeliveryPrice).HasColumnType("decimal(10,2)");
        builder.Property(o => o.TotalPrice).HasColumnType("NUMERIC(10, 2)");
        builder.Property(o => o.DeliveryAddress);
        builder.Property(o => o.DeliveryDate);
        builder.Property(o => o.PaymentMethod).IsRequired().HasMaxLength(50);
        builder.Property(o => o.Comment);
        builder.Property(o => o.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        builder.Property(o => o.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasCheckConstraint("CK_Order_PaymentMethod", "payment_method IN ('Card', 'Cash on Delivery')");

        builder.HasIndex(o => o.UserId);
        builder.HasIndex(o => o.Status);
    }
}