using EmployeeTask.Aggregator.Queries;
using EmployeeTask.Aggregator.ServiceContracts;
using MassTransit;
using MediatR;
using SharedModels.DTO.EmployeeDTO;
using SharedModels.RabbitMQEvents;

namespace EmployeeTask.Aggregator.Handlers
{
    public class GetEmployeesHandler : IRequestHandler<GetEmployeesQuery, IEnumerable<EmployeeResponseGet>>
    {
        private readonly IEmployeesService _employeesService;

        public GetEmployeesHandler(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        public async Task<IEnumerable<EmployeeResponseGet>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            // Get All Employees from database
            IEnumerable<EmployeeResponseGet>? employees =  await _employeesService.GetAllEmployees()
                ?? new List<EmployeeResponseGet>();
            
            if (employees is null)
                return new List<EmployeeResponseGet>();
            return employees;
        }
    }
}
