using EmployeeTask.Aggregator.Entities;
using SharedModels.DTO.EmployeeDTO;

namespace EmployeeTask.Aggregator.IRepositoryContracts
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeResponse>?> GetAllEmployees();
        Task<Employee?> GetEmployeeByID(int employeeID);
        Task<Employee?> AddEmployee(Employee? entity);
    }
}
