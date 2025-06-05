using EmployeeTask.AccountService.Entities;

namespace EmployeeTask.AccountService.RepositoryContracts
{
    public interface IEmployeeRepository
    {
        Task<Employee?> AddEmployee(Employee? entity);
        Task<Employee?> UpdateEmployee(Employee? entity);
        Task<bool> DeleteEmployee(int employeeID);
    }
}
