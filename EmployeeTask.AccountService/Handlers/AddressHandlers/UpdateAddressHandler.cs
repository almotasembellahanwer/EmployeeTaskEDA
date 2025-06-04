using EmployeeTask.AccountService.AddressCommands;
using EmployeeTask.AccountService.ServiceContracts;
using MassTransit;
using MediatR;
using SharedModels.DTO.AddressDTO;
using SharedModels.RabbitMQEvents;

namespace EmployeeTask.AccountService.Handlers.AddressHandlers
{
    public class UpdateAddressHandler : IRequestHandler<UpdateAddressCommand, AddressResponse>
    {
        private readonly IAddressesService _addressesService;
        private readonly IPublishEndpoint _publishEndpoint;

        public UpdateAddressHandler(IAddressesService addressesService, IPublishEndpoint publishEndpoint)
        {
            _addressesService = addressesService;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<AddressResponse> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            AddressResponse? addressResponse = await _addressesService.UpdateAddress(request.AddressDTO);
            if (addressResponse is not null)
            {
                // Publish the event for update to rabbitmq
                await _publishEndpoint.Publish<IAddressUpdatedEvent>(new
                {
                    addressResponse.AddressID,
                    NewAddressName = addressResponse.AddressName,
                    UpdatedAt = DateTime.UtcNow
                });
            }
            return addressResponse ?? throw new InvalidOperationException("Error while adding an employee");
        }
    }
}
