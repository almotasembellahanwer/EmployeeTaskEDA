using MediatR;
using SharedModels.DTO.AddressDTO;
using SharedModels.DTO.EmployeeDTO;

namespace EmployeeTask.Aggregator.Queries
{
    public record GetAddressByIdQuery(int Id) : IRequest<AddressResponse>;
}
