using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICD.Base.Data.Map
{
    public class ChampionshipMap : IEntityTypeConfiguration<ChampionshipEntity>
    {
        public void Configure(EntityTypeBuilder<ChampionshipEntity> builder)
        {
            builder.ToTable("Amir_Championship_Test", "BAS");

            builder.HasKey(pt => pt.Key);

            builder.Property(pt => pt.Key).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();
            builder.Property(pt => pt.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
            builder.Property(pt => pt.StartDate).HasColumnName("StartDate").IsRequired();
            builder.Property(pt => pt.EndDate).HasColumnName("EndDate").IsRequired();
            builder.Property(pt => pt.Location).HasColumnName("Location").IsRequired();
            builder.Property(pt => pt.Description).HasColumnName("Description"); 
        }
    }
}
