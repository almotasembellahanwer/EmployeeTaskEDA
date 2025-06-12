using EmployeeTask.Aggregator.ServiceContracts;
using MassTransit;
using SharedModels.RabbitMQEvents.GovernorateEvents;

namespace EmployeeTask.Aggregator.GovernorateConsumer
{
    public class GovernorateDeletedConsumer : IConsumer<IGovernorateDeletedEvent>
    {
        private readonly ILogger<GovernorateDeletedConsumer> _logger;
        private readonly IGovernoratesService _governoratesService;

        public GovernorateDeletedConsumer(ILogger<GovernorateDeletedConsumer> logger, IGovernoratesService governoratesService)
        {
            _logger = logger;
            _governoratesService = governoratesService;
        }

        public async Task Consume(ConsumeContext<IGovernorateDeletedEvent> context)
        {
            try
            {
                IGovernorateDeletedEvent message = context.Message;
                bool isDeleted = await _governoratesService.DeleteGovernorate(message.GovernorateID);
                _logger.LogInformation(isDeleted ? "Successfully Deleted governorate" : "Failed to delete governorate");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing governorate delete event");
                throw;
            }


        }
    }
}
