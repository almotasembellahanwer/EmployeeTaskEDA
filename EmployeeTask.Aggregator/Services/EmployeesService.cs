using EmployeeTask.Aggregator.Entities;
using EmployeeTask.Aggregator.IRepositoryContracts;
using EmployeeTask.Aggregator.ServiceContracts;
using Mapster;
using SharedModels.DTO.EmployeeDTO;
namespace EmployeeTask.Aggregator.Services;
public class EmployeesService : IEmployeesService
{
    private readonly IEmployeeRepository _employeeRepository;


    public EmployeesService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<IEnumerable<EmployeeResponse>?> GetAllEmployees()
    {
        IEnumerable<EmployeeResponse>? employees = await _employeeRepository.GetAllEmployees();
        if (employees is null)
            return new List<EmployeeResponse>();
        return employees;
    }

    public async Task<EmployeeResponse?> GetEmployeeByID(int employeeID)
    {
        if (employeeID == 0)
            throw new ArgumentException("Invalid ID");
        Employee? employee = await _employeeRepository.GetEmployeeByID(employeeID);
        if (employee is null)
            return null;
        EmployeeResponse response = employee.Adapt<EmployeeResponse>();
        return response;
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
