using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICD.Base.Data.Map
{
    public class CostTypeTaxMap : IEntityTypeConfiguration<CostTypeTaxEntity>
    {
        public void Configure(EntityTypeBuilder<CostTypeTaxEntity> builder)
        {
            builder.ToTable("CostTypeTax", "BAS");

            builder.HasKey(c => c.Key);

            builder.Property(c => c.Key).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(c => c.CostTypeRef).HasColumnName("CostTypeRef").IsRequired(true);
            builder.Property(c => c.TaxRef).HasColumnName("TaxRef").IsRequired(true);

            builder.HasOne(c => c.CostType).WithMany(x => x.CostTypeTaxes).HasForeignKey(c => c.CostTypeRef);
            builder.HasOne(c => c.Tax).WithMany(x => x.CostTypeTaxes).HasForeignKey(c => c.TaxRef);
        }
    }
}
