using EmployeeTask.Aggregator.ServiceContracts;
using MassTransit;
using SharedModels.RabbitMQEvents.AreaEvents;
using SharedModels.RabbitMQEvents.GovernorateEvents;

namespace EmployeeTask.Aggregator.AreaConsumer
{
    public class AreaDeletedConsumer : IConsumer<IAreaDeletedEvent>
    {
        private readonly ILogger<AreaDeletedConsumer> _logger;
        private readonly IAreasService _areasService;

        public AreaDeletedConsumer(ILogger<AreaDeletedConsumer> logger, IAreasService areasService)
        {
            _logger = logger;
            _areasService = areasService;
        }

        public async Task Consume(ConsumeContext<IAreaDeletedEvent> context)
        {
            try
            {
                IAreaDeletedEvent message = context.Message;
                bool isDeleted = await _areasService.DeleteArea(message.AreaID);
                _logger.LogInformation(isDeleted ? "Successfully Deleted area" : "Failed to delete area");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing area delete event");
                throw;
            }


        }
    }
}
