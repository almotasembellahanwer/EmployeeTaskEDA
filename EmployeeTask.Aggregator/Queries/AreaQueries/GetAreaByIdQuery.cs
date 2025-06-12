using MediatR;
using SharedModels.DTO.AreaDTO;
namespace EmployeeTask.Aggregator.Queries.AreaQueries
{
    public record GetAreaByIdQuery(int Id) : IRequest<AreaResponse>;
}
