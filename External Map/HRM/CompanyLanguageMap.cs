using ICD.Base.Domain.External_Entity.HRM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICD.Base.Data.Map
{
    public class CompanyLanguageMap : IEntityTypeConfiguration<CompanyLanguageEntity>
    {
        public void Configure(EntityTypeBuilder<CompanyLanguageEntity> builder)
        {
            builder.ToTable("CompanyLanguage", "HRM");

            builder.HasKey(x => x.Key);

            builder.Property(x => x.Key).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.HasOne(x => x.Company).WithMany(c => c.CompanyLanguages).HasForeignKey(x => x.CompanyRef);
        }
    }
}
