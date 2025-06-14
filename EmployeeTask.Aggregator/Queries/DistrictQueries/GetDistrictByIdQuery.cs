using MediatR;
using SharedModels.DTO.DistrictDTO;
namespace EmployeeTask.Aggregator.Queries.DistrictQueries
{
    public record GetDistrictByIdQuery(int Id) : IRequest<DistrictResponseGet>;
}
