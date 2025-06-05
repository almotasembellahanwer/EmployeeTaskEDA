using EmployeeTask.Aggregator.ServiceContracts;
using MassTransit;
using SharedModels.DTO.EmployeeDTO;
using SharedModels.RabbitMQEvents.EmployeeEvents;

namespace EmployeeTask.Aggregator.EmployeeConsumer
{
    public class EmployeeUpdatedConsumer : IConsumer<IEmployeeUpdatedEvent>
    {
        private readonly ILogger<EmployeeUpdatedConsumer> _logger;
        private readonly IEmployeesService _employeesService;

        public EmployeeUpdatedConsumer(ILogger<EmployeeUpdatedConsumer> logger, IEmployeesService employeesService)
        {
            _logger = logger;
            _employeesService = employeesService;
        }

        public async Task Consume(ConsumeContext<IEmployeeUpdatedEvent> context)
        {
            try
            {
                IEmployeeUpdatedEvent message = context.Message;
                var employee = new EmployeeUpdateRequest(message.EmployeeID,message.NewEmployeeName!, message.AddressID);
                EmployeeResponse? result = await _employeesService.UpdateEmployee(employee);

                _logger.LogInformation(result is not null ? $"Updated Employee {result.EmployeeID} {result.EmployeeName}" : "Failed to update employee to aggregator database");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing employee update event");
                throw;
            }


        }
    }
}
