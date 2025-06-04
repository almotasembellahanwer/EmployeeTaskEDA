using EmployeeTask.Aggregator.Entities;
using EmployeeTask.Aggregator.EntitiesConfig;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTask.Aggregator.Data
{
    public class AggregatorDbContext : DbContext
    {
        public AggregatorDbContext(DbContextOptions<AggregatorDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());

        }
    }
}
