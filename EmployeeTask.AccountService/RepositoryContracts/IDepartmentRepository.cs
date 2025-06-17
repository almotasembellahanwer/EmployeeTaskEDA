using EmployeeTask.AccountService.Entities;

namespace EmployeeTask.AccountService.RepositoryContracts
{
    public interface IDepartmentRepository
    {
        Task<Department?> AddDepartment(Department? entity);
        Task<Department?> UpdateDepartment(Department? entity);
        Task<bool> DeleteDepartment(int departmentID);
    }
}
