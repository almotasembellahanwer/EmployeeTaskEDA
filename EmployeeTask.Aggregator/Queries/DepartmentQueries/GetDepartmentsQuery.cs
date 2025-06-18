using MediatR;
using SharedModels.DTO.DepartmentDTO;
namespace EmployeeTask.Aggregator.Queries.DepartmentQueries
{
    public record GetDepartmentsQuery(DepartmentSearchRequest searchRequest) : IRequest<IEnumerable<DepartmentResponseGet>>;
}
