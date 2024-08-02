using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICD.Base.Data.Map
{
    public class ItemGroupMap : IEntityTypeConfiguration<ItemGroupEntity>
    {
        public void Configure(EntityTypeBuilder<ItemGroupEntity> builder)
        {
            builder.ToTable("ItemGroup", "BAS");

            builder.HasKey(ig => ig.Key);

            builder.Property(ig => ig.Key).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(ig => ig.ApplicationRef).IsRequired(true);
            builder.Property(ig => ig.Alias).IsRequired(true).HasMaxLength(100);
            builder.Property(ig => ig.IsActive).IsRequired(true);
        }
    }
}
