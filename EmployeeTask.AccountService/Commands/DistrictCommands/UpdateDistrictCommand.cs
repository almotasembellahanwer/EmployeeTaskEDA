using MediatR;
using SharedModels.DTO.DistrictDTO;
namespace EmployeeTask.AccountService.DistrictCommands
{
    public record UpdateDistrictCommand(DistrictUpdateRequest DistrictDTO) : IRequest<DistrictResponse>;
}
