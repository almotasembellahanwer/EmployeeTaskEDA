using MediatR;
using SharedModels.DTO.GovernorateDTO;

namespace EmployeeTask.Aggregator.Queries.GovernorateQueries
{
    public record GetGovernoratesQuery() : IRequest<IEnumerable<GovernorateResponse>>;
}
