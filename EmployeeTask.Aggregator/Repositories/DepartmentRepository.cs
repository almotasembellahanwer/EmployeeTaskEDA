using EmployeeTask.Aggregator.Data;
using EmployeeTask.Aggregator.Entities;
using EmployeeTask.Aggregator.Extensions;
using EmployeeTask.Aggregator.IRepositoryContracts;
using Microsoft.EntityFrameworkCore;
using SharedModels.DTO.DepartmentDTO;
namespace EmployeeTask.Aggregator.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AggregatorDbContext _context;

        public DepartmentRepository(AggregatorDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>?> GetAllDepartments(DepartmentSearchRequest? searchRequest)
        {
            IQueryable<Department> query = _context.Departments.AsQueryable();
            if (searchRequest is not null)
                query = query.ApplySearch(searchRequest);
            IEnumerable<Department> response = await query
            .ToListAsync();
            if (response is null)
                return new List<Department>();
            return response;
        }

        public async Task<Department?> GetDepartmentByID(int departmentID)
        {
            if (departmentID == 0)
                throw new ArgumentException($"Invalid ID");

            var departmentResponse = await _context.Departments
                .FirstOrDefaultAsync(d => d.DepartmentID == departmentID);
            if (departmentResponse is null)
                return null;
            return departmentResponse;
        }


        public async Task<Department?> AddDepartment(Department? entity)
        {
            if (entity is null)
                throw new ArgumentException("Invalid Department");
            if(await _context.Departments.AnyAsync(d => d.DepartmentID == entity.DepartmentID))
            {
                throw new InvalidOperationException($"Department with ID {entity.DepartmentID} already exists");
            }
            _context.Departments.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<Department?> UpdateDepartment(Department? entity)
        {
            if (entity is null)
                throw new ArgumentException("Invalid Department");

            Department? existingDepartment = await _context.Departments
                .FirstOrDefaultAsync(a => a.DepartmentID == entity.DepartmentID);
            if (existingDepartment is null || existingDepartment.DepartmentID != entity.DepartmentID)
                return null;
            existingDepartment.DepartmentName = entity.DepartmentName;
            existingDepartment.Active = entity.Active;
            existingDepartment.CreatedAt = entity.CreatedAt;

            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteDepartment(int departmentID)
        {

            Department? department = await _context.Departments
                .FirstOrDefaultAsync(a => a.DepartmentID == departmentID);
            if (department is null)
                return false;
            _context.Departments.Remove(department);
            int rowsCountAffected = await _context.SaveChangesAsync();
            return rowsCountAffected > 0;
        }

    }
}
