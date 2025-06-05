using EmployeeTask.AccountService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeTask.AccountService.EntitiesConfig;
public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder
            .HasKey(a => a.EmployeeID);

        builder
            .Property(a => a.EmployeeName)
            .HasMaxLength(40)
            .IsRequired();

        builder
            .HasOne(e => e.Address)
            .WithOne()
            .HasForeignKey<Employee>(e=>e.AddressID)
            .IsRequired(false);

        builder.ToTable("Employees");
    }
}
