using MediatR;
using SharedModels.DTO.DepartmentDTO;
namespace EmployeeTask.Aggregator.Queries.DepartmentQueries
{
    public record GetDepartmentByIdQuery(int Id) : IRequest<DepartmentResponseGet>;
}
