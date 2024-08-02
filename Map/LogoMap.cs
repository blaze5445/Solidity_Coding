using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICD.Base.Data.Map
{
    public class LogoMap : IEntityTypeConfiguration<LogoEntity>
    {
        public void Configure(EntityTypeBuilder<LogoEntity> builder)
        {
            builder.ToTable("Logo", "BAS");

            builder.HasKey(x => x.Key);

            builder.Property(x => x.Key).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(x => x.Alias).HasColumnName("Alias").IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.LogoData).HasColumnName("LogoData").IsRequired(true);
        }
    }
}
