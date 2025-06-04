using EmployeeTask.AccountService.Entities;
using EmployeeTask.AccountService.RepositoryContracts;
using EmployeeTask.AccountService.ServiceContracts;
using Mapster;
using SharedModels.DTO.EmployeeDTO;

namespace EmployeeTask.AccountService.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeResponse?> AddEmployee(EmployeeAddRequest? entity)
        {
            if (entity is null)
                throw new ArgumentException("Invalid employee to add");
            Employee employee = entity.Adapt<Employee>();
            Employee? employeeAdded = await _employeeRepository.AddEmployee(employee);
            if (employeeAdded is null)
                throw new InvalidOperationException("error while adding employee");
            EmployeeResponse response = employeeAdded.Adapt<EmployeeResponse>();
            return response;
        }
    }
}
