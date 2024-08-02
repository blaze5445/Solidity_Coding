using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICD.Base.Data.Map
{
    public class PersonTitleLanguageMap : IEntityTypeConfiguration<PersonTitleLanguageEntity>
    {
        public void Configure(EntityTypeBuilder<PersonTitleLanguageEntity> builder)
        {
            builder.ToTable("PersonTitleLanguage", "BAS");

            builder.HasKey(ptl => ptl.Key);

            builder.Property(ptl => ptl.Key).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(ptl => ptl._Name).IsRequired(true).HasMaxLength(100);
            builder.Property(ptl => ptl._Description).IsRequired(false).HasMaxLength(1000);

            builder.HasOne(ptl => ptl.PersonTitle).WithMany(pt => pt.PersonTitleLanguages).HasForeignKey(p => p.PersonTitleRef);
        }
    }
}
