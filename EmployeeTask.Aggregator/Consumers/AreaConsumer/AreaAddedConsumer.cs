using EmployeeTask.Aggregator.ServiceContracts;
using EmployeeTask.Aggregator.Services;
using Mapster;
using MassTransit;
using SharedModels.DTO.AreaDTO;
using SharedModels.DTO.GovernorateDTO;
using SharedModels.RabbitMQEvents.AreaEvents;
using SharedModels.RabbitMQEvents.GovernorateEvents;

namespace EmployeeTask.Aggregator.AreaConsumer
{
    public class AreaAddedConsumer : IConsumer<IAreaCreatedEvent>
    {
        private readonly ILogger<AreaAddedConsumer> _logger;
        private readonly IAreasService _areasService;

        public AreaAddedConsumer(ILogger<AreaAddedConsumer> logger, IAreasService areasService)
        {
            _logger = logger;
            _areasService = areasService;
        }

        public async Task Consume(ConsumeContext<IAreaCreatedEvent> context)
        {
            try
            {
                IAreaCreatedEvent message = context.Message;
                _logger.LogInformation("Area Added: {AreaID}, {ArabicName}, {EnglishName}, {GovernorateID}"
                    , message.AreaID, message.ArabicName,message.EnglishName, message.GovernorateID);
                var area = new AreaAddRequest(message.ArabicName!, message.EnglishName!, message.GovernorateID);
                AreaResponse? result = await _areasService.AddArea(area);
                if (result is null)
                {
                    _logger.LogError("Failed to add area to aggregator database");
                }
                else
                {
                    _logger.LogInformation("Successfully added area to aggregator: {AreaID}", result.AreaID);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing area add event");
                throw;
            }


        }
    }
}
