using EmployeeTask.Aggregator.ServiceContracts;
using Mapster;
using MassTransit;
using SharedModels.DTO.EmployeeDTO;
using SharedModels.RabbitMQEvents;

namespace EmployeeTask.Aggregator.Consumers.EmployeeConsumer
{
    public class EmployeeAddedConsumer : IConsumer<IEmployeeCreatedEvent>
    {
        private readonly ILogger<EmployeeAddedConsumer> _logger;
        private readonly IEmployeesService _employeesService;

        public EmployeeAddedConsumer(ILogger<EmployeeAddedConsumer> logger, IEmployeesService employeesService)
        {
            _logger = logger;
            _employeesService = employeesService;
        }

        public async Task Consume(ConsumeContext<IEmployeeCreatedEvent> context)
        {
            try
            {
                IEmployeeCreatedEvent message = context.Message;
                _logger.LogInformation("Employee Added: {EmployeeID}, {EmployeeName}, {AddressName}"
                    , message.EmployeeID, message.EmployeeName, message.AddressName);
                var employee = message.Adapt<EmployeeAddRequest>();
                EmployeeResponse? result = await _employeesService.AddEmployee(employee);
                if (result is null)
                {
                    _logger.LogError("Failed to add employee to aggregator database");
                }
                else
                {
                    _logger.LogInformation("Successfully added employee to aggregator: {EmployeeID}", result.EmployeeID);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing employee add event");
                throw;
            }


        }
    }
}
