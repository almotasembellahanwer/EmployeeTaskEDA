using MediatR;
using SharedModels.DTO.GovernorateDTO;

namespace EmployeeTask.Aggregator.Queries.GovernorateQueries
{
    public record GetGovernorateByIdQuery(int Id) : IRequest<GovernorateResponse>;
}
