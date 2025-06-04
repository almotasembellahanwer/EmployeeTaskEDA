using MediatR;

namespace EmployeeTask.AccountService.AddressCommands
{
    public record DeleteAddressCommand(int AddressID) : IRequest<bool>;
}
