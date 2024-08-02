using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICD.Base.Data.Map
{
    public class PersonMap : IEntityTypeConfiguration<PersonEntity>
    {
        public void Configure(EntityTypeBuilder<PersonEntity> builder)
        {
            builder.ToTable("Person", "BAS");

            builder.HasKey(p => p.Key);

            builder.Property(p => p.Key).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(p => p.PersonTitleRef).IsRequired(true);
            builder.Property(p => p.EconomicId).IsRequired(false).HasMaxLength(20);
            builder.Property(p => p.NationalIdentity).IsRequired(false).HasMaxLength(20);

            builder.HasOne(p => p.PersonTitle).WithMany(pt => pt.Persons).HasForeignKey(p => p.PersonTitleRef);
        }
    }
}
