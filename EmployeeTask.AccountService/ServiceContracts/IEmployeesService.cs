using SharedModels.DTO.EmployeeDTO;

namespace EmployeeTask.AccountService.ServiceContracts
{
    public interface IEmployeesService
    {
        Task<EmployeeResponse?> AddEmployee(EmployeeAddRequest? entity);
        Task<EmployeeResponse?> UpdateEmployee(EmployeeUpdateRequest? entity);
        Task<bool> DeleteEmployee(int employeeID);
    }
}
