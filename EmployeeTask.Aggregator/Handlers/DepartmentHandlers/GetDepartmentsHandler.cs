using EmployeeTask.Aggregator.Queries.AddressQueries;
using EmployeeTask.Aggregator.Queries.DepartmentQueries;
using EmployeeTask.Aggregator.Queries.GovernorateQueries;
using EmployeeTask.Aggregator.ServiceContracts;
using MediatR;
using SharedModels.DTO.AddressDTO;
using SharedModels.DTO.DepartmentDTO;
using SharedModels.DTO.GovernorateDTO;

namespace EmployeeTask.Aggregator.Handlers.DepartmentHandlers
{
    public class GetDepartmentsHandler : IRequestHandler<GetDepartmentsQuery, IEnumerable<DepartmentResponseGet>>
    {
        private readonly IDepartmentsService _departmentsService;

        public GetDepartmentsHandler(IDepartmentsService departmentsService)
        {
            _departmentsService = departmentsService;
        }

        public async Task<IEnumerable<DepartmentResponseGet>> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
        {
            // Get All Departments from database
            IEnumerable<DepartmentResponseGet>? departments = await _departmentsService.GetAllDepartments(request.searchRequest);
            
            if (departments is null)
                return new List<DepartmentResponseGet>();
            return departments;
        }
    }
}
