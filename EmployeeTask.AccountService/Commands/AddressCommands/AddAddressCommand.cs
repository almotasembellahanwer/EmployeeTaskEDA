using MediatR;
using SharedModels.DTO;
using SharedModels.DTO.AddressDTO;

namespace EmployeeTask.AccountService.AddressCommands
{
    public record AddAddressCommand(AddressAddRequest AddressDTO) : IRequest<AddressResponse>;
}
