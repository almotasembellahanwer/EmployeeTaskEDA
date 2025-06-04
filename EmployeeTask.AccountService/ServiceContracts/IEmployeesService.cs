using SharedModels.DTO.EmployeeDTO;

namespace EmployeeTask.AccountService.ServiceContracts
{
    public interface IEmployeesService
    {
        Task<EmployeeResponse?> AddEmployee(EmployeeAddRequest? entity);
    }
}
