using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICD.Base.Data.Map
{
    public class ItemRowLanguageMap : IEntityTypeConfiguration<ItemRowLanguageEntity>
    {
        public void Configure(EntityTypeBuilder<ItemRowLanguageEntity> builder)
        {
            builder.ToTable("ItemRowLanguage", "BAS");

            builder.HasKey(irl => irl.Key);

            builder.Property(irl => irl.Key).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(irl => irl._Title).HasMaxLength(100).IsRequired(true);
            builder.Property(irl => irl.LanguageRef).IsRequired(true);

            builder.HasOne(irl => irl.ItemRow).WithMany(ir => ir.ItemRowLanguages).HasForeignKey(irl => irl.ItemRowRef);
        }
    }
}
