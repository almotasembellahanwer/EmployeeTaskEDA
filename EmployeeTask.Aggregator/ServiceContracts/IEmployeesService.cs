using SharedModels.DTO.EmployeeDTO;
namespace EmployeeTask.Aggregator.ServiceContracts;
public interface IEmployeesService
{
    Task<IEnumerable<EmployeeResponse>?> GetAllEmployees();
    Task<EmployeeResponse?> GetEmployeeByID(int employeeID);
    Task<EmployeeResponse?> AddEmployee(EmployeeAddRequest? entity);
}
