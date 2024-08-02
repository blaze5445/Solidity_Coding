using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICD.Base.Data.Map
{
    public class TaxMap : IEntityTypeConfiguration<TaxEntity>
    {
        public void Configure(EntityTypeBuilder<TaxEntity> builder)
        {
            builder.ToTable("Tax", "BAS");

            builder.HasKey(c => c.Key);

            builder.Property(c => c.Key).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(c => c.TaxPercent).HasColumnName("TaxPercent").IsRequired(true);
            builder.Property(c => c.Alias).HasColumnName("Alias").IsRequired(false).HasMaxLength(50);
            builder.Property(c => c.IsActive).HasColumnName("IsActive").IsRequired(true);
        }
    }
}
