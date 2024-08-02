using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICD.Base.Data.Map
{
    public class PersonContactMap : IEntityTypeConfiguration<PersonContactEntity>
    {
        public void Configure(EntityTypeBuilder<PersonContactEntity> builder)
        {
            builder.ToTable("PersonContact", "BAS");

            builder.HasKey(pc => pc.Key);

            builder.Property(pc => pc.Key).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(pc => pc.ContactInfo).HasColumnName("ContactInfo").IsRequired(true).HasMaxLength(200);
            builder.Property(pc => pc.IsMain).HasColumnName("IsMain").IsRequired(true);
            builder.Property(pc => pc.PersonRef).HasColumnName("PersonRef").IsRequired(true);
            builder.Property(pc => pc.ContactTypeRef).HasColumnName("ContactTypeRef").IsRequired(true);

            builder.HasOne(pc => pc.Person).WithMany(p => p.PersonContacts).HasForeignKey(pc => pc.PersonRef);
            builder.HasOne(pc => pc.ContactType).WithMany(ct => ct.PersonContacts).HasForeignKey(pc => pc.ContactTypeRef);
        }
    }
}
