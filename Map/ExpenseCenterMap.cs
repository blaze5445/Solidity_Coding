using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICD.Base.Data.Map
{
    public class ExpenseCenterMap : IEntityTypeConfiguration<ExpenseCenterEntity>
    {
        public void Configure(EntityTypeBuilder<ExpenseCenterEntity> builder)
        {
            builder.ToTable("ExpenseCenter", "BAS");

            builder.HasKey(ec => ec.Key);

            builder.Property(ec => ec.Key).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();
            builder.Property(ec => ec.IsActive).HasColumnName("IsActive").IsRequired();
            builder.Property(ec => ec.CompanyRef).HasColumnName("CompanyRef").IsRequired();

        }
    }
}
