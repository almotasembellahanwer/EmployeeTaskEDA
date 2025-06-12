using MediatR;
using SharedModels.DTO.EmployeeDTO;

namespace EmployeeTask.Aggregator.Queries.EmployeeQueries
{
    public record GetEmployeeByIdQuery(int Id) : IRequest<EmployeeResponseGet>;
}
