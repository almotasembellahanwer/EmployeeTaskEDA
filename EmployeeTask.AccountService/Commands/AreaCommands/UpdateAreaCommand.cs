using MediatR;
using SharedModels.DTO.AreaDTO;
namespace EmployeeTask.AccountService.AreaCommands
{
    public record UpdateAreaCommand(AreaUpdateRequest AreaDTO) : IRequest<AreaResponse>;
}
