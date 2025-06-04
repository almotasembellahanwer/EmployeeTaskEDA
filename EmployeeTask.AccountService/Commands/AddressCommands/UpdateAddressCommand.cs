using MediatR;
using SharedModels.DTO;
using SharedModels.DTO.AddressDTO;

namespace EmployeeTask.AccountService.AddressCommands
{
    public record UpdateAddressCommand(AddressUpdateRequest AddressDTO) : IRequest<AddressResponse>;
}
