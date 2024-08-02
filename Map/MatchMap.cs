using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICD.Base.Data.Map
{
    public class MatchMap : IEntityTypeConfiguration<MatchEntity>
    {
        public void Configure(EntityTypeBuilder<MatchEntity> builder)
        {
            builder.ToTable("Amir_Match_Test", "BAS");

            builder.HasKey(pt => pt.Key);

            builder.Property(pt => pt.Key).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();
            builder.Property(pt => pt.Date).HasColumnName("Date").IsRequired();
            builder.Property(pt => pt.Location).HasColumnName("Location").HasMaxLength(100).IsRequired();
            builder.Property(pt => pt.HomeTeamScore).HasColumnName("HomeTeamScore");
            builder.Property(pt => pt.AwayTeamScore).HasColumnName("AwayTeamScore");

            builder.HasOne(pt=>pt.HomeTeam).WithMany(ct=>ct.Matches).HasForeignKey(pt => pt.HomeTeamId);
            builder.HasOne(pt=>pt.AwayTeam).WithMany(ct=>ct.Matches1).HasForeignKey(pt => pt.AwayTeamId);
            builder.HasOne(pt=>pt.Championship).WithMany(ct=>ct.Matches).HasForeignKey(pt => pt.ChampionshipId);

        }
    }
}
