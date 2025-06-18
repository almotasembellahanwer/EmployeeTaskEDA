using EmployeeTask.AccountService.DepartmentCommands;
using EmployeeTask.AccountService.ServiceContracts;
using MassTransit;
using MediatR;
using SharedModels.DTO.DepartmentDTO;
using SharedModels.RabbitMQEvents.DepartmentEvents;

namespace EmployeeTask.AccountService.Handlers.DepartmentHandlers
{
    public class AddDepartmentHandler : IRequestHandler<AddDepartmentCommand, DepartmentResponse>
    {
        private readonly IDepartmentsService _departmentsService;
        private readonly IPublishEndpoint _publishEndpoint;

        public AddDepartmentHandler(IDepartmentsService departmentsService, IPublishEndpoint publishEndpoint)
        {
            _departmentsService = departmentsService;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<DepartmentResponse> Handle(AddDepartmentCommand request, CancellationToken cancellationToken)
        {
            DepartmentResponse? departmentResponse = await _departmentsService.AddDepartment(request.DepartmentDTO);
            if (departmentResponse is not null)
            {
                // Publish the event to rabbitmq
                await _publishEndpoint.Publish<IDepartmentCreatedEvent>(new
                {
                    departmentResponse.DepartmentID,
                    departmentResponse.DepartmentName,
                    departmentResponse.Active
                });
            }
            return departmentResponse ?? throw new InvalidOperationException("Error while adding a department");
        }
    }
}
