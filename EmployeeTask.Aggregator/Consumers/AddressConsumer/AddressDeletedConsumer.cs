using EmployeeTask.Aggregator.ServiceContracts;
using Mapster;
using MassTransit;
using SharedModels.DTO.AddressDTO;
using SharedModels.RabbitMQEvents;

namespace EmployeeTask.Aggregator.Consumers.AddressConsumer
{
    public class AddressDeletedConsumer : IConsumer<IAddressDeletedEvent>
    {
        private readonly ILogger<AddressDeletedConsumer> _logger;
        private readonly IAddressesService _addressesService;

        public AddressDeletedConsumer(ILogger<AddressDeletedConsumer> logger, IAddressesService addressesService)
        {
            _logger = logger;
            _addressesService = addressesService;
        }

        public async Task Consume(ConsumeContext<IAddressDeletedEvent> context)
        {
            try
            {
                IAddressDeletedEvent message = context.Message;
                bool isDeleted = await _addressesService.DeleteAddress(message.AddressID);
                _logger.LogError(isDeleted ? "Successfully Deleted address" : "Failed to delete address");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing address delete event");
                throw;
            }


        }
    }
}
