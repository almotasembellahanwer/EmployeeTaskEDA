using MediatR;

namespace EmployeeTask.AccountService.AreaCommands
{
    public record DeleteAreaCommand(int AreaID) : IRequest<bool>;
}
