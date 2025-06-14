using EmployeeTask.Aggregator.ServiceContracts;
using EmployeeTask.Aggregator.Services;
using Mapster;
using MassTransit;
using SharedModels.DTO.DistrictDTO;
using SharedModels.DTO.GovernorateDTO;
using SharedModels.RabbitMQEvents.DistrictEvents;
using SharedModels.RabbitMQEvents.GovernorateEvents;

namespace EmployeeTask.Aggregator.DistrictConsumer
{
    public class DistrictAddedConsumer : IConsumer<IDistrictCreatedEvent>
    {
        private readonly ILogger<DistrictAddedConsumer> _logger;
        private readonly IDistrictsService _districtsService;

        public DistrictAddedConsumer(ILogger<DistrictAddedConsumer> logger, IDistrictsService districtsService)
        {
            _logger = logger;
            _districtsService = districtsService;
        }

        public async Task Consume(ConsumeContext<IDistrictCreatedEvent> context)
        {
            try
            {
                IDistrictCreatedEvent message = context.Message;
                _logger.LogInformation("District Added: {DistrictID}, {ArabicName}, {EnglishName}, {AreaID}"
                    , message.DistrictID, message.ArabicName,message.EnglishName, message.AreaID);
                var district = new DistrictAddRequest(message.ArabicName!, message.EnglishName!, message.AreaID);
                DistrictResponse? result = await _districtsService.AddDistrict(district);
                if (result is null)
                {
                    _logger.LogError("Failed to add district to aggregator database");
                }
                else
                {
                    _logger.LogInformation("Successfully added district to aggregator: {DistrictID}", result.DistrictID);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing district add event");
                throw;
            }


        }
    }
}
