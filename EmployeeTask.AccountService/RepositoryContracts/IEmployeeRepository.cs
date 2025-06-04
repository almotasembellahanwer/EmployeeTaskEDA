using EmployeeTask.AccountService.Entities;

namespace EmployeeTask.AccountService.RepositoryContracts
{
    public interface IEmployeeRepository
    {
        Task<Employee?> AddEmployee(Employee? entity);
    }
}
