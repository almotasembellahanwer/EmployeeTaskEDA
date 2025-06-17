using MediatR;
using SharedModels.DTO.DepartmentDTO;
namespace EmployeeTask.AccountService.DepartmentCommands
{
    public record UpdateDepartmentCommand(DepartmentUpdateRequest DepartmentDTO) : IRequest<DepartmentResponse>;
}
