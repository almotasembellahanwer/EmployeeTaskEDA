using EmployeeTask.Aggregator.ServiceContracts;
using Mapster;
using MassTransit;
using SharedModels.DTO.AddressDTO;
using SharedModels.DTO.AreaDTO;
using SharedModels.DTO.GovernorateDTO;
using SharedModels.RabbitMQEvents.AddressEvents;
using SharedModels.RabbitMQEvents.AreaEvents;
using SharedModels.RabbitMQEvents.GovernorateEvents;

namespace EmployeeTask.Aggregator.AreaConsumer
{
    public class AreaUpdatedConsumer : IConsumer<IAreaUpdatedEvent>
    {
        private readonly ILogger<AreaUpdatedConsumer> _logger;
        private readonly IAreasService _areasService;

        public AreaUpdatedConsumer(ILogger<AreaUpdatedConsumer> logger, IAreasService areasService)
        {
            _logger = logger;
            _areasService = areasService;
        }

        public async Task Consume(ConsumeContext<IAreaUpdatedEvent> context)
        {
            try
            {
                IAreaUpdatedEvent message = context.Message;
                var area = new AreaUpdateRequest(message.AreaID, message.ArabicName!,message.EnglishName!, message.GovernorateID);
                AreaResponse? result = await _areasService.UpdateArea(area);

                _logger.LogInformation(result is not null ? $"Updated Area {result.AreaID} {result.ArabicName} {result.EnglishName} {result.GovernorateID}" : "Failed to update area to aggregator database");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing area update event");
                throw;
            }


        }
    }
}
