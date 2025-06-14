using MediatR;
using SharedModels.DTO.DistrictDTO;
namespace EmployeeTask.Aggregator.Queries.DistrictQueries
{
    public record GetDistrictsQuery() : IRequest<IEnumerable<DistrictResponseGet>>;
}
