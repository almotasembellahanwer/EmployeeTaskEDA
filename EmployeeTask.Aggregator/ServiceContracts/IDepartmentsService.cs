using SharedModels.DTO.DepartmentDTO;
namespace EmployeeTask.Aggregator.ServiceContracts
{
    public interface IDepartmentsService
    {
        Task<IEnumerable<DepartmentResponseGet>?> GetAllDepartments(DepartmentSearchRequest? searchRequest);
        Task<DepartmentResponseGet?> GetDepartmentByID(int departmentID);
        Task<DepartmentResponse?> AddDepartment(DepartmentAddRequest? entity);
        Task<DepartmentResponse?> UpdateDepartment(DepartmentUpdateRequest? entity);
        Task<bool> DeleteDepartment(int departmentID);
    }
}
