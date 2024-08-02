using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICD.Base.Data.Map
{
    public class PersonTitleMap : IEntityTypeConfiguration<PersonTitleEntity>
    {
        public void Configure(EntityTypeBuilder<PersonTitleEntity> builder)
        {
            builder.ToTable("PersonTitle", "BAS");

            builder.HasKey(pt => pt.Key);

            builder.Property(pt => pt.Key).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(pt => pt.IsLegal).IsRequired(true).HasDefaultValue(false);
            builder.Property(pt => pt.IsActive).IsRequired(true);
            builder.Property(pt => pt.Alias).IsRequired(true).HasMaxLength(100);
            builder.Property(pt => pt.ItemRowRef_LegalType).IsRequired(true);

            builder.HasOne(pt => pt.ItemRow).WithMany(ir => ir.PersonTitles).HasForeignKey(pt => pt.ItemRowRef_LegalType);
        }
    }
}
