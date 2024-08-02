using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICD.Base.Data.Map
{
    public class ContactTypeMap : IEntityTypeConfiguration<ContactTypeEntity>
    {
        public void Configure(EntityTypeBuilder<ContactTypeEntity> builder)
        {
            builder.ToTable("ContactType", "BAS");

            builder.HasKey(ct => ct.Key);

            builder.Property(ct => ct.Key).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(ct => ct.Alias).HasColumnName("Alias").HasMaxLength(50).IsRequired(true);
            builder.Property(ct => ct.IsActive).HasColumnName("IsActive").IsRequired(true);
        }
    }
}
