using MediatR;
using SharedModels.DTO.GovernorateDTO;
namespace EmployeeTask.AccountService.GovernorateCommands
{
    public record UpdateGovernorateCommand(GovernorateUpdateRequest GovernorateDTO) : IRequest<GovernorateResponse>;
}
