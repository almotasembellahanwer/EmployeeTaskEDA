using EmployeeTask.AccountService.Commands.EmployeeCommands;
using EmployeeTask.AccountService.EmployeeCommands;
using EmployeeTask.AccountService.ServiceContracts;
using MassTransit;
using MediatR;
using SharedModels.DTO.EmployeeDTO;
using SharedModels.RabbitMQEvents.EmployeeEvents;

namespace EmployeeTask.AccountService.Handlers.EmployeeHandlers
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeResponse>
    {
        private readonly IEmployeesService _employeesService;
        private readonly IPublishEndpoint _publishEndpoint;

        public UpdateEmployeeHandler(IEmployeesService employeesService, IPublishEndpoint publishEndpoint)
        {
            _employeesService = employeesService;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<EmployeeResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            EmployeeResponse? employeeResponse = await _employeesService.UpdateEmployee(request.EmployeeDTO);
            if (employeeResponse is not null)
            {
                // Publish the event to rabbitmq
                await _publishEndpoint.Publish<IEmployeeUpdatedEvent>(new
                {
                    employeeResponse.EmployeeID,
                    employeeResponse.EmployeeName,
                    UpdatedAt = DateTime.UtcNow
                });
            }
            return employeeResponse ?? throw new InvalidOperationException("Error while updating an employee");
        }
    }
}
