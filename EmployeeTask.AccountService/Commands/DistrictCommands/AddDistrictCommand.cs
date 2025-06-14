using MediatR;
using SharedModels.DTO.DistrictDTO;
namespace EmployeeTask.AccountService.DistrictCommands
{
    public record AddDistrictCommand(DistrictAddRequest DistrictDTO) : IRequest<DistrictResponse>;
}
