using MediatR;

namespace EmployeeTask.AccountService.DistrictCommands
{
    public record DeleteDistrictCommand(int DistrictID) : IRequest<bool>;
}
