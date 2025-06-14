using EmployeeTask.Aggregator.ServiceContracts;
using Mapster;
using MassTransit;
using SharedModels.DTO.AddressDTO;
using SharedModels.DTO.DistrictDTO;
using SharedModels.DTO.GovernorateDTO;
using SharedModels.RabbitMQEvents.AddressEvents;
using SharedModels.RabbitMQEvents.DistrictEvents;
using SharedModels.RabbitMQEvents.GovernorateEvents;

namespace EmployeeTask.Aggregator.DistrictConsumer
{
    public class DistrictUpdatedConsumer : IConsumer<IDistrictUpdatedEvent>
    {
        private readonly ILogger<DistrictUpdatedConsumer> _logger;
        private readonly IDistrictsService _districtsService;

        public DistrictUpdatedConsumer(ILogger<DistrictUpdatedConsumer> logger, IDistrictsService districtsService)
        {
            _logger = logger;
            _districtsService = districtsService;
        }

        public async Task Consume(ConsumeContext<IDistrictUpdatedEvent> context)
        {
            try
            {
                IDistrictUpdatedEvent message = context.Message;
                var district = new DistrictUpdateRequest(message.DistrictID, message.ArabicName!,message.EnglishName!, message.AreaID);
                DistrictResponse? result = await _districtsService.UpdateDistrict(district);

                _logger.LogInformation(result is not null ? $"Updated District {result.DistrictID} {result.ArabicName} {result.EnglishName} {result.AreaID}" : "Failed to update district to aggregator database");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing district update event");
                throw;
            }


        }
    }
}
