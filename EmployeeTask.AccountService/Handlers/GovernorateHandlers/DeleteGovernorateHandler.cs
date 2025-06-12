using EmployeeTask.AccountService.GovernorateCommands;
using EmployeeTask.AccountService.ServiceContracts;
using MassTransit;
using MediatR;
using SharedModels.RabbitMQEvents.GovernorateEvents;

namespace EmployeeTask.AccountService.Handlers.GovernorateHandlers
{
    public class DeleteGovernorateHandler : IRequestHandler<DeleteGovernorateCommand, bool>
    {
        private readonly IGovernoratesService _governoratesService;
        private readonly IPublishEndpoint _publishEndpoint;

        public DeleteGovernorateHandler(IGovernoratesService governoratesService, IPublishEndpoint publishEndpoint)
        {
            _governoratesService = governoratesService;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<bool> Handle(DeleteGovernorateCommand request, CancellationToken cancellationToken)
        {
            bool isDeleted = await _governoratesService.DeleteGovernorate(request.GovernorateID);
            if (isDeleted)
            {
                // Publish the event to rabbitmq
                await _publishEndpoint.Publish<IGovernorateDeletedEvent>(new
                {
                    request.GovernorateID,
                    DeletedAt = DateTime.UtcNow
                });
            }
            return isDeleted;
        }
    }
}
