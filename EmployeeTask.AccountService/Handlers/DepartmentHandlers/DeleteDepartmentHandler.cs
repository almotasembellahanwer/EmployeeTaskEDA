using EmployeeTask.AccountService.DepartmentCommands;
using EmployeeTask.AccountService.ServiceContracts;
using MassTransit;
using MediatR;
using SharedModels.RabbitMQEvents.DepartmentEvents;

namespace EmployeeTask.AccountService.Handlers.DepartmentHandlers
{
    public class DeleteDepartmentHandler : IRequestHandler<DeleteDepartmentCommand, bool>
    {
        private readonly IDepartmentsService _departmentsService;
        private readonly IPublishEndpoint _publishEndpoint;

        public DeleteDepartmentHandler(IDepartmentsService departmentsService, IPublishEndpoint publishEndpoint)
        {
            _departmentsService = departmentsService;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<bool> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            bool isDeleted = await _departmentsService.DeleteDepartment(request.DepartmentID);
            if (isDeleted)
            {
                // Publish the event to rabbitmq
                await _publishEndpoint.Publish<IDepartmentDeletedEvent>(new
                {
                    request.DepartmentID,
                    DeletedAt = DateTime.UtcNow
                });
            }
            return isDeleted;
        }
    }
}
