using MediatR;

namespace EmployeeTask.AccountService.GovernorateCommands
{
    public record DeleteGovernorateCommand(int GovernorateID) : IRequest<bool>;
}
