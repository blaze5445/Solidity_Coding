using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICD.Base.Data.Map
{
    public class SanaSupportInfoMap : IEntityTypeConfiguration<SanaSupportInfoEntity>
    {
        public void Configure(EntityTypeBuilder<SanaSupportInfoEntity> builder)
        {
            builder.ToTable("SanaSupportInfo", "BAS");

            builder.HasKey(ssi => ssi.Key);

            builder.Property(ssi => ssi.Key).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();
            builder.Property(ssi => ssi.PhoneNo).HasColumnName("PhoneNo").HasMaxLength(50).IsRequired();
            builder.Property(ssi => ssi.WhatsAppID).HasColumnName("WhatsAppID").HasMaxLength(50).IsRequired();
            builder.Property(ssi => ssi.CreateDate).HasColumnName("CreateDate").IsRequired();
            builder.Property(ssi => ssi.MobileNo).HasColumnName("MobileNo").HasMaxLength(50);

            builder.HasOne(ssi => ssi.Person).WithMany(p => p.SanaSupportInfos).HasForeignKey(ssi => ssi.PersonRef);

        }
    }
}
