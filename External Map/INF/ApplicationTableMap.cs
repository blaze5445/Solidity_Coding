using ICD.Base.Domain.External_Entity.INF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICD.Base.Data.External_Map.INF
{
    public class ApplicationTableMap : IEntityTypeConfiguration<ApplicationTableEntity>
    {
        public void Configure(EntityTypeBuilder<ApplicationTableEntity> builder)
        {
            builder.ToTable("ApplicationTable", "INF");

            builder.HasKey(at => at.Key);

            builder.Property(at => at.Key).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();
            builder.Property(at => at.Name).HasColumnName("Name");
            builder.Property(at => at.Schema).HasColumnName("Schema");
            builder.Property(at => at.IsBase).HasColumnName("IsBase").IsRequired();

            builder.HasOne(at => at.Application).WithMany(a => a.ApplicationTables).HasForeignKey(at => at.ApplicationRef);
        }
    }
}
