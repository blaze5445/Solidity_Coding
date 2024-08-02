using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICD.Base.Data.Map
{
    public class GLNLanguageMap : IEntityTypeConfiguration<GLNLanguageEntity>
    {
        public void Configure(EntityTypeBuilder<GLNLanguageEntity> builder)
        {
            builder.ToTable("GLNLanguage", "BAS");

            builder.HasKey(gl => gl.Key);

            builder.Property(gl => gl.Key).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(gl => gl.GLNRef).HasColumnName("GLNRef").IsRequired(true);
            builder.Property(gl => gl.LanguageRef).HasColumnName("LanguageRef").IsRequired(true);
            builder.Property(gl => gl._Title).HasColumnName("_Title").IsRequired(true).HasMaxLength(100);
            builder.Property(gl => gl._Address).HasColumnName("_Address").IsRequired(true).HasMaxLength(500);

            builder.HasOne(gl => gl.GLNE).WithMany(g => g.GLNLanguages).HasForeignKey(gl => gl.GLNRef);
        }
    }
}
