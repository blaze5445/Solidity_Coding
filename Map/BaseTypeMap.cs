using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICD.Base.Data.Map
{
    public class BaseTypeMap : IEntityTypeConfiguration<BaseTypeEntity>
    {
        public void Configure(EntityTypeBuilder<BaseTypeEntity> builder)
        {
            builder.ToTable("BaseType", "BAS");

            builder.HasKey(bt => bt.Key);

            builder.Property(bt => bt.Key).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(bt => bt.Alias).IsRequired(true).HasMaxLength(100);
        }
    }
}
