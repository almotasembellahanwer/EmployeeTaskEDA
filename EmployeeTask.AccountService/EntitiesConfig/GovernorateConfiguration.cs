using EmployeeTask.AccountService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeTask.AccountService.EntitiesConfig;
public class GovernorateConfiguration : IEntityTypeConfiguration<Governorate>
{
    public void Configure(EntityTypeBuilder<Governorate> builder)
    {
        builder
            .HasKey(a => a.GovernorateID);

        builder
            .Property(a => a.EnglishName)
            .HasMaxLength(40)
            .IsRequired();
        builder
            .Property(a => a.ArabicName)
            .HasMaxLength(40)
            .IsRequired();

        builder.ToTable("Governorates");
    }
}
