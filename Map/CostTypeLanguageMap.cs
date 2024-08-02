using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICD.Base.Data.Map
{
    public class CostTypeLanguageMap : IEntityTypeConfiguration<CostTypeLanguageEntity>
    {
        public void Configure(EntityTypeBuilder<CostTypeLanguageEntity> builder)
        {
            builder.ToTable("CostTypeLanguage", "BAS");

            builder.HasKey(c => c.Key);

            builder.Property(c => c.Key).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(c => c.CostTypeRef).HasColumnName("CostTypeRef").IsRequired(true);
            builder.Property(c => c.LanguageRef).HasColumnName("LanguageRef").IsRequired(true);
            builder.Property(c => c._Title).HasColumnName("_Title").IsRequired(true).HasMaxLength(100);
            builder.Property(c => c._Description).HasColumnName("_Description").IsRequired(false).HasMaxLength(500);

            builder.HasOne(x => x.CostType).WithMany(z => z.CostTypeLanguages).HasForeignKey(x => x.CostTypeRef);
        }
    }
}
