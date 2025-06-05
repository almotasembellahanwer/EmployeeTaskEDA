using EmployeeTask.AccountService.EmployeeCommands;
using EmployeeTask.AccountService.ServiceContracts;
using MassTransit;
using MediatR;
using SharedModels.RabbitMQEvents.EmployeeEvents;

namespace EmployeeTask.AccountService.Handlers.EmployeeHandlers
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly IEmployeesService _employeesService;
        private readonly IPublishEndpoint _publishEndpoint;

        public DeleteEmployeeHandler(IEmployeesService employeesService, IPublishEndpoint publishEndpoint)
        {
            _employeesService = employeesService;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            bool isDeleted = await _employeesService.DeleteEmployee(request.EmployeeID);
            if (isDeleted)
            {
                // Publish the event to rabbitmq
                await _publishEndpoint.Publish<IEmployeeDeletedEvent>(new
                {
                    request.EmployeeID,
                    DeletedAt = DateTime.UtcNow
                });
            }
            return isDeleted;
        }
    }
}
