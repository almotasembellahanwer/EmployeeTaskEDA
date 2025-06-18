using EmployeeTask.Aggregator.ServiceContracts;
using MassTransit;
using SharedModels.DTO.DepartmentDTO;
using SharedModels.RabbitMQEvents.DepartmentEvents;

namespace EmployeeTask.Aggregator.DepartmentConsumer
{
    public class DepartmentUpdatedConsumer : IConsumer<IDepartmentUpdatedEvent>
    {
        private readonly ILogger<DepartmentUpdatedConsumer> _logger;
        private readonly IDepartmentsService _departmentsService;

        public DepartmentUpdatedConsumer(ILogger<DepartmentUpdatedConsumer> logger, IDepartmentsService departmentsService)
        {
            _logger = logger;
            _departmentsService = departmentsService;
        }

        public async Task Consume(ConsumeContext<IDepartmentUpdatedEvent> context)
        {
            try
            {
                IDepartmentUpdatedEvent message = context.Message;
                var department = new DepartmentUpdateRequest(message.DepartmentID, message.DepartmentName!,message.Active);
                DepartmentResponse? result = await _departmentsService.UpdateDepartment(department);

                _logger.LogInformation(result is not null ? $"Updated Department {result.DepartmentID} {result.DepartmentName} {result.Active} {result.CreatedAt}" : "Failed to update department to aggregator database");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing department update event");
                throw;
            }


        }
    }
}
