using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICD.Base.Data.Map
{
    public class PersonBaseTypeMap : IEntityTypeConfiguration<PersonBaseTypeEntity>
    {
        public void Configure(EntityTypeBuilder<PersonBaseTypeEntity> builder)
        {
            builder.ToTable("PersonBaseType", "BAS");

            builder.HasKey(pbt => pbt.Key);

            builder.Property(pbt => pbt.Key).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(pbt => pbt.PersonRef).IsRequired(true);
            builder.Property(pbt => pbt.BaseTypeRef).IsRequired(true);

            builder.HasOne(pbt => pbt.Person).WithMany(p => p.PersonBaseTypes).HasForeignKey(pbt => pbt.PersonRef);
            builder.HasOne(bpt => bpt.BaseType).WithMany(bt => bt.personBaseTypes).HasForeignKey(pbt => pbt.BaseTypeRef);
        }
    }
}
