using MediatR;
using SharedModels.DTO.EmployeeDTO;

namespace EmployeeTask.Aggregator.Queries
{
    public record GetEmployeeByIdQuery(int Id) : IRequest<EmployeeResponse>;
}
