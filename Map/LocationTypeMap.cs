using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICD.Base.Data.Map
{
    public class LocationTypeMap : IEntityTypeConfiguration<LocationTypeEntity>
    {
        public void Configure(EntityTypeBuilder<LocationTypeEntity> builder)
        {
            builder.ToTable("LocationType", "BAS");

            builder.HasKey(lt => lt.Key);

            builder.Property(lt => lt.Key).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(lt => lt.Alias).HasMaxLength(100).IsRequired(true);
        }
    }
}
