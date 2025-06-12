using EmployeeTask.Aggregator.ServiceContracts;
using Mapster;
using MassTransit;
using SharedModels.DTO.GovernorateDTO;
using SharedModels.RabbitMQEvents.GovernorateEvents;

namespace EmployeeTask.Aggregator.GovernorateConsumer
{
    public class GovernorateAddedConsumer : IConsumer<IGovernorateCreatedEvent>
    {
        private readonly ILogger<GovernorateAddedConsumer> _logger;
        private readonly IGovernoratesService _governoratesService;

        public GovernorateAddedConsumer(ILogger<GovernorateAddedConsumer> logger, IGovernoratesService governoratesService)
        {
            _logger = logger;
            _governoratesService = governoratesService;
        }

        public async Task Consume(ConsumeContext<IGovernorateCreatedEvent> context)
        {
            try
            {
                IGovernorateCreatedEvent message = context.Message;
                _logger.LogInformation("Governorate Added: {GovernorateID}, {ArabicName}, {EnglishName}"
                    , message.GovernorateID, message.ArabicName,message.EnglishName);
                var governorate = message.Adapt<GovernorateAddRequest>();
                GovernorateResponse? result = await _governoratesService.AddGovernorate(governorate);
                if (result is null)
                {
                    _logger.LogError("Failed to add governorate to aggregator database");
                }
                else
                {
                    _logger.LogInformation("Successfully added governorate to aggregator: {GovernorateID}", result.GovernorateID);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing governorate add event");
                throw;
            }


        }
    }
}
