using EmployeeTask.Aggregator.Entities;
using MediatR;
using SharedModels.DTO.EmployeeDTO;

namespace EmployeeTask.Aggregator.Queries
{
    public record GetEmployeesQuery() : IRequest<IEnumerable<EmployeeResponseGet>>;
}
