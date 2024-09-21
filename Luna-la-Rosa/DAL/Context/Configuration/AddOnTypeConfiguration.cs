using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configuration;

public class AddOnTypeConfiguration : IEntityTypeConfiguration<AddOnType>
{
    public void Configure(EntityTypeBuilder<AddOnType> builder)
    {
        builder.HasKey(aot => aot.Id);
        builder.Property(aot => aot.Id).UseIdentityColumn();
		builder.Property(aot => aot.Name).IsRequired().HasMaxLength(50);

		builder.HasMany(aot => aot.AddOn)
			.WithOne(ao => ao.Type)
			.HasForeignKey(ao => ao.TypeId)
			.OnDelete(DeleteBehavior.Restrict);
    } 
}
