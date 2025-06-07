using EmployeeTask.AccountService.Commands.EmployeeCommands;
using EmployeeTask.AccountService.ServiceContracts;
using MassTransit;
using MediatR;
using SharedModels.DTO.EmployeeDTO;
using SharedModels.RabbitMQEvents.EmployeeEvents;

namespace EmployeeTask.AccountService.Handlers.EmployeeHandlers
{
    public class AddEmployeeHandler : IRequestHandler<AddEmployeeCommand, EmployeeResponse>
    {
        private readonly IEmployeesService _employeesService;
        private readonly IPublishEndpoint _publishEndpoint;

        public AddEmployeeHandler(IEmployeesService employeesService, IPublishEndpoint publishEndpoint)
        {
            _employeesService = employeesService;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<EmployeeResponse> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            EmployeeResponse? employeeResponse = await _employeesService.AddEmployee(request.EmployeeDTO);
            if (employeeResponse is not null)
            {
                // Publish the event to rabbitmq
                await _publishEndpoint.Publish<IEmployeeCreatedEvent>(new
                {
                    employeeResponse.EmployeeID,
                    employeeResponse.EmployeeName,
                    employeeResponse.AddressID
                });
            }
            return employeeResponse ?? throw new InvalidOperationException("Error while adding an employee");
        }
    }
}
