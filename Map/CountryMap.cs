using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICD.Base.Data.Map
{
    public class CountryMap : IEntityTypeConfiguration<CountryEntity>
    {
        public void Configure(EntityTypeBuilder<CountryEntity> builder)
        {
            builder.ToTable("Country", "BAS");

            builder.HasKey(c => c.Key);

            builder.Property(c => c.Key).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(c => c.IsActive).HasColumnName("IsActive").IsRequired(true);
        }
    }
}
