using MediatR;
using SharedModels.DTO.AreaDTO;
using SharedModels.DTO.GovernorateDTO;

namespace EmployeeTask.AccountService.AreaCommands
{
    public record AddAreaCommand(AreaAddRequest AreaDTO) : IRequest<AreaResponse>;
}
