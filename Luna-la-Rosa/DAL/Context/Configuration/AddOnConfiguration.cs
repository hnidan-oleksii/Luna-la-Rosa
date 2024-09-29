using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configuration;

public class AddOnConfiguration : IEntityTypeConfiguration<AddOn>
{
    public void Configure(EntityTypeBuilder<AddOn> builder)
    {
        builder.ToTable("Add_Ons");
        builder.HasKey(ao => ao.Id);
        builder.Property(ao => ao.Id).UseIdentityColumn();
        builder.Property(ao => ao.Type).IsRequired().HasMaxLength(50);
        builder.Property(ao => ao.Name).IsRequired().HasMaxLength(255);
        builder.Property(ao => ao.Price).IsRequired().HasColumnType("NUMERIC(10, 2)");
        builder.Property(ao => ao.Image).HasColumnType("BYTEA");
        builder.Property(ao => ao.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasCheckConstraint("CK_AddOn_Type", "type IN ('Balloons', 'Card', 'Sweets', 'Wrapping', 'Ribbon')");
    }
}