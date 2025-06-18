using EmployeeTask.Aggregator.ServiceContracts;
using MassTransit;
using SharedModels.RabbitMQEvents.DepartmentEvents;
namespace EmployeeTask.Aggregator.DepartmentConsumer
{
    public class DepartmentDeletedConsumer : IConsumer<IDepartmentDeletedEvent>
    {
        private readonly ILogger<DepartmentDeletedConsumer> _logger;
        private readonly IDepartmentsService _departmentsService;

        public DepartmentDeletedConsumer(ILogger<DepartmentDeletedConsumer> logger, IDepartmentsService departmentsService)
        {
            _logger = logger;
            _departmentsService = departmentsService;
        }

        public async Task Consume(ConsumeContext<IDepartmentDeletedEvent> context)
        {
            try
            {
                IDepartmentDeletedEvent message = context.Message;
                bool isDeleted = await _departmentsService.DeleteDepartment(message.DepartmentID);
                _logger.LogInformation(isDeleted ? "Successfully Deleted department" : "Failed to delete department");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing department delete event");
                throw;
            }


        }
    }
}
