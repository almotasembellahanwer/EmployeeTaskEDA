using EmployeeTask.AccountService.Data;
using EmployeeTask.AccountService.Entities;
using EmployeeTask.AccountService.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTask.AccountService.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AccountDbContext _context;

        public EmployeeRepository(AccountDbContext context)
        {
            _context = context;
        }

        public async Task<Employee?> AddEmployee(Employee? entity)
        {
            if (entity is null)
                throw new ArgumentException("Invalid Employee");
            _context.Employees.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
