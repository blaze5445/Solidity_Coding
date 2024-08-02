using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICD.Base.Data.Map
{
    public class LocationLanguageMap : IEntityTypeConfiguration<LocationLanguageEntity>
    {
        public void Configure(EntityTypeBuilder<LocationLanguageEntity> builder)
        {
            builder.ToTable("LocationLanguage", "BAS");

            builder.HasKey(ll => ll.Key);

            builder.Property(ll => ll.Key).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(ll => ll.LocationRef).IsRequired(true);
            builder.Property(ll => ll.LanguageRef).IsRequired(true);
            builder.Property(ll => ll._Name).HasMaxLength(100).IsRequired(true);

            builder.HasOne(ll => ll.Location).WithMany(l => l.LocationLanguages).HasForeignKey(ll => ll.LocationRef);
        }
    }
}
