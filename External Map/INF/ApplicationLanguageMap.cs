using ICD.Base.Domain.External_Entity.INF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICD.Base.Data.Map
{
    public class ApplicationLanguageMap : IEntityTypeConfiguration<ApplicationLanguageEntity>
    {
        public void Configure(EntityTypeBuilder<ApplicationLanguageEntity> builder)
        {
            builder.ToTable("ApplicationLanguage", "INF")
                .HasIndex(al => new { al.ApplicationRef, al.LanguageRef }).IsUnique();

            builder.HasKey(al => al.Key);
            builder.Property(x => x.Key).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(x => x._Title).HasColumnName("_Title");

            builder.HasOne(al => al.Application).WithMany(a => a.ApplicationLanguages).HasForeignKey(al => al.ApplicationRef);
        }
    }
}