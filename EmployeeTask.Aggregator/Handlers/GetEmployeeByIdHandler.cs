using EmployeeTask.Aggregator.Queries;
using EmployeeTask.Aggregator.ServiceContracts;
using MediatR;
using SharedModels.DTO.EmployeeDTO;

namespace EmployeeTask.Aggregator.Handlers
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeResponse?>
    {
        private readonly IEmployeesService _employeesService;

        public GetEmployeeByIdHandler(IEmployeesService employeesService) => _employeesService = employeesService;

        public async Task<EmployeeResponse?> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            EmployeeResponse? employee = await _employeesService.GetEmployeeByID(request.Id);
            if (employee is null)
                return null;
            return employee;
        }
    }
}
