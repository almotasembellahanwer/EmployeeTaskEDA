using EmployeeTask.Aggregator.ServiceContracts;
using Mapster;
using MassTransit;
using SharedModels.DTO.AddressDTO;
using SharedModels.DTO.GovernorateDTO;
using SharedModels.RabbitMQEvents.AddressEvents;
using SharedModels.RabbitMQEvents.GovernorateEvents;

namespace EmployeeTask.Aggregator.GovernorateConsumer
{
    public class GovernorateUpdatedConsumer : IConsumer<IGovernorateUpdatedEvent>
    {
        private readonly ILogger<GovernorateUpdatedConsumer> _logger;
        private readonly IGovernoratesService _governoratesService;

        public GovernorateUpdatedConsumer(ILogger<GovernorateUpdatedConsumer> logger, IGovernoratesService governoratesService)
        {
            _logger = logger;
            _governoratesService = governoratesService;
        }

        public async Task Consume(ConsumeContext<IGovernorateUpdatedEvent> context)
        {
            try
            {
                IGovernorateUpdatedEvent message = context.Message;
                var governorate = new GovernorateUpdateRequest(message.GovernorateID,message.ArabicName!,message.EnglishName!);
                GovernorateResponse? result = await _governoratesService.UpdateGovernorate(governorate);

                _logger.LogInformation(result is not null ? $"Updated Governorate {result.GovernorateID} {result.ArabicName} {result.EnglishName}" : "Failed to update governorate to aggregator database");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing governorate update event");
                throw;
            }


        }
    }
}
