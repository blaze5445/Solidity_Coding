using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ICD.Base.Data.Map
{
    public class LocationMap : IEntityTypeConfiguration<LocationEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<LocationEntity> builder)
        {
            builder.ToTable("Location", "BAS");

            builder.HasKey(l => l.Key);

            builder.Property(l => l.Key).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(l => l.LocationTypeRef).IsRequired(true);
            builder.Property(l => l.ParentRef).IsRequired(false);
            builder.Property(l => l.LevelNo).IsRequired(true);
            builder.Property(l => l.IsActive).IsRequired(true).HasDefaultValue(true);

            builder.HasOne(l => l.LocationType).WithMany(lt => lt.Locations).HasForeignKey(l => l.LocationTypeRef);
            builder.HasOne(l => l.Location).WithMany(l => l.Locations).HasForeignKey(l => l.ParentRef);
        }
    }
}
