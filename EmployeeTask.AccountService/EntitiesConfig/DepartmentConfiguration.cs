using EmployeeTask.AccountService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeTask.AccountService.EntitiesConfig;
public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder
            .HasKey(a => a.DepartmentID);

        builder
            .Property(a => a.DepartmentName)
            .HasMaxLength(40)
            .IsRequired();
        builder.ToTable("Departments");
    }
}
