using EmployeeTask.Aggregator.Entities;
using SharedModels.DTO.EmployeeDTO;

namespace EmployeeTask.Aggregator.IRepositoryContracts
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeResponseGet>?> GetAllEmployees();
        Task<Employee?> GetEmployeeByID(int employeeID);
        Task<Employee?> AddEmployee(Employee? entity);
        Task<Employee?> UpdateEmployee(Employee? entity);
        Task<bool> DeleteEmployee(int employeeID);
    }
}
