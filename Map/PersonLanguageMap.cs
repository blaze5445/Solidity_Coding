using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICD.Base.Data.Map
{
    public class PersonLanguageMap : IEntityTypeConfiguration<PersonLanguageEntity>
    {
        public void Configure(EntityTypeBuilder<PersonLanguageEntity> builder)
        {
            builder.ToTable("PersonLanguage", "BAS");

            builder.HasKey(pl => pl.Key);

            builder.Property(pl => pl.Key).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(pl => pl._Name).IsRequired(true).HasMaxLength(200);
            builder.Property(pl => pl._LastName).HasMaxLength(200).IsRequired(false);
            builder.Property(pl => pl._FatherName).IsRequired(false).HasMaxLength(100);
            builder.Property(pl => pl.FullName).IsRequired(false).HasMaxLength(401).HasComputedColumnSql("[_Name] + ', ' + [_LastName]");

            builder.HasOne(pl => pl.Person).WithMany(p => p.PersonLanguages).HasForeignKey(pl => pl.PersonRef);
        }
    }
}
