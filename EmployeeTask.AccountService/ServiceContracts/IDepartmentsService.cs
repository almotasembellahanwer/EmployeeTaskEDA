using SharedModels.DTO.DepartmentDTO;
namespace EmployeeTask.AccountService.ServiceContracts
{
    public interface IDepartmentsService
    {
        Task<DepartmentResponse?> AddDepartment(DepartmentAddRequest? entity);
        Task<DepartmentResponse?> UpdateDepartment(DepartmentUpdateRequest? entity);
        Task<bool> DeleteDepartment(int departmentID);
    }
}
