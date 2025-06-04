using EmployeeTask.AccountService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeTask.AccountService.EntitiesConfig;
public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder
            .HasKey(a => a.AddressID);

        builder
            .Property(a => a.AddressName)
            .HasMaxLength(70)
            .IsRequired();

        builder.ToTable("Addresses");
    }
}
