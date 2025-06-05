using SharedModels.DTO.EmployeeDTO;
namespace EmployeeTask.Aggregator.ServiceContracts;
public interface IEmployeesService
{
    Task<IEnumerable<EmployeeResponseGet>?> GetAllEmployees();
    Task<EmployeeResponseGet?> GetEmployeeByID(int employeeID);
    Task<EmployeeResponse?> AddEmployee(EmployeeAddRequest? entity);
    Task<EmployeeResponse?> UpdateEmployee(EmployeeUpdateRequest? entity);
    Task<bool> DeleteEmployee(int employeeID);
}
