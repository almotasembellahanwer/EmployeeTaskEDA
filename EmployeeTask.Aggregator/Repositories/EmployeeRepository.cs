using EmployeeTask.Aggregator.Data;
using EmployeeTask.Aggregator.Entities;
using EmployeeTask.Aggregator.IRepositoryContracts;
using Mapster;
using Microsoft.EntityFrameworkCore;
using SharedModels.DTO.EmployeeDTO;

namespace EmployeeTask.Aggregator.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AggregatorDbContext _context;

        public EmployeeRepository(AggregatorDbContext context) => _context = context;

        public async Task<IEnumerable<EmployeeResponseGet>?> GetAllEmployees()
        {
            IEnumerable<EmployeeResponseGet> employees = await _context.Employees
                .Select(e => new EmployeeResponseGet(e.EmployeeID, e.EmployeeName, e.Address.AddressName))
                .ToListAsync();
            if (employees is null)
                return new List<EmployeeResponseGet>();
            return employees;
        }

        public async Task<Employee?> GetEmployeeByID(int employeeID)
        {
            if (employeeID <= 0)
                throw new ArgumentException($"Invalid ID");

            EmployeeResponseGet? employeeResponse = await (from e in _context.Employees
                                                        join a in _context.Addresses on e.AddressID equals a.AddressID into addressGroup
                                                        from address in addressGroup.DefaultIfEmpty()
                                                        where e.EmployeeID == employeeID
                                                        select new EmployeeResponseGet(e.EmployeeID, e.EmployeeName, address.AddressName))
                                                            .FirstOrDefaultAsync();


            if (employeeResponse is null)
                return null;
            Employee? employee = employeeResponse.Adapt<Employee>();
            return employee;
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
                .FirstOrDefaultAsync(e => e.EmployeeID == entity.EmployeeID);
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
