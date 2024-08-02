using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICD.Base.Data.Map
{
    public class LocationTypeLanguageMap : IEntityTypeConfiguration<LocationTypeLanguageEntity>
    {
        public void Configure(EntityTypeBuilder<LocationTypeLanguageEntity> builder)
        {
            builder.ToTable("LocationTypeLanguage", "BAS");

            builder.HasKey(ltl => ltl.Key);

            builder.Property(ltl => ltl.Key).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(ltl => ltl.LocationTypeRef).IsRequired(true);
            builder.Property(ltl => ltl.LanguageRef).IsRequired(true);
            builder.Property(ltl => ltl._Title).HasMaxLength(100).IsRequired(true);

            builder.HasOne(ltl => ltl.LocationType).WithMany(lt => lt.LocationTypeLanguages).HasForeignKey(ltl => ltl.LocationTypeRef);
        }
    }
}
