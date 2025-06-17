using MediatR;
namespace EmployeeTask.AccountService.DepartmentCommands
{
    public record DeleteDepartmentCommand(int DepartmentID) : IRequest<bool>;
}
