using ICD.Base.Domain.External_Entity.INF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICD.Base.Data.Map
{
    public class ApplicationMap : IEntityTypeConfiguration<ApplicationEntity>
    {
        public void Configure(EntityTypeBuilder<ApplicationEntity> builder)
        {
            builder.ToTable("Application", "INF")
                .HasIndex(a => a.Url).IsUnique();

            builder.HasKey(a => a.Key);
            builder.Property(x => x.Key).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.HasIndex(a => a.Alias).IsUnique();

            builder.HasIndex(a => a.Abbreviation).IsUnique();
        }
    }
}