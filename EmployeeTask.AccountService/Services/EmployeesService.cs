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
        public async Task<EmployeeResponse?> UpdateEmployee(EmployeeUpdateRequest? entity)
        {
            if (entity is null)
                throw new ArgumentException("Invalid employee to add");
            Employee employee = entity.Adapt<Employee>();
            Employee? employeeUpdated = await _employeeRepository.UpdateEmployee(employee);
            if (employeeUpdated is null)
                throw new ArgumentException("error while updating employee");
            EmployeeResponse response = employeeUpdated.Adapt<EmployeeResponse>();
            return response;
        }
        public async Task<bool> DeleteEmployee(int employeeID)
        {
            if (employeeID == 0)
                throw new ArgumentException("Invalid ID");
            bool isDeleted = await _employeeRepository.DeleteEmployee(employeeID);
            return isDeleted;
        }
    }
}
