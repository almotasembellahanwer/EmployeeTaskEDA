using EmployeeTask.Aggregator.ServiceContracts;
using Mapster;
using MassTransit;
using SharedModels.DTO.AddressDTO;
using SharedModels.RabbitMQEvents.AddressEvents;

namespace EmployeeTask.Aggregator.EmployeeConsumer
{
    public class EmployeeDeletedConsumer : IConsumer<IAddressDeletedEvent>
    {
        private readonly ILogger<EmployeeDeletedConsumer> _logger;
        private readonly IAddressesService _addressesService;

        public EmployeeDeletedConsumer(ILogger<EmployeeDeletedConsumer> logger, IAddressesService addressesService)
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
                _logger.LogInformation(isDeleted ? "Successfully Deleted address" : "Failed to delete address");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing address delete event");
                throw;
            }


        }
    }
}
