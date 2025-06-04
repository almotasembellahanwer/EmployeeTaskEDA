using EmployeeTask.Aggregator.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeTask.Aggregator.EntitiesConfig;
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

    builder.Ignore(e => e.AddressName);

        builder.ToTable("Employees");
    }
}
