using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICD.Base.Data.Map
{
    public class TaxLanguageMap : IEntityTypeConfiguration<TaxLanguageEntity>
    {
        public void Configure(EntityTypeBuilder<TaxLanguageEntity> builder)
        {
            builder.ToTable("TaxLanguage", "BAS");

            builder.HasKey(c => c.Key);

            builder.Property(c => c.Key).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(c => c.TaxRef).HasColumnName("TaxRef").IsRequired(true);
            builder.Property(c => c.LanguageRef).HasColumnName("LanguageRef").IsRequired(true);
            builder.Property(c => c._Title).HasColumnName("_Title").IsRequired(true).HasMaxLength(50);
            builder.Property(c => c._Description).HasColumnName("_Description").IsRequired(false).HasMaxLength(500);

            builder.HasOne(tl => tl.Tax).WithMany(t => t.TaxLanguages).HasForeignKey(tl => tl.TaxRef);
        }
    }
}
