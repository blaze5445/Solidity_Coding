using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICD.Base.Data.Map
{
    public class PersonIdentityMap : IEntityTypeConfiguration<PersonIdentityEntity>
    {
        public void Configure(EntityTypeBuilder<PersonIdentityEntity> builder)
        {
            builder.ToTable("PersonIdentity", "BAS");

            builder.HasKey(pi => pi.Key);

            builder.Property(pi => pi.Key).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(pi => pi.PersonRef).IsRequired(true);
            builder.Property(pi => pi.ItemRowRef_IdentityType).IsRequired(true);
            builder.Property(pi => pi.FirstIdNo).IsRequired(true).HasMaxLength(100);
            builder.Property(pi => pi.SecondIdNo).HasMaxLength(100).IsRequired(false);
            builder.Property(pi => pi.IssueDate).IsRequired(true).HasColumnType("Date");
            builder.Property(pi => pi.ExpireDate).IsRequired(false).HasColumnType("Date");
            builder.Property(pi => pi.LocationRef_IssuePlace).IsRequired(true);
            builder.Property(pi => pi.BirthDate).IsRequired(false).HasColumnType("Date");
            builder.Property(pi => pi.LocationRef_BirthLocation).IsRequired(false).HasColumnName("LocationRef_BirthPlace");

            builder.HasOne(pi => pi.Person).WithMany(p => p.PersonIdentities).HasForeignKey(pi => pi.PersonRef);
            builder.HasOne(pi => pi.BirthLocation).WithMany(l => l.BirthLocationPersonIdentities).HasForeignKey(pi => pi.LocationRef_BirthLocation);
            builder.HasOne(pi => pi.IssuePlace).WithMany(l => l.IssuePlacePersonIdentities).HasForeignKey(pi => pi.LocationRef_IssuePlace);
            builder.HasOne(pi => pi.ItemRow).WithMany(ir => ir.PersonIdentities).HasForeignKey(pi => pi.ItemRowRef_IdentityType);
        }
    }
}
