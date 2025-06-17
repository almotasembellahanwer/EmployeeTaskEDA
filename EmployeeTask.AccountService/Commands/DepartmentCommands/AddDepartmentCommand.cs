using MediatR;
using SharedModels.DTO.DepartmentDTO;
namespace EmployeeTask.AccountService.DepartmentCommands
{
    public record AddDepartmentCommand(DepartmentAddRequest DepartmentDTO) : IRequest<DepartmentResponse>;
}
