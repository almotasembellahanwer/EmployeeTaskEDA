using EmployeeTask.Aggregator.ServiceContracts;
using MassTransit;
using SharedModels.RabbitMQEvents.DistrictEvents;
using SharedModels.RabbitMQEvents.GovernorateEvents;

namespace EmployeeTask.Aggregator.DistrictConsumer
{
    public class DistrictDeletedConsumer : IConsumer<IDistrictDeletedEvent>
    {
        private readonly ILogger<DistrictDeletedConsumer> _logger;
        private readonly IDistrictsService _districtsService;

        public DistrictDeletedConsumer(ILogger<DistrictDeletedConsumer> logger, IDistrictsService districtsService)
        {
            _logger = logger;
            _districtsService = districtsService;
        }

        public async Task Consume(ConsumeContext<IDistrictDeletedEvent> context)
        {
            try
            {
                IDistrictDeletedEvent message = context.Message;
                bool isDeleted = await _districtsService.DeleteDistrict(message.DistrictID);
                _logger.LogInformation(isDeleted ? "Successfully Deleted district" : "Failed to delete district");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing district delete event");
                throw;
            }


        }
    }
}
