using EmployeeTask.Aggregator.Queries.DepartmentQueries;
using EmployeeTask.Aggregator.ServiceContracts;
using MediatR;
using SharedModels.DTO.DepartmentDTO;

namespace EmployeeTask.Aggregator.Handlers.GovernorateHandlers
{
    public class GetDepartmentByIdHandler : IRequestHandler<GetDepartmentByIdQuery, DepartmentResponseGet?>
    {
        private readonly IDepartmentsService _departmentsService;

        public GetDepartmentByIdHandler(IDepartmentsService departmentsService) => _departmentsService = departmentsService;

        public async Task<DepartmentResponseGet?> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            DepartmentResponseGet? department = await _departmentsService.GetDepartmentByID(request.Id);
            if (department is null)
                return null;
            return department;
        }
    }
}
