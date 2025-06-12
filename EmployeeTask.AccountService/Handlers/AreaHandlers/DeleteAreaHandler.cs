using EmployeeTask.AccountService.AreaCommands;
using EmployeeTask.AccountService.GovernorateCommands;
using EmployeeTask.AccountService.ServiceContracts;
using MassTransit;
using MediatR;
using SharedModels.RabbitMQEvents.AreaEvents;
using SharedModels.RabbitMQEvents.GovernorateEvents;

namespace EmployeeTask.AccountService.Handlers.AreaHandlers
{
    public class DeleteAreaHandler : IRequestHandler<DeleteAreaCommand, bool>
    {
        private readonly IAreasService _areasService;
        private readonly IPublishEndpoint _publishEndpoint;

        public DeleteAreaHandler(IAreasService areasService, IPublishEndpoint publishEndpoint)
        {
            _areasService = areasService;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<bool> Handle(DeleteAreaCommand request, CancellationToken cancellationToken)
        {
            bool isDeleted = await _areasService.DeleteArea(request.AreaID);
            if (isDeleted)
            {
                // Publish the event to rabbitmq
                await _publishEndpoint.Publish<IAreaDeletedEvent>(new
                {
                    request.AreaID,
                    DeletedAt = DateTime.UtcNow
                });
            }
            return isDeleted;
        }
    }
}
