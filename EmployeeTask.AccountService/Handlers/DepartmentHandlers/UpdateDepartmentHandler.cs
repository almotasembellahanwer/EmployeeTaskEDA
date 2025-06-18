using EmployeeTask.AccountService.DepartmentCommands;
using EmployeeTask.AccountService.ServiceContracts;
using MassTransit;
using MediatR;
using SharedModels.DTO.DepartmentDTO;
using SharedModels.RabbitMQEvents.DepartmentEvents;

namespace EmployeeTask.AccountService.Handlers.DepartmentHandlers
{
    public class UpdateDepartmentHandler : IRequestHandler<UpdateDepartmentCommand, DepartmentResponse>
    {
        private readonly IDepartmentsService _departmentsService;
        private readonly IPublishEndpoint _publishEndpoint;

        public UpdateDepartmentHandler(IDepartmentsService departmentsService, IPublishEndpoint publishEndpoint)
        {
            _departmentsService = departmentsService;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<DepartmentResponse> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            DepartmentResponse? departmentResponse = await _departmentsService.UpdateDepartment(request.DepartmentDTO);
            if (departmentResponse is not null)
            {
                // Publish the event for update to rabbitmq
                await _publishEndpoint.Publish<IDepartmentUpdatedEvent>(new
                {
                    departmentResponse.DepartmentName,
                    departmentResponse.Active,
                    UpdatedAt = DateTime.UtcNow
                });
            }
            return departmentResponse ?? throw new InvalidOperationException("Error while adding an department");
        }
    }
}
