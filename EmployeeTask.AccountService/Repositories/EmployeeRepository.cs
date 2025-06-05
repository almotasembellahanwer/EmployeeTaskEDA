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
        public async Task<Employee?> UpdateEmployee(Employee? entity)
        {
            if (entity is null)
                throw new ArgumentException("Invalid Employee");
            Employee? existingEmployee = await _context.Employees
                .FirstOrDefaultAsync(e=>e.EmployeeID == entity.EmployeeID);
            if (existingEmployee is null)
                return null;
            existingEmployee.EmployeeID = entity.EmployeeID;
            existingEmployee.EmployeeName = entity.EmployeeName;
            existingEmployee.AddressID = entity.AddressID;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteEmployee(int employeeID)
        {
            Employee? employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.EmployeeID == employeeID);
            if (employee is null)
                return false;
            _context.Employees.Remove(employee);
            int rowsCountAffected = await _context.SaveChangesAsync();
            return rowsCountAffected > 0;
        }
    }
}
