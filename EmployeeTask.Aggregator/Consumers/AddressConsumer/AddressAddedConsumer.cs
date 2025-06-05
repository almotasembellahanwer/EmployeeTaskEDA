using EmployeeTask.Aggregator.ServiceContracts;
using Mapster;
using MassTransit;
using SharedModels.DTO.AddressDTO;
using SharedModels.RabbitMQEvents.AddressEvents;

namespace EmployeeTask.Aggregator.AddressConsumer
{
    public class AddressAddedConsumer : IConsumer<IAddressCreatedEvent>
    {
        private readonly ILogger<AddressAddedConsumer> _logger;
        private readonly IAddressesService _addressesService;

        public AddressAddedConsumer(ILogger<AddressAddedConsumer> logger, IAddressesService addressesService)
        {
            _logger = logger;
            _addressesService = addressesService;
        }

        public async Task Consume(ConsumeContext<IAddressCreatedEvent> context)
        {
            try
            {
                IAddressCreatedEvent message = context.Message;
                _logger.LogInformation("Address Added: {AddressID}, {AddressName}"
                    , message.AddressID, message.AddressName);
                var address = message.Adapt<AddressAddRequest>();
                AddressResponse? result = await _addressesService.AddAddress(address);
                if (result is null)
                {
                    _logger.LogError("Failed to add address to aggregator database");
                }
                else
                {
                    _logger.LogInformation("Successfully added address to aggregator: {AddressID}", result.AddressID);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing address add event");
                throw;
            }


        }
    }
}
