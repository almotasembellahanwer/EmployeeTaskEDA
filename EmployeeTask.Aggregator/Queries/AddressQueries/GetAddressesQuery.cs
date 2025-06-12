using EmployeeTask.Aggregator.Entities;
using MediatR;
using SharedModels.DTO.AddressDTO;
using SharedModels.DTO.EmployeeDTO;

namespace EmployeeTask.Aggregator.Queries.AddressQueries
{
    public record GetAddressesQuery() : IRequest<IEnumerable<AddressResponse>>;
}
