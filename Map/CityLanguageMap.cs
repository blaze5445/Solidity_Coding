using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICD.Base.Data.Map
{
    public class CityLanguageMap : IEntityTypeConfiguration<CityLanguageEntity>
    {
        public void Configure(EntityTypeBuilder<CityLanguageEntity> builder)
        {
            builder.ToTable("CityLanguage", "BAS");

            builder.HasKey(c => c.Key);

            builder.Property(c => c.Key).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();
            builder.Property(c => c.CityRef).HasColumnName("CityRef").IsRequired(true);
            builder.Property(c => c.LanguageRef).HasColumnName("LanguageRef").IsRequired(true);
            builder.Property(c => c._Title).HasColumnName("_Title").HasMaxLength(50).IsRequired(true);
            builder.Property(c => c._Description).HasColumnName("_Description").HasMaxLength(500).IsRequired(false);

            builder.HasOne(c => c.City).WithMany(cl => cl.CityLanguages).HasForeignKey(c => c.CityRef);
        }
    }
}
