using EmployeeTask.Aggregator.Queries.EmployeeQueries;
using EmployeeTask.Aggregator.ServiceContracts;
using MediatR;
using SharedModels.DTO.EmployeeDTO;

namespace EmployeeTask.Aggregator.Handlers.EmployeeHandlers
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeResponseGet?>
    {
        private readonly IEmployeesService _employeesService;

        public GetEmployeeByIdHandler(IEmployeesService employeesService) => _employeesService = employeesService;

        public async Task<EmployeeResponseGet?> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            EmployeeResponseGet? employee = await _employeesService.GetEmployeeByID(request.Id);
            if (employee is null)
                return null;
            return employee;
        }
    }
}
