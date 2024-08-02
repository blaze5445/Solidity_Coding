using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICD.Base.Data.Map
{
    public class GLNMap : IEntityTypeConfiguration<GLNEntity>
    {
        public void Configure(EntityTypeBuilder<GLNEntity> builder)
        {
            builder.ToTable("GLN", "BAS");

            builder.HasKey(g => g.Key);

            builder.Property(g => g.Key).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(g => g.PersonRef).HasColumnName("PersonRef").IsRequired(true);
            builder.Property(g => g.GLN).HasColumnName("GLN").IsRequired(true).HasMaxLength(20);
        }
    }
}
