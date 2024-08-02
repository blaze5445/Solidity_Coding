using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICD.Base.Data.Map
{
    public class CurrencyMap : IEntityTypeConfiguration<CurrencyEntity>
    {
        public void Configure(EntityTypeBuilder<CurrencyEntity> builder)
        {
            builder.ToTable("Currency", "BAS");

            builder.HasKey(c => c.Key);

            builder.Property(c => c.Key).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(c => c.IsActive).HasColumnName("IsActive").IsRequired(true);
            builder.Property(c => c.IsNational).HasColumnName("IsNational").IsRequired(true);
            builder.Property(c => c.Icon).HasColumnName("Icon").IsRequired(false).HasMaxLength(500);
        }
    }
}
