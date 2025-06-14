using MediatR;
using SharedModels.DTO.AreaDTO;
namespace EmployeeTask.Aggregator.Queries.AreaQueries
{
    public record GetAreasQuery() : IRequest<IEnumerable<AreaResponseGet>>;
}
