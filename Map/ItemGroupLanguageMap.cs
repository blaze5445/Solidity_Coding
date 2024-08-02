using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICD.Base.Data.Map
{
    public class ItemGroupLanguageMap : IEntityTypeConfiguration<ItemGroupLanguageEntity>
    {
        public void Configure(EntityTypeBuilder<ItemGroupLanguageEntity> builder)
        {
            builder.ToTable("ItemGroupLanguage", "BAS");

            builder.HasKey(igl => igl.Key);

            builder.Property(igl => igl.Key).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(igl => igl.LanguageRef).IsRequired(true);
            builder.Property(igl => igl._Title).HasMaxLength(100).IsRequired(true);

            builder.HasOne(igl => igl.ItemGroup).WithMany(ig => ig.ItemGroupLanguages).HasForeignKey(igl => igl.ItemGroupRef);
        }
    }
}
