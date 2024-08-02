using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICD.Base.Data.Map
{
    public class PlayerMap : IEntityTypeConfiguration<PlayerEntity>
    {
        public void Configure(EntityTypeBuilder<PlayerEntity> builder)
        {
            builder.ToTable("Amir_Player_Test", "BAS");

            builder.HasKey(pt => pt.Key);

            builder.Property(pt => pt.Key).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();
            builder.Property(pt => pt.FirstName).HasColumnName("FirstName").HasMaxLength(100).IsRequired();
            builder.Property(pt => pt.LastName).HasColumnName("LastName").HasMaxLength(100).IsRequired();
            builder.Property(pt => pt.DateOfBirth).HasColumnName("DateOfBirth").IsRequired();
            builder.Property(pt => pt.Position).HasColumnName("Position").HasMaxLength(100).IsRequired();

            builder.HasOne(pt => pt.Team).WithMany(ct => ct.Players).HasForeignKey(pt => pt.TeamId);
        }
    }
}
