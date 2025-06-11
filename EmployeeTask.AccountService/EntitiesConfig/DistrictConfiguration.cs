using EmployeeTask.AccountService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeTask.AccountService.EntitiesConfig;
public class DistrictConfiguration : IEntityTypeConfiguration<District>
{
    public void Configure(EntityTypeBuilder<District> builder)
    {
        builder
            .HasKey(a => a.DistrictID);

        builder
             .Property(a => a.EnglishName)
             .HasMaxLength(40)
             .IsRequired();
        builder
            .Property(a => a.ArabicName)
            .HasMaxLength(40)
            .IsRequired();

        builder
            .Property(a => a.AreaID)
            .IsRequired(false);

        builder.ToTable("Districts");
    }
}
