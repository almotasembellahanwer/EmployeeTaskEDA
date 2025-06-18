using EmployeeTask.Aggregator.ServiceContracts;
using MassTransit;
using SharedModels.DTO.DepartmentDTO;
using SharedModels.RabbitMQEvents.DepartmentEvents;
namespace EmployeeTask.Aggregator.DepartmentConsumer
{
    public class DepartmentAddedConsumer : IConsumer<IDepartmentCreatedEvent>
    {
        private readonly ILogger<DepartmentAddedConsumer> _logger;
        private readonly IDepartmentsService _departmentsService;

        public DepartmentAddedConsumer(ILogger<DepartmentAddedConsumer> logger, IDepartmentsService departmentsService)
        {
            _logger = logger;
            _departmentsService = departmentsService;
        }

        public async Task Consume(ConsumeContext<IDepartmentCreatedEvent> context)
        {
            try
            {
                IDepartmentCreatedEvent message = context.Message;
                _logger.LogInformation("Department Added: {DepartmentID}, {DepartmentName}, {Active}"
                    , message.DepartmentID, message.DepartmentName, message.Active);
                var department = new DepartmentAddRequest()
                {
                    DepartmentName = message.DepartmentName!,
                    Active = message.Active
                };
                DepartmentResponse? result = await _departmentsService.AddDepartment(department);
                if (result is null)
                {
                    _logger.LogError("Failed to add department to aggregator database");
                }
                else
                {
                    _logger.LogInformation("Successfully added department to aggregator: {DepartmentID}", result.DepartmentID);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing department add event");
                throw;
            }


        }
    }
}
