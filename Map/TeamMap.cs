using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICD.Base.Data.Map
{
    public class TeamMap : IEntityTypeConfiguration<TeamEntity>
    {
        public void Configure(EntityTypeBuilder<TeamEntity> builder)
        {
            builder.ToTable("Amir_Team_Test", "BAS");

            builder.HasKey(pt => pt.Key);

            builder.Property(pt => pt.Key).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();
            builder.Property(pt => pt.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();

            builder.HasOne(pt => pt.Player).WithMany(ct => ct.Teams).HasForeignKey(pt => pt.CaptainId);
            builder.HasOne(ct => ct.Championship).WithMany(pt => pt.Teams).HasForeignKey(ct => ct.ChampionshipId);
        }
    }
}
