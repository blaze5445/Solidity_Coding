using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICD.Base.Data.Map
{
    public class ItemRowMap : IEntityTypeConfiguration<ItemRowEntity>
    {
        public void Configure(EntityTypeBuilder<ItemRowEntity> builder)
        {
            builder.ToTable("ItemRow", "BAS");

            builder.HasKey(ir => ir.Key);

            builder.Property(ir => ir.Key).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(ir => ir.Alias).HasMaxLength(100).IsRequired(true);
            builder.Property(ir => ir.IsActive).IsRequired(true);

            builder.HasOne(ir => ir.ItemGroup).WithMany(ig => ig.ItemRows).HasForeignKey(ir => ir.ItemGroupRef);
        }
    }
}
