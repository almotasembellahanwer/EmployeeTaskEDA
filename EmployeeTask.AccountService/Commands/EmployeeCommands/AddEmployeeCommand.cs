using MediatR;
using SharedModels.DTO.EmployeeDTO;

namespace EmployeeTask.AccountService.Commands.EmployeeCommands
{
    public record AddEmployeeCommand(EmployeeAddRequest EmployeeDTO) : IRequest<EmployeeResponse>;
}
