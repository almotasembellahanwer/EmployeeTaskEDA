using EmployeeTask.AccountService.AddressCommands;
using EmployeeTask.AccountService.ServiceContracts;
using MassTransit;
using MediatR;
using SharedModels.DTO.AddressDTO;
using SharedModels.RabbitMQEvents;

namespace EmployeeTask.AccountService.Handlers.AddressHandlers
{
    public class AddAddressHandler : IRequestHandler<AddAddressCommand, AddressResponse>
    {
        private readonly IAddressesService _addressesService;
        private readonly IPublishEndpoint _publishEndpoint;

        public AddAddressHandler(IAddressesService addressesService, IPublishEndpoint publishEndpoint)
        {
            _addressesService = addressesService;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<AddressResponse> Handle(AddAddressCommand request, CancellationToken cancellationToken)
        {
            AddressResponse? addressResponse = await _addressesService.AddAddress(request.AddressDTO);
            if (addressResponse is not null)
            {
                // Publish the event to rabbitmq
                await _publishEndpoint.Publish<IAddressCreatedEvent>(new
                {
                    addressResponse.AddressID,
                    addressResponse.AddressName
                });
            }
            return addressResponse ?? throw new InvalidOperationException("Error while adding an employee");
        }
    }
}
