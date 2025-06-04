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

        public async Task<IEnumerable<EmployeeResponse>?> GetAllEmployees()
        {
            IEnumerable<EmployeeResponse> employees = await _context.Employees
                .Select(e => new EmployeeResponse(e.EmployeeID, e.EmployeeName, e.Address.AddressName))
                .ToListAsync();
            if (employees is null)
                return new List<EmployeeResponse>();
            return employees;
        }

        public async Task<Employee?> GetEmployeeByID(int employeeID)
        {
            if (employeeID <= 0)
                throw new ArgumentException($"Invalid ID");

            EmployeeResponse? employeeResponse = await (from e in _context.Employees
                                                        join a in _context.Addresses on e.AddressID equals a.AddressID into addressGroup
                                                        from address in addressGroup.DefaultIfEmpty()
                                                        where e.EmployeeID == employeeID
                                                        select new EmployeeResponse(e.EmployeeID, e.EmployeeName, address.AddressName))
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
    }
}
