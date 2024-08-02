using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICD.Base.Data.Map
{
    public class CostTypeMap : IEntityTypeConfiguration<CostTypeEntity>
    {
        public void Configure(EntityTypeBuilder<CostTypeEntity> builder)
        {
            builder.ToTable("CostType", "BAS");

            builder.HasKey(c => c.Key);

            builder.Property(c => c.Key).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();
            builder.Property(c => c.IsActive).HasColumnName("IsActive").IsRequired(true);
            builder.Property(c => c.CompanyRef).HasColumnName("CompanyRef").IsRequired(true);
            builder.Property(c => c.ItemRowRef_CostOrigin).HasColumnName("ItemRowRef_CostOrigin").IsRequired(true);
            builder.Property(c => c.ItemRowRef_SharingType).HasColumnName("ItemRowRef_SharingType").IsRequired(true);
            builder.Property(c => c.CostSign).HasColumnName("CostSign").IsRequired(true);
        }
    }
}
