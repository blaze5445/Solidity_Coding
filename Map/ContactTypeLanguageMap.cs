using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICD.Base.Data.Map
{
    public class ContactTypeLanguageMap : IEntityTypeConfiguration<ContactTypeLanguageEntity>
    {
        public void Configure(EntityTypeBuilder<ContactTypeLanguageEntity> builder)
        {
            builder.ToTable("ContactTypeLanguage", "BAS");

            builder.HasKey(ctl => ctl.Key);

            builder.Property(ctl => ctl.Key).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(ctl => ctl._Title).IsRequired(true).HasMaxLength(50);
            builder.Property(ctl => ctl.LanguageRef).IsRequired(true);
            builder.Property(ctl => ctl.ContactTypeRef).IsRequired(true);

            builder.HasOne(ctl => ctl.ContactType).WithMany(ct => ct.ContactTypeLanguages).HasForeignKey(ctl => ctl.ContactTypeRef);
        }
    }
}
