using MediatR;
using SharedModels.DTO.AddressDTO;
using SharedModels.DTO.EmployeeDTO;

namespace EmployeeTask.Aggregator.Queries.AddressQueries
{
    public record GetAddressByIdQuery(int Id) : IRequest<AddressResponse>;
}
