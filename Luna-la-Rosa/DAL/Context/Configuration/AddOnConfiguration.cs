using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configuration;

public class AddOnConfiguration : IEntityTypeConfiguration<AddOn>
{
    public void Configure(EntityTypeBuilder<AddOn> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Type)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(a => a.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(a => a.Price)
            .HasColumnType("decimal(10,2)")
            .IsRequired();
    }
}
