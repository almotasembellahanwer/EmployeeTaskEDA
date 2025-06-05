using MediatR;
using SharedModels.DTO.EmployeeDTO;

namespace EmployeeTask.AccountService.EmployeeCommands
{
    public record UpdateEmployeeCommand(EmployeeUpdateRequest EmployeeDTO) : IRequest<EmployeeResponse>;
}
