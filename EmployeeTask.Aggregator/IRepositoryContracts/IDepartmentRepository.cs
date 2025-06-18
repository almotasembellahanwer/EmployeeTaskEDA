using EmployeeTask.Aggregator.Entities;
using SharedModels.DTO.DepartmentDTO;

namespace EmployeeTask.Aggregator.IRepositoryContracts
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>?> GetAllDepartments(DepartmentSearchRequest? searchRequest);
        Task<Department?> GetDepartmentByID(int departmentID);
        Task<Department?> AddDepartment(Department? entity);
        Task<Department?> UpdateDepartment(Department? entity);
        Task<bool> DeleteDepartment(int departmentID);
    }
}
