using EmployeeTask.AccountService.AddressCommands;
using EmployeeTask.AccountService.ServiceContracts;
using MassTransit;
using MediatR;
using SharedModels.RabbitMQEvents;

namespace EmployeeTask.AccountService.Handlers.AddressHandlers
{
    public class DeleteAddressHandler : IRequestHandler<DeleteAddressCommand, bool>
    {
        private readonly IAddressesService _addressesService;
        private readonly IPublishEndpoint _publishEndpoint;

        public DeleteAddressHandler(IAddressesService addressesService, IPublishEndpoint publishEndpoint)
        {
            _addressesService = addressesService;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<bool> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            bool isDeleted = await _addressesService.DeleteAddress(request.AddressID);
            if (isDeleted)
            {
                // Publish the event to rabbitmq
                await _publishEndpoint.Publish<IAddressDeletedEvent>(new
                {
                    request.AddressID,
                    DeletedAt = DateTime.UtcNow
                });
            }
            return isDeleted;
        }
    }
}
