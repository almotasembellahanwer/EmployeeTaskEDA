using EmployeeTask.AccountService.Entities;
using EmployeeTask.AccountService.EntitiesConfig;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTask.AccountService.Data;
public class AccountDbContext : DbContext
{
    public AccountDbContext(DbContextOptions<AccountDbContext> options)
        : base(options)
    {
        
    }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Governorate> Governorates { get; set; }
    public DbSet<Area> Areas { get; set; }
    public DbSet<District> Districts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        modelBuilder.ApplyConfiguration(new AddressConfiguration());

    }
}
