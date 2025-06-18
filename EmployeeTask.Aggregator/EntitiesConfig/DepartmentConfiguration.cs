using EmployeeTask.Aggregator.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeTask.Aggregator.EntitiesConfig;
public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder
            .HasKey(d => d.DepartmentID);
        builder
            .Property(d => d.DepartmentName)
            .HasMaxLength(40)
            .IsRequired();
        builder.ToTable("Departments");
    }
}
