using EmployeeTask.AccountService.Data;
using EmployeeTask.AccountService.Entities;
using EmployeeTask.AccountService.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTask.AccountService.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AccountDbContext _context;

        public DepartmentRepository(AccountDbContext context)
        {
            _context = context;
        }

        public async Task<Department?> AddDepartment(Department? entity)
        {
            if (entity is null)
                throw new ArgumentException("Invalid Department");
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
