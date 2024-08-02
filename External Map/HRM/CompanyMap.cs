using ICD.Base.Domain.External_Entity.HRM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICD.Base.Data.Map
{
    public class CompanyMap : IEntityTypeConfiguration<CompanyEntity>
    {
        public void Configure(EntityTypeBuilder<CompanyEntity> builder)
        {
            builder.ToTable("Company", "HRM");

            builder.HasKey(c => c.Key);

            builder.Property(c => c.Key).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(c => c.PersonRef).IsRequired(true);
            builder.Property(c => c.Code).IsRequired(true);
            builder.Property(c => c.TotalCode).IsRequired(true);
            builder.Property(c => c.ParentRef).IsRequired(false);
            builder.Property(c => c.IsActive).IsRequired(true);
            builder.Property(c => c.Prefix).HasColumnName("Prefix").HasMaxLength(200).IsRequired(false);
            builder.Property(c => c.Abbreviation).HasColumnName("Abbreviation").HasMaxLength(10).IsRequired(false);

            builder.HasOne(c => c.Company).WithMany(c => c.Companies).HasForeignKey(c => c.ParentRef);
        }
    }
}
