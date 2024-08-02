using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICD.Base.Data.Map
{
    public class CountryLanguageMap : IEntityTypeConfiguration<CountryLanguageEntity>
    {
        public void Configure(EntityTypeBuilder<CountryLanguageEntity> builder)
        {
            builder.ToTable("CountryLanguage", "BAS");

            builder.HasKey(cl => cl.Key);

            builder.Property(cl => cl.Key).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(cl => cl.CountryRef).HasColumnName("CountryRef").IsRequired(true);
            builder.Property(cl => cl.LanguageRef).HasColumnName("LanguageRef").IsRequired(true);
            builder.Property(cl => cl._Title).HasColumnName("_Title").IsRequired(true).HasMaxLength(50);

            builder.HasOne(cl => cl.Country).WithMany(cl => cl.CountryLanguages).HasForeignKey(cl => cl.CountryRef);
        }
    }
}
