using MediatR;
using SharedModels.DTO.EmployeeDTO;

namespace EmployeeTask.AccountService.EmployeeCommands
{
    public record DeleteEmployeeCommand(int EmployeeID) : IRequest<bool>;
}
