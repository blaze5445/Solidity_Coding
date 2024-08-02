using ICD.Base.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICD.Base.Data.Map
{
    public class ExpenseCenterLanguageMap : IEntityTypeConfiguration<ExpenseCenterLanguageEntity>
    {
        public void Configure(EntityTypeBuilder<ExpenseCenterLanguageEntity> builder)
        {
            builder.ToTable("ExpenseCenterLanguage", "BAS");

            builder.HasKey(ecl => ecl.Key);

            builder.Property(ecl => ecl.Key).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();
            builder.Property(ecl => ecl.LanguageRef).HasColumnName("LanguageRef").IsRequired();
            builder.Property(ecl => ecl._Title).HasColumnName("_Title").HasMaxLength(200).IsRequired();

            builder.HasOne(ecl => ecl.ExpenseCenter).WithMany(ec => ec.ExpenseCenterLanguages).HasForeignKey(ecl => ecl.ExpenseCenterRef);
        }
    }
}
