using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICD.Base.Data.Map
{
    public class CurrencyLanguageMap : IEntityTypeConfiguration<CurrencyLanguageEntity>
    {
        public void Configure(EntityTypeBuilder<CurrencyLanguageEntity> builder)
        {
            builder.ToTable("CurrencyLanguage", "BAS");

            builder.HasKey(cl => cl.Key);

            builder.Property(cl => cl.Key).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(cl => cl.CurrencyRef).HasColumnName("CurrencyRef").IsRequired(true);
            builder.Property(cl => cl.LanguageRef).HasColumnName("LanguageRef").IsRequired(true);
            builder.Property(cl => cl._Title).HasColumnName("_Title").IsRequired(true).HasMaxLength(50);

            builder.HasOne(cl => cl.Currency).WithMany(cl => cl.CurrencyLanguages).HasForeignKey(cl => cl.CurrencyRef);
        }
    }
}
