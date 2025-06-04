using EmployeeTask.Aggregator.ServiceContracts;
using Mapster;
using MassTransit;
using SharedModels.DTO.AddressDTO;
using SharedModels.RabbitMQEvents;

namespace EmployeeTask.Aggregator.Consumers.AddressConsumer
{
    public class AddressUpdatedConsumer : IConsumer<IAddressUpdatedEvent>
    {
        private readonly ILogger<AddressUpdatedConsumer> _logger;
        private readonly IAddressesService _addressesService;

        public AddressUpdatedConsumer(ILogger<AddressUpdatedConsumer> logger, IAddressesService addressesService)
        {
            _logger = logger;
            _addressesService = addressesService;
        }

        public async Task Consume(ConsumeContext<IAddressUpdatedEvent> context)
        {
            try
            {
                IAddressUpdatedEvent message = context.Message;
                var address = new AddressUpdateRequest(message.AddressID,message.NewAddressName!);
                AddressResponse? result = await _addressesService.UpdateAddress(address);

                _logger.LogError(result is not null ? $"Updated Address {result.AddressID} {result.AddressName}" : "Failed to update address to aggregator database");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing address update event");
                throw;
            }


        }
    }
}
